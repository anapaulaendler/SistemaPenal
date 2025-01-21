using PenalSystem.Infra.CrossCutting.IoC;

var builder = WebApplication.CreateBuilder(args);

DependencyInjectionBootstrap.Register(builder.Services, builder.Configuration);

builder.Services.AddOpenApi();
builder.Services.AddAuthorization();
builder.Services.AddMemoryCache();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();