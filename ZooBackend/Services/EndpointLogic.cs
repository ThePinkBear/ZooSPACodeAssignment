public static class EndPointLogic
{
  public static double GetTotalCost(IFileReader reader)
  {
    return new AnimalHandler(reader).CalculateTotalCost();
  }
  public static List<AnimalDTO> GetZooAnimals(IFileReader reader)
  {
    return new AnimalHandler(reader).ZooAnimals();
  }
  public static double GetMeatCost(IFileReader reader)
  {
    return new AnimalHandler(reader).CalculateMeatCost();
  }
  public static double GetFruitCost(IFileReader reader)
  {
    return new AnimalHandler(reader).CalculateFruitCost();
  }
}