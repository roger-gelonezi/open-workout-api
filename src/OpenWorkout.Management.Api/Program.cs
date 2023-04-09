using RogerioGelonezi.WebApi.Sdk.IoC;
using OpenWorkout.Services.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services
    .MainStartup(builder.Configuration);

builder.Services
    .AddDatabases(builder.Configuration)
    .AddInterfaces();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();

app.Run();
