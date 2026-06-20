public class Gearbox
{
    public static List<IGearbox> GetAll()
    {
        return new List<IGearbox>
        {
            new Automatic(),
            new Mechanics(),
            new Robot(),
        };
    }
}