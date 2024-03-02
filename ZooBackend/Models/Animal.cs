namespace ZooBackend;

public class Animal
{
  public string Species { get; set; } = default!;
  public double Consumption { get; set; }
  public string Diet { get; set; } = default!;
  public int MeatPercentage { get; set; }
}