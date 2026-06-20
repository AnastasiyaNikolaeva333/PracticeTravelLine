public class Designer
{
    public static List<ICar> CreateCar()
    {
        return new List<ICar>()
        {
            new Car(new Sedan(), new Black(), new PetrolEngine(), new Automatic(), new LeftSteeringWheel()),
            new Car(new Hatchback(), new White(), new DieselEngine(), new Mechanics(), new RightSteeringWheel()),
            new Car(new Hatchback(), new Blue(), new ElectricEngine(), new Reducer(), new LeftSteeringWheel())
        };
    }
    public static ICar BuildManually()
    {
        var builder = new CarBuilder();
        return builder
            .ChooseCarBodyShape()
            .ChooseEngine()
            .ChooseGearboxe()
            .ChooseColor()
            .ChooseSteeringWheel()
            .Build();
    }
}