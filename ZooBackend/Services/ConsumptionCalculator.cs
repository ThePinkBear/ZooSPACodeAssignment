public class ConsumptionCalculator : IConsumptionCalculator
{
  private List<Individual> _individuals;
  private List<Animal> _animals;
  private List<Price> _prices;

  
  public ConsumptionCalculator(IFileReader reader)
  {
    _individuals = reader.ReadIndividuals();
    _animals = reader.ReadAnimals();
    _prices = reader.ReadPrices();
  }
  public List<IndividualDTO> ZooAnimals()
  {
    
    var animalDTOs = new List<IndividualDTO>();
    foreach (var individual in _individuals)
    {
      var animal = _animals.FirstOrDefault(a => a.Species == individual.Species)!;
      var cost = CalculateIndividualCost(_prices, individual, animal);
      var animalDTO = new IndividualDTO
      {
        Species = individual.Species,
        Name = individual.Name,
        Weight = individual.Weight,
        Cost = cost
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
      totalCost += CalculateIndividualCost(_prices, individual, _animals.FirstOrDefault(a => a.Species == individual.Species)!);
    }
    return Math.Round(totalCost, 2);
  }
  public double CalculateIndividualCost(List<Price> prices, Individual individual, Animal animal)
  {
    var cost = animal.Diet switch
    {
      "meat" => individual.Weight * animal.Consumption * prices[0].Cost,
      "fruit" => individual.Weight * animal.Consumption * prices[1].Cost,
      "both" => (OmnivoreConsumption(individual, animal, animal.MeatPercentage) * prices[0].Cost) + 
                (OmnivoreConsumption(individual, animal, animal.FruitPercentage) * prices[1].Cost),
      _ => throw new ArgumentOutOfRangeException()
    };

    return cost;
  }

  private double OmnivoreConsumption(Individual individual, Animal animal, double percentage)
  {
    return individual.Weight * animal.Consumption * (percentage / 100.00);
  }
}
