var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var application = builder.Build();

application.UseSwagger();
application.UseSwaggerUI();

application.MapGet(
        pattern: "/weatherforecast",
        handler: () => "")
    .WithName("GetWeatherForecast")
    .WithOpenApi();

application.Run();