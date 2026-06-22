public interface IInputProvider
{
    string ReadLine();
}
public interface IOutputProvider
{
    void Print( string message );
}
public class ConsoleInputProvider : IInputProvider
{
    public string ReadLine() => Console.ReadLine();
}
public class ConsoleOutputProvider : IOutputProvider
{
    public void Print( string message ) => ConsoleLogger.Print( message );
}
public interface IRandomProvider
{
    int Next( int minValue, int maxValue );
}
public class RandomProvider : IRandomProvider
{
    public int Next( int minValue, int maxValue ) => Random.Shared.Next( minValue, maxValue );
}