using static EndPointLogic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowZooFrontend", builder =>
  {
    builder.WithOrigins("http://localhost:5173")
           .AllowAnyMethod()
           .AllowAnyHeader();
  });
});
var paths = new string[] { @"./Data/animals.csv", @"./Data/prices.txt", @"./Data/zoo.xml" };
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowZooFrontend");

app.MapGet("/ZooAnimals", () =>
{
  return GetZooAnimals(new FileReader(paths[0], paths[1], paths[2]));
});

app.MapGet("/ZooTotalCost", () =>
{
  return GetPrices(new FileReader(paths[0], paths[1], paths[2]));
});

app.MapGet("/ZooMeatCost", () =>
{
  return GetMeatCost(new FileReader(paths[0], paths[1], paths[2]));
});

app.MapGet("/ZooFruitCost", () =>
{
  return GetFruitCost(new FileReader(paths[0], paths[1], paths[2]));
});

app.Run();
