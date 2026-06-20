public class Engines
{
    public static List<IEngine> GetAll()
    {
        return new List<IEngine>
        {
            new DieselEngine(),
            new ElectricEngine(),
            new PetrolEngine()
        };
    }
}