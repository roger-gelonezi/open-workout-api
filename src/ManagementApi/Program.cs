using ManagementApi.Filters;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Services.IoC;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Open Workout - Management API", Version = "v1" });
    c.OperationFilter<ApiResponsesOperationFilter>();
    c.DocumentFilter<TagDescriptionsDocumentFilter>();

    //Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddControllersWithViews()
                    .AddNewtonsoftJson(options =>
                        options.SerializerSettings.Converters.Add(new StringEnumConverter()));

builder.Services.AddSwaggerGenNewtonsoftSupport();
builder.Services.AddMvc(options =>
{
    options.Filters.Add(typeof(ErrorResponseFilter));
});

builder.Services.AddDatabases(builder.Configuration);
builder.Services.AddServices();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
