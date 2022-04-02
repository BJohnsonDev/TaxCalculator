using TaxCalculator.Api.Services;

// A simple web API to expose some of the functionality of TaxJar's API

var builder = WebApplication.CreateBuilder(args);

// secrets file not included for obvious reasons, create your own or add TaxJarApiKey to configuration via some other means
builder.Configuration.AddJsonFile("secrets.json", optional: true);

// Add services to the container.
builder.Services.AddHttpClient<ITaxJarApiClient, TaxJarApiClient>();
builder.Services.AddTransient<TaxJarCalculator>()
                .AddTransient<ITaxCalculator, TaxJarCalculator>(s => s.GetRequiredService<TaxJarCalculator>());
builder.Services.AddTransient<ITaxCalculatorFactory, TaxCalculatorFactory>();
builder.Services.AddTransient<ITaxService, TaxService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
