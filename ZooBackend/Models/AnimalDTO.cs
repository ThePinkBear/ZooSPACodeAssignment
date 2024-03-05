public class AnimalDTO
{
  public Guid Id { get; set; }
  public string Species { get; set; } = default!;
  public string Name { get; set; } = default!;
  public string Diet { get; set; } = default!;
  public double Weight { get; set; }
  public double Cost { get; set; }
  public string Image { get; set; } = default!;
}