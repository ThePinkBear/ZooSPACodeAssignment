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
  public List<AnimalDTO> ZooAnimals()
  {
    
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
        Diet = species.DietType() ?? "",
        Weight = animal.Weight,
        Cost = Math.Round(species.CalculateIndividualCost(_prices, animal), 2)
      };
      animalDTOs.Add(animalDTO);
    }
    return animalDTOs;
  }

  public double CalculateTotalCost()
  {
    var totalCost = 0.0;

    foreach (var animal in _animals)
    {
      totalCost += _speciesInformation.FirstOrDefault(a => a.Species == animal.Species)!.CalculateIndividualCost(_prices, animal);
    }
    return Math.Round(totalCost, 2);
  }
}
