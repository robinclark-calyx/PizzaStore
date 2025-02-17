using Microsoft.EntityFrameworkCore;
using PizzaStore.Data;
using PizzaStore.Models;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Pizzas") ?? "Data Source=Pizzas.db";

builder.WebHost.UseUrls("http://localhost:5032");

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddSqlite<PizzaDb>(connectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapGet("/", () => "Hello World!");
app.MapGet("/pizzas", async (PizzaDb db) => await db.Pizzas.ToListAsync());
app.MapGet("/pizza/{id:int}", async (PizzaDb db, int id) => await db.Pizzas.FindAsync(id));
app.MapPost("/pizza", async (PizzaDb db, Pizza pizza) =>
{
    await db.Pizzas.AddAsync(pizza);
    await db.SaveChangesAsync();
    return Results.Created($"/pizza/{pizza.Id}", pizza);
});
app.MapPut("/pizza/{id:int}", async (PizzaDb db, Pizza updatedPizza, int id) =>
{
    var pizza = await db.Pizzas.FindAsync(id);
    if (pizza == null)
    {
        return Results.NotFound();
    }
    pizza.Name = updatedPizza.Name;
    pizza.Description = updatedPizza.Description;
    await db.SaveChangesAsync();
    return Results.NoContent();
});
app.MapDelete("/pizza/{id:int}", async (PizzaDb db, int id) =>
{
    var pizza = await db.Pizzas.FindAsync(id);
    if (pizza == null)
    {
        return Results.NotFound();
    }
    db.Pizzas.Remove(pizza);
    await db.SaveChangesAsync();
    return Results.Ok();
});

app.Run();