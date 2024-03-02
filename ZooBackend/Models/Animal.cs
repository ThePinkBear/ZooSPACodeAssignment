namespace ZooBackend;

public abstract class Animal
{
  public string Species { get; set; } = default!;
  public string Diet { get; set; } = default!;
  public decimal Consumption { get; set; }
  public int MeatPercentage { get; set; }
}