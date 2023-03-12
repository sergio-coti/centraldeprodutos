using CentralDeProdutos.Services.Api.Setups;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//adicionando as configurações
AutoMapperSetup.Configure(builder);
CorsSetup.Configure(builder);
DependencyInjectionSetup.Configure(builder);
SwaggerSetup.Configure(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

CorsSetup.Use(app);

app.UseAuthorization();

app.MapControllers();

app.Run();
