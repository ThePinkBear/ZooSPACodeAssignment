using System.Globalization;

namespace ZooBackend.Tests;

public class ZooBackendTests
{
  private readonly string _animalPath = @"../../../../ZooBackend/Data/animals.csv";
  private readonly string _pricePath = @"../../../../ZooBackend/Data/prices.txt";
  private readonly string _individualPath = @"../../../../ZooBackend/Data/zoo.xml";

  [Fact]
  public void FileReader_should_read_Prices_file_correctly()
  {
    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
    // Arrange
    var _reader = new FileReader(_animalPath, _pricePath, _individualPath);
    // Act
    var prices = _reader.ReadPrices();

    // Assert
    Assert.Equal(2, prices.Count);
    Assert.Equal("Meat", prices[0].Food);
    Assert.Equal(12.56, prices[0].Cost);
    Assert.Equal("Fruit", prices[1].Food);
    Assert.Equal(5.60, prices[1].Cost);
  }
  [Fact]
  public void FileReader_should_read_Animals_file_correctly()
  {
    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
    // Arrange
    var _reader = new FileReader(_animalPath, _pricePath, _individualPath);

    // Act
    var animals = _reader.ReadSpeciesInformation();

    // Assert
    Assert.Equal(6, animals.Count);
    Assert.Equal("Lion", animals[0].Species);
    Assert.Equal(0.10, animals[0].Consumption);
    Assert.Equal("meat", animals[0].Diet);
    Assert.Equal(100, animals[0].MeatPercentage);
    Assert.Equal("Piranha", animals[5].Species);
    Assert.Equal(50, animals[5].MeatPercentage);
  }
  [Fact]
  public void FileReader_should_read_Individuals_file_correctly()
  {
    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

    // Arrange
    var _reader = new FileReader(_animalPath, _pricePath, _individualPath);
    // Act
    var individuals = _reader.ReadAnimals();

    // Assert
    Assert.Equal(14, individuals.Count);
    Assert.Equal("Lion", individuals[0].Species);
    Assert.Equal(160, individuals[0].Weight);
    Assert.Equal("Piranha", individuals[13].Species);
    Assert.Equal(0.5, individuals[13].Weight);
  }
  [Fact]
  public void Animal_should_calculate_fruit_percentage_correctly()
  {
    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
    // Arrange
    var animal = new SpeciesDietInformation
    {
      Species = "Lion",
      Consumption = 0.10,
      Diet = "meat",
      MeatPercentage = 100
    };
    var animal2 = new SpeciesDietInformation
    {
      Species = "Giraffe",
      Consumption = 0.10,
      Diet = "fruit",
      MeatPercentage = 0
    };
    var animal3 = new SpeciesDietInformation
    {
      Species = "Piranha",
      Consumption = 0.10,
      Diet = "both",
      MeatPercentage = 50
    };

    // Act
    var actual = animal.FruitPercentage;

    // Assert
    Assert.Equal(0, actual);
    Assert.Equal(100, animal2.FruitPercentage);
    Assert.Equal(50, animal3.FruitPercentage);
  }
  [Fact]
  public void Animal_should_calculate_carnivore_consumption_correctly()
  {
    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
    // Arrange

    var individual = new Animal
    {
      Species = "Lion",
      Weight = 160
    };
    var animal = new SpeciesDietInformation
    {
      Species = "Lion",
      Consumption = 0.10,
      Diet = "meat",
      MeatPercentage = 100
    };
    var prices = new List<Price>
    {
      new Price { Food = "Meat", Cost = 12.56 },
      new Price { Food = "Fruit", Cost = 5.60 }
    };

    // Act
    var actual = animal.CalculateIndividualCost(prices, individual);

    // Assert
    Assert.Equal(200.96, Math.Round(actual, 2));
  }
  [Fact]
  public void Animal_should_calculate_herbivore_consumption_correctly()
  {
    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

    // Arrange
    var individual = new Animal
    {
      Species = "Giraffe",
      Weight = 160
    };
    var animal = new SpeciesDietInformation
    {
      Species = "Giraffe",
      Consumption = 0.10,
      Diet = "fruit",
      MeatPercentage = 0
    };
    var prices = new List<Price>
    {
      new Price { Food = "Meat", Cost = 12.56 },
      new Price { Food = "Fruit", Cost = 5.60 }
    };

    // Act
    var actual = animal.CalculateIndividualCost(prices, individual);

    // Assert
    Assert.Equal(89.60, Math.Round(actual, 2));
  }
  [Fact]
  public void Animal_should_calculate_omnivore_consumption_correctly()
  {
    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
    // Arrange
    var prices = new List<Price>
    {
      new Price { Food = "Meat", Cost = 12.56 },
      new Price { Food = "Fruit", Cost = 5.60 }
    };
    var individual = new Animal
    {
      Name = "Conny",
      Species = "Wolf",
      Weight = 70
    };
    var animal = new SpeciesDietInformation
    {
      Species = "Wolf",
      Consumption = 0.07,
      Diet = "both",
      MeatPercentage = 90
    };

    // Act
    var actual = animal.CalculateIndividualCost(prices, individual);

    // Assert
    Assert.Equal(58.13, Math.Round(actual, 2));
  }
  [Fact]
  public void ConsumptionCalculator_should_calculate_total_cost_correctly()
  {
    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
    // Arrange
    var _reader = new FileReader(_animalPath, _pricePath, _individualPath);
    var _calculator = new AnimalHandler(_reader);

    // Act
    var actual = _calculator.CalculateTotalCost();

    // Assert
    Assert.Equal(1609.01, Math.Round(actual, 2));
  }
  [Fact]
  public void ConsumptionCalculator_should_return_animalDTOs_correctly()
  {
    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
    // Arrange
    var _reader = new FileReader(_animalPath, _pricePath, _individualPath);
    var _calculator = new AnimalHandler(_reader);

    // Act
    var actual = _calculator.ZooAnimals();

    // Assert
    Assert.Equal(14, actual.Count);
    Assert.Equal("Simba", actual[0].Name);
    Assert.Equal("Lion", actual[0].Species);
    Assert.Equal("Piranha", actual[13].Species);
  }
  [Fact]
  public void ConsumptionCalculator_should_return_animalDTOs_with_correct_cost()
  {
    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
    // Arrange
    var _reader = new FileReader(_animalPath, _pricePath, _individualPath);
    var _calculator = new AnimalHandler(_reader);

    // Act
    var actual = _calculator.ZooAnimals();

    // Assert
    Assert.Equal(200.96, actual[0].Cost);
    Assert.Equal(2.27, actual[13].Cost);
  }
  [Fact]
  public void ConsumptionCalculator_should_return_animalDTOs_with_correct_weight()
  {
    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
    // Arrange
    var _reader = new FileReader(_animalPath, _pricePath, _individualPath);
    var _calculator = new AnimalHandler(_reader);

    // Act
    var actual = _calculator.ZooAnimals();

    // Assert
    Assert.Equal(160, actual[0].Weight);
    Assert.Equal(0.5, actual[13].Weight);
  }
}