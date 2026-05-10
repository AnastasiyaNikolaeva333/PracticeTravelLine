public class Program
{
    public static void Main( string[] args )
    {
        Console.WriteLine( "Консольна игра \"Боец\"" );
        Console.WriteLine( "Краткая инструкция:\n" +
            "- Первым делом необходимо добавить персонажей, которые будут играть\n" +
            "- Далее будут происходить сражения\n" +
            "- Последний оставщийся боец является победителем" );
        Game.Run();
    }
}