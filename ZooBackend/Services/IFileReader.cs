public interface IFileReader
{
  List<SpeciesDietInformation> ReadSpeciesInformation();
  List<Price> ReadPrices();
  List<Animal> ReadAnimals();
}