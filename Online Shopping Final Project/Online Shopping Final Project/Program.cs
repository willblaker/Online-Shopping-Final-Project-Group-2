using Microsoft.EntityFrameworkCore;
using Microsoft.FluentUI.AspNetCore.Components;
using OnlineShopping.Client.Pages;
using OnlineShopping.Components;
using OnlineShopping.Data;
using OnlineShopping.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ShoppingContext>(optionsBuilder =>
{
    optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("ShoppingDB"));
});
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddFluentUIComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);

app.Run();
