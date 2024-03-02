var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

void GetPrices()
{
  // FileReader.ReadAnimals(@".\Data\animals.csv");
  FileReader.ReadPrices(@".\Data\prices.txt");
}

app.UseHttpsRedirection();

app.MapGet("/ZooPrices", () =>
{
  GetPrices();
  return "Hello World!";
})
.WithName("GetPrices")
.WithOpenApi();

app.Run();
