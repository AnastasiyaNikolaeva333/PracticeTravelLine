public class Gearboxes
{
    public static List<IGearboxe> GetAll()
    {
        return new List<IGearboxe>
        {
            new Automatic(),
            new Mechanics(),
            new Robot(),
        };
    }
}