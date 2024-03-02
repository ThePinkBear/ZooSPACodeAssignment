var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

double GetPrices()
{
  return ConsumptionCalculator.Calculate();
}

app.UseHttpsRedirection();

app.MapGet("/ZooPrices", () =>
{
  return GetPrices();
})
.WithName("GetPrices")
.WithOpenApi();

app.Run();
