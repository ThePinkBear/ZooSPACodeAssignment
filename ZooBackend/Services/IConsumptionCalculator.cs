public interface IConsumptionCalculator
{
  public double CalculateTotalCost();
  public double CalculateIndividualCost(List<Price> prices, Individual individual, Animal animal);
}
