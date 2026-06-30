using Microsoft.EntityFrameworkCore;
using TerminOn.Application.Infrastructur;
using TerminOn.Application.Services;
using TerminOn.Web.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppointmentContext>(options =>
    options.UseSqlite("Data Source=../terminon.db"));


builder.Services.AddScoped<PatientService>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

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


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppointmentContext>();
    db.Database.EnsureCreated();
}

app.Run();
