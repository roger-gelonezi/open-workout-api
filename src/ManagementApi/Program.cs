using ManagementApi.Extensions;
using Services.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services
    .AddSwagger(builder.Configuration)
    .AddAuthentication(builder.Configuration)
    .AddFilters()
    .AddNewtonsoftJson();

builder.Services
    .AddDatabases(builder.Configuration)
    .AddInterfaces();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
