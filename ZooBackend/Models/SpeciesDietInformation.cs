namespace ZooBackend;

public class SpeciesDietInformation
{
  public string Species { get; set; } = default!;
  public double Consumption { get; set; }
  public string Diet { get; set; } = default!;
  public int MeatPercentage { get; set; }
  public int FruitPercentage { get => FruitPercentageCalculator(); }
  public string DietType => Diet switch
  {
    "meat" => "Carnivore",
    "fruit" => "Herbivore",
    "both" => "Omnivore",
    _ => ""
  };

  private int FruitPercentageCalculator()
  {
    return Diet switch
    {
      "meat" => 0,
      "fruit" => 100,
      "both" => 100 - MeatPercentage,
      _ => 0
    };
  }
  public double CalculateIndividualCost(List<Price> prices, Animal animal)
  {
    var cost = Diet switch
    {
      "meat" => animal.Weight * Consumption * prices[0].Cost,
      "fruit" => animal.Weight * Consumption * prices[1].Cost,
      "both" => (OmnivoreConsumption(animal, MeatPercentage) * prices[0].Cost) +
                (OmnivoreConsumption(animal, FruitPercentage) * prices[1].Cost),
      _ => throw new ArgumentOutOfRangeException()
    };

    return cost;
  }

  private double OmnivoreConsumption(Animal animal, double percentage)
  {
    return animal.Weight * Consumption * (percentage / 100.00);
  }
}