using Microsoft.EntityFrameworkCore;
using VeterinariaASPWebApi.Models;
using VeterinariaASPWebApi.Services;
using VeterinariaASPWebApi.ServicesImpl;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//inyeccion del contexto
builder.Services.AddDbContext<VeterinariaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("VeterinariaConnection")));

//scopes de veterinaria

builder.Services.AddScoped<IMascotaService, MascotaServiceImpl>();
builder.Services.AddScoped<IUsuarioService, UsuarioServiceImpl>();
builder.Services.AddScoped<IColaboradorService, ColaboradorServiceImpl>();
builder.Services.AddAutoMapper(typeof(IStartup));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
