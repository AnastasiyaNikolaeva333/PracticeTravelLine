public class CarBodyShapes
{
    public static List<ICarBodyShape> GetAll()
    {
        return new List<ICarBodyShape>
        {
            new Hatchback(),
            new Sedan(),
            new Сoupe()
        };
    }
}