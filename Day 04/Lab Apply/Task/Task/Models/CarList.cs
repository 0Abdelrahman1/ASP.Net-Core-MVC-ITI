namespace Task.Models
{
    public static class CarList
    {
        public static List<Car> cars = new() {
            new() { Num = 1, Color = "Red", Model = "Model S", Manufacturer = "Tesla" },
            new() { Num = 2, Color = "Blue", Model = "Mustang", Manufacturer = "Ford" },
            new() { Num = 3, Color = "Black", Model = "Civic", Manufacturer = "Honda" },
            new() { Num = 4, Color = "White", Model = "Corolla", Manufacturer = "Toyota" }
        };
    }
}
