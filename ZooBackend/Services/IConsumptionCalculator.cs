public interface IConsumptionCalculator
{
  public List<IndividualDTO> ZooAnimals();
  public double CalculateTotalCost();
  public double CalculateIndividualCost(List<Price> prices, Individual individual, Animal animal);
}
