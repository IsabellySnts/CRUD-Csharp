using ApiWeb.DataContext;
using ApiWeb.Services.FuncionarioServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner.

builder.Services.AddControllers();
// Saiba mais sobre como configurar Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IFuncionarioInterface, FuncionarioServices>();
builder.Services.AddDbContext<AplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var CorsPolicy = "_PermitirOrigemEspecifica";


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CorsPolicy,
        policy =>
        {
            policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

var app = builder.Build();
app.UseCors(CorsPolicy);
// Configurar o pipeline de solicitação HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();





app.UseAuthorization();

app.MapControllers();

app.Run();
