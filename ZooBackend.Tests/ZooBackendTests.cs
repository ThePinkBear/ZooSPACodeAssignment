using System.Globalization;

namespace ZooBackend.Tests;

public class ZooBackendTests
{
  [Fact]
  public void FileReader_should_read_Prices_file_correctly()
  {
    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
    // Arrange
    var path = @"..\..\..\..\ZooBackend\Data\prices.txt";

    // Act
    var prices = FileReader.ReadPrices(path);

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
    var path = @"..\..\..\..\ZooBackend\Data\animals.csv";

    // Act
    var animals = FileReader.ReadAnimals(path);

    // Assert
    Assert.Equal(6, animals.Count);
    Assert.Equal("Lion", animals[0].Species);
    Assert.Equal(0.10, animals[0].Consumption);
    Assert.Equal("meat", animals[0].Diet);
    Assert.Equal(0, animals[0].MeatPercentage);
    Assert.Equal("Piranha", animals[5].Species);
    Assert.Equal(50, animals[5].MeatPercentage);
  }
}