public class Response
{
    public static ICarBodyShape ChooseCarBodyShape()
    {
        return ConsoleMenu.Select(
            "Выберите тип кузова из списка ниже:",
            CarBodyShapes.GetAll(),
            carBodyShape => carBodyShape.Name );
    }

    public static IColor ChooseColor()
    {
        return ConsoleMenu.Select(
            "Выберите цвет из списка ниже:",
            Colors.GetAll(),
            color => color.Name );
    }

    public static IEngine ChooseEngine()
    {
        return ConsoleMenu.Select(
            "Выберите двигатель из списка ниже:",
            Engines.GetAll(),
            engine => engine.Name );
    }

    public static IGearbox ChooseGearboxe()
    {
        return ConsoleMenu.Select(
            "Выберите коробку передач из списка ниже:",
            Gearbox.GetAll(),
            gearbox => gearbox.Name );
    }

    public static ISteeringWheel ChooseSteeringWheel()
    {
        return ConsoleMenu.Select(
            "Выберите готовый автомобиль из списка:",
            SteeringWheel.GetAll(),
            car => car.ToString() );
    }
    public static ICar ChoosePrebuiltCars()
    {
        return ConsoleMenu.Select(
            "Выберите готовый автомобиль из списка:",
            Designer.CreateCar(),
            car => car.ToString() + "\n" );
    }
}