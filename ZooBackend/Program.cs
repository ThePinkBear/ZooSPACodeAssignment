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
IFileReader reader = new FileReader(@"./Data/animals.csv", @"./Data/prices.txt", @"./Data/zoo.xml");
IAnimalHandler handler = new AnimalHandler(reader);

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseCors("AllowZooFrontend");

app.MapGet("/ZooAnimals", () 
  =>  handler.GetAnimalDataTransferObjects());
app.MapGet("/ZooTotalCost", () 
  => handler.CalculateTotalCost());
app.MapGet("/ZooMeatCost", () 
  => handler.CalculateMeatCost());
app.MapGet("/ZooFruitCost", () 
  => handler.CalculateFruitCost());

app.Run();
