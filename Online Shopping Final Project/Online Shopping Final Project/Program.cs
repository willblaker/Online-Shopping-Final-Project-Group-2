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

app.MapGet("/api/Users", async (ShoppingContext dbContext) =>
{
    var users = await dbContext.Users.ToListAsync();

    List<UserViewModel> userViewModels = new();
    foreach(var user in users)
    {
        userViewModels.Add(new UserViewModel
        {
            UserId = user.UserId,
            Username = user.Username,
            Email = user.Email,
            PasswordHash = user.PasswordHash,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Address = user.Address,
            City = user.City,
            State = user.City,
            PostalCode = user.PostalCode
        });
    }
    return Results.Ok(userViewModels);
});

app.MapGet("/api/Users/{id}", async (ShoppingContext dbContext, int id) =>
{
    var user = await dbContext.Users.FindAsync(id);
    if (user == null)
    {
        return Results.NotFound();
    }

    UserViewModel userViewModel = new()
    {
        UserId = user.UserId,
        Username = user.Username,
        Email = user.Email,
        PasswordHash = user.PasswordHash,
        FirstName = user.FirstName,
        LastName = user.LastName,
        Address = user.Address,
        City = user.City,
        State = user.City,
        PostalCode = user.PostalCode
    };
    return Results.Ok(userViewModel);
});

app.MapPost("/api/Users", async (ShoppingContext dbContext, UserViewModel userViewModel) =>
{
    User user = new()
    {
        UserId = userViewModel.UserId,
        Username = userViewModel.Username,
        Email = userViewModel.Email,
        PasswordHash = userViewModel.PasswordHash,
        FirstName = userViewModel.FirstName,
        LastName = userViewModel.LastName,
        Address = userViewModel.Address,
        City = userViewModel.City,
        State = userViewModel.City,
        PostalCode = userViewModel.PostalCode
    };
    await dbContext.Users.AddAsync(user);
    await dbContext.SaveChangesAsync();
    return Results.Created($"/api/User/{user.UserId}", user);
});

app.MapPut("/api/Users/{id}", async (ShoppingContext dbContext, int id, UserViewModel userViewModel) =>
{
    var user = await dbContext.Users.FindAsync(id);
    if (user == null)
    {
        return Results.NotFound();
    }

    user.UserId = userViewModel.UserId;
    user.Username = userViewModel.Username;
    user.Email = userViewModel.Email;
    user.PasswordHash = userViewModel.PasswordHash;
    user.FirstName = userViewModel.FirstName;
    user.LastName = userViewModel.LastName;
    user.Address = userViewModel.Address;
    user.City = userViewModel.City;
    user.State = userViewModel.City;
    user.PostalCode = userViewModel.PostalCode;

    await dbContext.SaveChangesAsync();
    return Results.Ok(userViewModel);
});



app.MapPost("/api/CartEntry/{id}", async ([FromRoute]int id, ShoppingContext dbContext) =>
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

app.MapPut("/api/CartEntry/{id}", async ([FromRoute] int id, ShoppingContext dbContext, [FromBody] CartEntryViewModel cartEntryViewModel) =>
{
    var cartEntry = await dbContext.CartEntries.FindAsync(id);
    
    cartEntry.Quantity = cartEntryViewModel.Quantity;

    await dbContext.SaveChangesAsync();
    return Results.Ok(cartEntry);

});

app.MapGet("/api/CartEntry/", async (ShoppingContext dbContext) =>
{
    var cartEntries = await dbContext.CartEntries.Include(entry => entry.Item).ToListAsync();
    // Converts cartEntries into viewModel objects
    var viewModels = cartEntries.Select(entry => new CartEntryViewModel() { CartEntryId = entry.CartEntryId, ItemName = entry.Item.ItemName, ItemPrice = entry.Item.ItemPrice, Quantity = entry.Quantity}).ToList();
    return Results.Json(viewModels);
});

app.MapGet("/api/CartEntry/{id}", async (ShoppingContext dbContext, int id) =>
{
    var cartEntry = await dbContext.CartEntries.Include(entry => entry.Item).FirstOrDefaultAsync(entry => entry.CartEntryId == id);

    if (cartEntry == null)
    {
        return Results.NotFound();
    }

    var viewModel = new CartEntryViewModel() { CartEntryId = cartEntry.CartEntryId, ItemName = cartEntry.Item.ItemName, ItemPrice = cartEntry.Item.ItemPrice, Quantity = cartEntry.Quantity };

    return Results.Json(viewModel);

});

app.MapDelete("/api/CartEntry/{Id}", async (ShoppingContext dbContext, int id) =>
{
    var cartEntries = await dbContext.CartEntries.FindAsync(id);
    if (cartEntries == null)
    {
        return Results.NotFound();
    }

    dbContext.CartEntries.Remove(cartEntries);
    await dbContext.SaveChangesAsync();
    return Results.Ok();
});

app.MapPost("/api/Checkout/{Id}", async (ShoppingContext dbContext, int id) =>
{
    var cartEntries = await dbContext.CartEntries.Include(entry => entry.Item).ToListAsync();
    var order = new Order
    {
        OrderDate = DateTime.Now,
        UserId = id,
        TotalPrice = cartEntries.Sum(ce => ce.Item.ItemPrice * ce.Quantity),
        OrderDetails = new List<OrderDetail>()
    };

    foreach(var entry in cartEntries)
    {
        order.OrderDetails.Add(new OrderDetail
        {
            ItemId = entry.Item.ItemId,
            Quantity = entry.Quantity,
            Price = entry.Item.ItemPrice
        });
    }

    dbContext.OrderHistory.Add(order);
    await dbContext.SaveChangesAsync();
    return Results.Ok();
});

app.Run();
