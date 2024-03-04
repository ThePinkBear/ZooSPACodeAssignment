
namespace ZooBackend;

public class AnimalDietInformation
{
  public string Species { get; set; } = default!;
  public double Consumption { get; set; }
  public string Diet { get; set; } = default!;
  public int MeatPercentage { get; set; }
  public int FruitPercentage { get => FruitPercentageCalculator(); }
  private int FruitPercentageCalculator()
  {
    return Diet switch
    {
      "meat" => 0,
      "fruit" => 100,
      "both" => 100 - MeatPercentage,
      _ => throw new ArgumentOutOfRangeException()
    };
  }
  public double CalculateIndividualCost(List<Price> prices, Animal individual)
  {
    var cost = Diet switch
    {
      "meat" => individual.Weight * Consumption * prices[0].Cost,
      "fruit" => individual.Weight * Consumption * prices[1].Cost,
      "both" => (OmnivoreConsumption(individual, MeatPercentage) * prices[0].Cost) + 
                (OmnivoreConsumption(individual, FruitPercentage) * prices[1].Cost),
      _ => throw new ArgumentOutOfRangeException()
    };

    return cost;
  }

  private double OmnivoreConsumption(Animal individual, double percentage)
  {
    return individual.Weight * Consumption * (percentage / 100.00);
  }
}