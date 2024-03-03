public class IndividualDTO
{
  public Guid Id { get; set; }
  public string Species { get; set; } = default!;
  public string Name { get; set; } = default!;
  public double Weight { get; set; }
  public double Cost { get; set; }
}