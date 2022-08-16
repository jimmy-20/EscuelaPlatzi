using Curso_de_ASP.NET.Context;
using Curso_de_ASP.NET.Models;
using Curso_de_ASP.NET.Services;
using Curso_de_ASP.Services;
using  Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<EscuelaContext>(options =>
//{
  //  options.UseInMemoryDatabase("Escuela");
//});
builder.Services.AddSqlServer<EscuelaContext>(builder.Configuration.GetConnectionString("EscuelaDb"));

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IEscuelaServices,EscuelaServices>();
builder.Services.AddScoped<Crud<Curso>,CursoServices>();
builder.Services.AddScoped<Crud<Asignatura>,AsignaturaServices>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Escuela}/{action=Index}/{id?}");

app.Run();
