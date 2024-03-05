public class AnimalHandler : IAnimalHandler
{
  private List<Animal> _animals;
  private List<SpeciesDietInformation> _speciesInformation;
  private List<Price> _prices;

  public AnimalHandler(IFileReader reader)
  {
    _animals = reader.ReadAnimals();
    _speciesInformation = reader.ReadSpeciesInformation();
    _prices = reader.ReadPrices();
  }
  public List<AnimalDTO> GetAnimalDataTransferObjects()
  {
    if (_animals.Count == 0 || _prices.Count == 0 || _speciesInformation.Count == 0) return [];

    var animalDTOs = new List<AnimalDTO>();
    foreach (var animal in _animals)
    {
      var species = _speciesInformation.FirstOrDefault(a => a.Species == animal.Species);
      if (species == null) continue;
      var animalDTO = new AnimalDTO
      {
        Id = Guid.NewGuid(),
        Species = animal.Species,
        Name = animal.Name,
        Diet = species.DietType,
        Weight = animal.Weight,
        Cost = Math.Round(species.CalculateIndividualCost(_prices, animal), 2),
        Image = animal.Image
      };
      animalDTOs.Add(animalDTO);
    }
    return animalDTOs;
  }

  public double CalculateTotalCost()
  {
    if (_animals.Count == 0) return 0.0;

    var totalCost = _animals.Sum(animal => _speciesInformation.FirstOrDefault(a => a.Species == animal.Species)?.CalculateIndividualCost(_prices, animal) ?? 0.0);

    return Math.Round(totalCost, 2);
  }

  public double CalculateMeatCost()
  {
    if (_animals.Count == 0) return 0.0;
    var totalMeatCost = 0.0;
    var meatEaters = SortByDiet("meat");

    foreach (var animal in _animals)
    {
      var MeatPercentage = _speciesInformation.FirstOrDefault(a => a.Species == animal.Species)!.MeatPercentage / 100.0;
      var meatCost = CalculateDietCost(animal);
      totalMeatCost += meatCost * MeatPercentage;
    }
    return Math.Round(totalMeatCost, 2);
  }
  public double CalculateFruitCost()
  {
    if (_animals.Count == 0) return 0.0;
    var totalFruitCost = 0.0;
    var fruitEaters = SortByDiet("fruit");

    foreach (var animal in _animals)
    {
      var FruitPercentage = _speciesInformation.FirstOrDefault(a => a.Species == animal.Species)!.FruitPercentage / 100.0;
      var fruitCost = CalculateDietCost(animal);
      totalFruitCost += fruitCost * FruitPercentage;
    }
    return Math.Round(totalFruitCost, 2);
  }
  private List<Animal> SortByDiet(string diet) => (from a in _animals
                                                   join s in _speciesInformation on a.Species equals s.Species
                                                   where s.Diet == diet || s.Diet == "both"
                                                   select a).ToList();

  private double CalculateDietCost(Animal animal) => _speciesInformation
                  .FirstOrDefault(a => a.Species == animal.Species)!
                  .CalculateIndividualCost(_prices, animal);

}
