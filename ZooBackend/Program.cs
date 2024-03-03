var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

double GetPrices(IFileReader reader)
{
  return new ConsumptionCalculator(reader).CalculateTotalCost();
}
List<IndividualDTO> GetZooAnimals(IFileReader reader)
{
  return new ConsumptionCalculator(reader).ZooAnimals();
}

app.UseHttpsRedirection();
app.MapGet("/ZooAnimals", () =>
{
  return GetZooAnimals(new FileReader(@".\Data\animals.csv", @".\Data\prices.txt", @".\Data\zoo.xml"));
})
.WithName("GetZooAnimals")
.WithOpenApi();

app.MapGet("/ZooPrices", () =>
{
  return GetPrices(new FileReader(@".\Data\animals.csv", @".\Data\prices.txt", @".\Data\zoo.xml"));
})
.WithName("GetPrices")
.WithOpenApi();

app.Run();
