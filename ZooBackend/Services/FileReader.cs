using System.Xml.Linq;

public class FileReader : IFileReader
{
  private readonly string _animalPath = "";
  private readonly string _pricePath = "";
  private readonly string _individualPath = "";

  public FileReader(string animalPath, string pricePath, string individualPath)
  {
    _animalPath = animalPath;
    _pricePath = pricePath;
    _individualPath = individualPath;
  }
  public List<SpeciesDietInformation> ReadSpeciesInformation()
  {
    var animals = new List<SpeciesDietInformation>();
    using var reader = new StreamReader(_animalPath);
    string? line;
    while ((line = reader.ReadLine()) != null)
    {
      var values = line.Split(';');

      var animal = new SpeciesDietInformation
      {
        Species = values[0],
        Consumption = Convert.ToDouble(values[1]),
        Diet = values[2],
        MeatPercentage = values[2] switch 
         {
          "meat" => 100,
          "fruit" => 0,
          "both" => Convert.ToInt32(values[3].Replace("%", "")),
          _ => throw new ArgumentOutOfRangeException()
         }
      };
      animals.Add(animal);
    }
    return animals;
  }
  public List<Price> ReadPrices()
  {
    var prices = new List<Price>();
    using (var reader = new StreamReader(_pricePath))
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
  public List<Animal> ReadAnimals()
  {
    var animals = new List<Animal>();

    var content = File.ReadAllText(_individualPath);
    var doc = XDocument.Parse(content);

    foreach (var animal in doc.Element("Zoo")!.Elements())
    {
      var species = animal.Name.LocalName;
      var firstChild = animal.Elements().FirstOrDefault();
      if (firstChild != null) species = firstChild.Name.LocalName;
      
      foreach (var individual in animal.Elements())
      {
        animals.Add(new Animal
        {
          Species = species,
          Name = individual.Attribute("name")!.Value,
          Weight = Convert.ToDouble(individual.Attribute("kg")!.Value)
        });
      }
    }
    return animals;
  }
}