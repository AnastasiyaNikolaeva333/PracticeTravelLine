public class SteeringWheel
{
    public static List<ISteeringWheel> GetAll()
    {
        return new List<ISteeringWheel>
        {
            new LeftSteeringWheel(),
            new RightSteeringWheel()
        };
    }
}