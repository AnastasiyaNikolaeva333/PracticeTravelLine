public class Colors
{
    public static List<IColor> GetAll()
    {
        return new List<IColor>
        {
            new Black(),
            new Blue(),
            new White()
        };
    }
}