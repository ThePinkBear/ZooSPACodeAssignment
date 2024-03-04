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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowZooFrontend");


app.MapGet("/ZooAnimals", () =>
{
  return GetZooAnimals(new FileReader(@"./Data/animals.csv", @"./Data/prices.txt", @"./Data/zoo.xml"));
})
.WithName("GetZooAnimals")
.WithOpenApi();

app.MapGet("/ZooPrices", () =>
{
  return GetPrices(new FileReader(@"./Data/animals.csv", @"./Data/prices.txt", @"./Data/zoo.xml"));
})
.WithName("GetPrices")
.WithOpenApi();


app.Run();
