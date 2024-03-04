public static class EndPointLogic
{
  public static double GetPrices(IFileReader reader)
  {
    return new ConsumptionCalculator(reader).CalculateTotalCost();
  }
  public static List<IndividualDTO> GetZooAnimals(IFileReader reader)
  {
    return new ConsumptionCalculator(reader).ZooAnimals();
  }
}