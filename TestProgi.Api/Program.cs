using TestProgi.Api.Services;
using TestProgi.Api.Services.Strategy;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200") // Reemplaza con la URL de tu front-end local
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddScoped<ICostCalculationStrategy, BasicUserFeeStrategy>();
builder.Services.AddScoped<ICostCalculationStrategy, SellerSpecialFeeStrategy>();
builder.Services.AddScoped<ICostCalculationStrategy, AssociationCostsStrategy>();
builder.Services.AddScoped<ICostCalculatorService, CostCalculatorService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();
app.UseCors("AllowLocalhost");
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test Progi"));

app.Run();
