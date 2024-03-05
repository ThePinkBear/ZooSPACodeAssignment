public interface IAnimalHandler
{
  public List<AnimalDTO> GetAnimalDataTransferObjects();
  public double CalculateTotalCost();
  public double CalculateMeatCost();
  public double CalculateFruitCost();
}
