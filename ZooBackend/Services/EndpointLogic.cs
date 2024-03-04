public static class EndPointLogic
{
  public static double GetPrices(IFileReader reader)
  {
    return new AnimalHandler(reader).CalculateTotalCost();
  }
  public static List<AnimalDTO> GetZooAnimals(IFileReader reader)
  {
    return new AnimalHandler(reader).ZooAnimals();
  }
}