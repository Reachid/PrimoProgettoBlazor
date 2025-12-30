using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.EntityFrameworkCore;
using PrimoProgettoBlazor.Components;
using PrimoProgettoBlazor.Components.Classi;
using PrimoProgettoBlazor.Servizi.Classi;
using PrimoProgettoBlazor.Servizi.Interfacce;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddRadzenComponents();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BancaDati>(x => x.UseSqlServer(connectionString), ServiceLifetime.Scoped);

builder.Services.AddScoped<IPersonaggioService,PersonaggioService>(); 
builder.Services.AddScoped<IAbilitàPersonaggioService,AbilitàPersonaggioService>(); 
builder.Services.AddScoped<IAbilitàService,AbilitàService>(); 
builder.Services.AddScoped<ISessioneService,SessioneService>(); 
builder.Services.AddScoped<IGiocatoreService,GiocatoreService>();
builder.Services.AddScoped<IPerkService,PerkService>();
builder.Services.AddScoped<ICategoriaKeywordService,CategoriaKeywordService>();
builder.Services.AddScoped<IKeywordService,KeywordService>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
