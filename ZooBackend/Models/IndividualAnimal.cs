namespace ZooBackend;

public class Individual : Animal
{
  public string Name { get; set; }
  public decimal Weight { get; set; }

  public Individual(string species, string diet, decimal consumption, int meatPercentage, string name, decimal weight) : base(species, diet, consumption, meatPercentage)
  {
    Name = name;
    Weight = weight;
  }
}