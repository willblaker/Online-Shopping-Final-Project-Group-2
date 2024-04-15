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
    user.Username = user.Username;
    user.Email = user.Email;
    user.PasswordHash = user.PasswordHash;
    user.FirstName = user.FirstName;
    user.LastName = user.LastName;
    user.Address = user.Address;
    user.City = user.City;
    user.State = user.City;
    user.PostalCode = user.PostalCode;

    await dbContext.SaveChangesAsync();
    return Results.Ok(userViewModel);
});



app.Run();
