public interface IConsumptionCalculator
{
  public List<AnimalDTO> ZooAnimals();
  public double CalculateTotalCost();
  public double CalculateIndividualCost(List<Price> prices, Animal individual, AnimalDietInformation animal);
}
