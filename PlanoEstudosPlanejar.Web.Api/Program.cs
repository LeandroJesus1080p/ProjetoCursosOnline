using Microsoft.EntityFrameworkCore;
using PlanoEstudosPlanejar.Web.Api.Models.Entities;
using PlanoEstudosPlanejar.Web.Api.Services.ArquivoServices;
using PlanoEstudosPlanejar.Web.Api.Services.MateriaServices;
using PlanoEstudosPlanejar.Web.Api.Services.PlanoEstudoServices;
using PlanoEstudosPlanejar.Web.Api.Services.Repository;
using PlanoEstudosPlanejar.Web.Api.Services.UsuarioServices;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// registra o banco de dados
builder.Services.AddDbContextPool<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b
        .MigrationsAssembly("PlanoEstudosPlanejar.Web.Api")
        .MigrationsHistoryTable("PlanoEstudoss"));

});



builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddScoped<IArquivoService, ArquivoService>();
builder.Services.AddScoped<IPlanoEstudoService, PlanoEstudoService>();
builder.Services.AddScoped<IMateriaService, MateriaService>();

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
