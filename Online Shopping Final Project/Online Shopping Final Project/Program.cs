using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.FluentUI.AspNetCore.Components;
using Online_Shopping_Final_Project.Client.Pages;
using Online_Shopping_Final_Project.Components;
using Online_Shopping_Final_Project.Data;
using Online_Shopping_Final_Project.Entities;
using OnlineShoppingViewModels;

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

builder.Services.AddSingleton<HttpClient>(new HttpClient { BaseAddress = new Uri("https://localhost:7126/") });

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

app.MapPut("/api/CartEntry/{id}", async ([FromRoute]int id, ShoppingContext dbContext) =>
{
    var cartEntries = await dbContext.CartEntries.Include(entry => entry.Item).ToListAsync();
    bool alreadyInCart = false;
    foreach (var cartEntry in cartEntries)
    {
        if(id == cartEntry.Item.ItemId)
        {
            alreadyInCart = true;
            cartEntry.Quantity++;
            break;
        }
    }

    if (!alreadyInCart)
    {
        var item = await dbContext.Items.FindAsync(id);
        var cartEntry = new CartEntry();
        cartEntry.Quantity = 1;
        cartEntry.Item = item;
        dbContext.CartEntries.Add(cartEntry);
    }
    dbContext.SaveChanges();
});

app.MapGet("/api/CartEntry/", async (ShoppingContext dbContext) =>
{
    var cartEntries = await dbContext.CartEntries.Include(entry => entry.Item).ToListAsync();
    // Converts cartEntries into viewModel objects
    var viewModels = cartEntries.Select(entry => new CartEntryViewModel() { CartEntryId = entry.CartEntryId, ItemName = entry.Item.ItemName, ItemPrice = entry.Item.ItemPrice, Quantity = entry.Quantity}).ToList();
    return Results.Json(viewModels);
});

app.Run();
