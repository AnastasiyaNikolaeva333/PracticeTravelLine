public class Program
{
    public static void Main( string[] args )
    {
        var input = new ConsoleInputProvider();
        var output = new ConsoleOutputProvider();
        var random = new RandomProvider();
        var menu = new ConsoleMenu( input, output );
        var repository = ComponentRepository.AllObjects;
        var factory = new ComponentFactory( input, output, repository, menu );
        var gameManager = new GameManager( output, random );
        var damageFighter = new DamageFighter( output );
        var gameModes = new GameModes( output, factory, gameManager, damageFighter );
        var game = new Game( menu, gameModes, output );

        output.Print( "Консольна игра \"Боец\"" );
        output.Print( "Краткая инструкция:\n" +
            "- Первым делом необходимо добавить персонажей, которые будут играть\n" +
            "- Далее будут происходить сражения\n" +
            "- Последний оставщийся боец является победителем" );
        game.Run();
    }
}