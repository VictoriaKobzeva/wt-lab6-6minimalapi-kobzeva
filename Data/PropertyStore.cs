using wt_lab6_6minimalapi_kobzeva.Models;

namespace wt_lab6_6minimalapi_kobzeva.Data;

public static class PropertyStore
{
    public static List<Property> Properties { get; } = new()
    {
        new Property { Id = 1, Address = "Тридевятое царство, замок принцессы", Type = "Замок", Price = 999999m, Area = 500, Rooms = 20, IsAvailable = true },
        new Property { Id = 2, Address = "Тёмный лес, избушка на курьих ножках", Type = "Избушка", Price = 666000m, Area = 13, Rooms = 1, IsAvailable = true },
        new Property { Id = 3, Address = "Подводное царство, дворец Нептуна", Type = "Дворец", Price = 5000000m, Area = 1200, Rooms = 50, IsAvailable = false },
        new Property { Id = 4, Address = "Минск, ул. Ленина, 15, кв. 42", Type = "Квартира", Price = 120000m, Area = 65.5, Rooms = 3, IsAvailable = true },
        new Property { Id = 5, Address = "Минск, пр. Независимости, 100", Type = "Офис", Price = 250000m, Area = 120, Rooms = 5, IsAvailable = true },
        new Property { Id = 6, Address = "Космос, лунная база Илона Маска", Type = "Космический дом", Price = 1000000000m, Area = 250, Rooms = 5, IsAvailable = true }
    };
}