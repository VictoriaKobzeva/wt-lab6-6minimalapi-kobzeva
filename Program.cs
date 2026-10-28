using wt_lab6_6minimalapi_kobzeva.Models;
using wt_lab6_6minimalapi_kobzeva.Data;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// --- Блок 1: Базовые эндпоинты ---
app.MapGet("/", () => "Minimal API работает!");

app.MapGet("/api/info", () =>
{
    return new
    {
        Application = "Web Technologies",
        Technology = "ASP.NET Core Minimal API",
        Version = "1.0"
    };
});

// --- Блок 3: GET запросы ---
app.MapGet("/api/properties", (string? search) =>
{
    var properties = PropertyStore.Properties.AsEnumerable();

    if (!string.IsNullOrWhiteSpace(search))
    {
        properties = properties.Where(x =>
            x.Address.Contains(search, StringComparison.OrdinalIgnoreCase) ||
            x.Type.Contains(search, StringComparison.OrdinalIgnoreCase));
    }

    return Results.Ok(properties);
});

app.MapGet("/api/properties/{id}", (int id) =>
{
    var property = PropertyStore.Properties.FirstOrDefault(x => x.Id == id);
    
    if (property == null)
        return Results.NotFound();

    return Results.Ok(property);
});
// --- Блок 4: POST запрос (создание) ---
app.MapPost("/api/properties", (Property property) =>
{
    // Автогенерация ID
    var newId = PropertyStore.Properties.Count == 0
        ? 1
        : PropertyStore.Properties.Max(x => x.Id) + 1;

    property.Id = newId;
    PropertyStore.Properties.Add(property);

    // Возвращаем 201 Created + ссылку на созданный объект
    return Results.Created($"/api/properties/{property.Id}", property);
});
// --- Блок 5: PUT запрос (изменение) ---
app.MapPut("/api/properties/{id}", (int id, Property updatedProperty) =>
{
    var property = PropertyStore.Properties.FirstOrDefault(x => x.Id == id);
    if (property == null)
        return Results.NotFound();

    property.Address = updatedProperty.Address;
    property.Type = updatedProperty.Type;
    property.Price = updatedProperty.Price;
    property.Area = updatedProperty.Area;
    property.Rooms = updatedProperty.Rooms;
    property.IsAvailable = updatedProperty.IsAvailable;

    return Results.Ok(property); // 200 OK
});

// --- Блок 5: DELETE запрос (удаление) ---
app.MapDelete("/api/properties/{id}", (int id) =>
{
    var property = PropertyStore.Properties.FirstOrDefault(x => x.Id == id);
    if (property == null)
        return Results.NotFound();

    PropertyStore.Properties.Remove(property);
    return Results.NoContent(); // 204 No Content
});
app.Run();