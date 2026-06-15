public class Response
{
    public static ICarBodyShape ChooseCarBodyShape()
    {
        List<ICarBodyShape> carBodieShapes = new List<ICarBodyShape>()
        {
            new Hatchback(),
            new Sedan(),
            new Сoupe()
        };
        return ConsoleMenu.Select(
            "Выберите тип кузова из списка ниже:",
            carBodieShapes,
            carBodieShape => carBodieShape.Name);
    }
    public static IColor ChooseColor()
    {
        List<IColor> colors = new List<IColor>()
        {
            new Black(),
            new Blue(),
            new White(),
        };
        return ConsoleMenu.Select(
            "Выберите цвет из списка ниже:",
            colors,
            color => color.Name);
    }
    public static IEngine ChooseEngine()
    {
        List<IEngine> engines = new List<IEngine>()
        {
            new DieselEngine(),
            new ElectricEngine(),
            new PetrolEngine(),
        };
        return ConsoleMenu.Select(
            "Выберите двигатель из списка ниже:",
            engines,
            engine => engine.Name);
    }
    public static IGearboxe ChooseGearboxe()
    {
        List<IGearboxe> gearboxes = new List<IGearboxe>()
        {
            new Automatic(),
            new Mechanics(),
            new Robot(),
        };
        return ConsoleMenu.Select(
           "Выберите коробку передач из списка ниже:",
           gearboxes,
           gearboxe => gearboxe.Name);
    }
    public static ICar ChooseReadyMadeCar()
    {
        List<ICar> readyMadeCars = new List<ICar>()
        {
            new Car(new Sedan(), new Black(), new PetrolEngine(), new Automatic()),
            new Car(new Hatchback(), new White(), new DieselEngine(), new Mechanics()),
            new Car(new Hatchback(), new Blue(), new ElectricEngine(), new Robot())
        };

        return ConsoleMenu.Select(
            "Выберите готовый автомобиль из списка:",
            readyMadeCars,
            car => car.ToString() + "\n");
    }
}