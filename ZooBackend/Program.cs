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
var reader = new FileReader(@"./Data/animals.csv", @"./Data/prices.txt", @"./Data/zoo.xml");

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseCors("AllowZooFrontend");

app.MapGet("/ZooAnimals", () 
  =>  new AnimalHandler(reader).GetAnimalDataTransferObjects());
app.MapGet("/ZooTotalCost", () 
  => new AnimalHandler(reader).CalculateTotalCost());
app.MapGet("/ZooMeatCost", () 
  => new AnimalHandler(reader).CalculateMeatCost());
app.MapGet("/ZooFruitCost", () 
  => new AnimalHandler(reader).CalculateFruitCost());

app.Run();
