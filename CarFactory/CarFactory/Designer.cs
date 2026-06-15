public class Designer
{
    public static ICar BuildYourOwn()
    {
        var builder = new CarBuilder();
        return builder
            .ChooseCarBodyShape()
            .ChooseGearboxe()
            .ChooseColor()
            .ChooseEngine()
            .Build();
    }
}