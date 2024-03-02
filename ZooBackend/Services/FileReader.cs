using System.Xml.Linq;

public static class FileReader
{
  public static List<Animal> ReadAnimals(string path)
  {
    var animals = new List<Animal>();
    using var reader = new StreamReader(path);
    string? line;
    while ((line = reader.ReadLine()) != null)
    {
      var values = line.Split(';');

      var animal = new Animal
      {
        Species = values[0],
        Consumption = Convert.ToDouble(values[1]),
        Diet = values[2],
        MeatPercentage = values[3] == "" ? 0 : Convert.ToInt32(values[3].Replace("%", ""))
      };
      animals.Add(animal);
    }
    return animals;
  }
  public static List<Price> ReadPrices(string path)
  {
    var prices = new List<Price>();
    using (var reader = new StreamReader(path))
    {
      string? line;
      while ((line = reader.ReadLine()) != null)
      {
        var values = line.Split('=');
        var price = new Price
        {
          Food = values[0],
          Cost = Convert.ToDouble(values[1])
        };
        prices.Add(price);
      }
    }
    return prices;
  }

  public static List<Individual> ReadIndividuals(string path)
  {
    var individuals = new List<Individual>();

    var content = File.ReadAllText(path);
    var doc = XDocument.Parse(content);

    foreach (var animal in doc.Element("Zoo")!.Elements())
    {
      string species = animal.Name.LocalName;
      foreach (var individual in animal.Elements())
      {
        individuals.Add(new Individual
        {
          Species = species,
          Name = individual.Attribute("name")!.Value,
          Weight = Convert.ToDouble(individual.Attribute("kg")!.Value)
        });
      }
    }
    return individuals;
  }
}