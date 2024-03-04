public class ConsumptionCalculator : IConsumptionCalculator
{
  private List<Animal> _individuals;
  private List<AnimalDietInformation> _animals;
  private List<Price> _prices;

  
  public ConsumptionCalculator(IFileReader reader)
  {
    _individuals = reader.ReadIndividuals();
    _animals = reader.ReadAnimals();
    _prices = reader.ReadPrices();
  }
  public List<AnimalDTO> ZooAnimals()
  {
    
    var animalDTOs = new List<AnimalDTO>();
    foreach (var individual in _individuals)
    {
      var animal = _animals.FirstOrDefault(a => a.Species == individual.Species);
      if (animal == null) continue;
      var cost = animal.CalculateIndividualCost(_prices, individual);
      var animalDTO = new AnimalDTO
      {
        Id = Guid.NewGuid(),
        Species = individual.Species,
        Name = individual.Name,
        Diet = animal?.Diet switch
        {
          "meat" => "Carnivore",
          "fruit" => "Herbivore",
          "both" => "Omnivore",
          _ => throw new ArgumentOutOfRangeException()
        },
        Weight = individual.Weight,
        Cost = Math.Round(cost, 2)
      };
      animalDTOs.Add(animalDTO);
    }
    return animalDTOs;
  }
  public double CalculateTotalCost()
  {
    var totalCost = 0.0;

    foreach (var individual in _individuals)
    {
      totalCost += _animals.FirstOrDefault(a => a.Species == individual.Species)!.CalculateIndividualCost(_prices, individual);
    }
    return Math.Round(totalCost, 2);
  }
}
