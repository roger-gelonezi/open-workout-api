using AuthManagementApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services
    .AddSwagger()
    .AddDatabase(builder.Configuration)
    .AddIdentityJwt(builder.Configuration)
    .AddInterfaces()
    .AddFilters()
    .AddNewtonsoftJson();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
