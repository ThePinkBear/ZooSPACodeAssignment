public static class ConsumptionCalculator
{
  public static double Calculate()
  {
    var animals = FileReader.ReadAnimals(@"..\ZooBackend\Data\animals.csv");
    var prices = FileReader.ReadPrices(@"..\ZooBackend\Data\prices.txt");
    var individuals = FileReader.ReadIndividuals(@"..\ZooBackend\Data\zoo.xml");

    var totalCost = 0.0;

    foreach (var individual in individuals)
    {
      totalCost += CalculateCost(prices, individual, animals.FirstOrDefault(a => a.Species == individual.Species)!);
    }
    return Math.Round(totalCost, 2);
  }
  public static double CalculateCost(List<Price> prices, Individual individual, Animal animal)
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

  private static double OmnivoreConsumption(Individual individual, Animal animal, double percentage)
  {
    return individual.Weight * animal.Consumption * (percentage / 100.00);
  }
}
