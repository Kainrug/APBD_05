using Api_APBD05.APBD_05.APBD_5;
using Api_APBD05.APBD_05.APBD_5.classes;
using Api_APBD05.APBD_05.APBD_5.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSingleton<IMockDbAnimal, MockDbAnimals>();
builder.Services.AddSingleton<IMockDbVisit, MockDbVisit>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/animals", (IMockDbAnimal mockDbAnimal) =>
{
    return Results.Ok(mockDbAnimal.GetAll());
});

app.MapGet("/animals/{id:int}", (IMockDbAnimal mockDbAnimal, int id) =>
{
    var animal = mockDbAnimal.GetById(id);
    if (animal is null) return Results.NotFound("");

    return Results.Ok(animal);
});

app.MapPost("/animals", (IMockDbAnimal mockDbAnimal, AnimalInfo animalInfo) =>
{
     mockDbAnimal.Add(animalInfo);
     return Results.Created();
});

app.MapPut("/animals", (IMockDbAnimal mockDbAnimal, int id, AnimalInfo animalInfo) =>
{
    if (mockDbAnimal.GetById(id) is null) return Results.NotFound();
    
    mockDbAnimal.Edit(id, animalInfo);
    return Results.NoContent();
});

app.MapDelete("/animals", (IMockDbAnimal mockDbAnimal, int id) =>
{
    var animalToRemove = mockDbAnimal.GetById(id);
    if (animalToRemove is null) return Results.NotFound();

     mockDbAnimal.Delete(id);
     return Results.NoContent();

});
    



app.MapGet("/visits/{id:int}", (IMockDbVisit mockDbVisit, int id) =>
{
    var animal = MockDbVisit._mockDbAnimal.GetById(id);
    var visits = mockDbVisit.GetByAnimal(animal!);
    if (visits.Count == 0)
    {
        return Results.NotFound();
    }

    return Results.Ok(visits);
});

app.MapPost("/visits", (IMockDbVisit mockDbVisit, Visit visit)=> {
    mockDbVisit.Add(visit);
    return Results.Created();
});


app.MapControllers();
app.Run();

