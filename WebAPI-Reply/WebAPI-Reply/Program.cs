using Microsoft.EntityFrameworkCore;
using WebAPI_Reply.Data;
using WebAPI_Reply.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository<Projetos>, ProjetoRepository>();
builder.Services.AddScoped<IRepository<Tarefas>, TarefaRepository>();
builder.Services.AddScoped<IRepository<Usuarios>, UsuarioRepository>();
builder.Services.AddScoped<IRepository<Equipes>, EquipeRepository>();


builder.Services.AddDbContext<DataContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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
