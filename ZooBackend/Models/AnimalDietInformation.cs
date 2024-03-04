
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
}