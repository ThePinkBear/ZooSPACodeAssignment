public interface IFileReader
{
  List<AnimalDietInformation> ReadAnimals();
  List<Price> ReadPrices();
  List<Animal> ReadIndividuals();
}