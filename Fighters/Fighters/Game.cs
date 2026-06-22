public class Game
{
    private readonly ConsoleMenu _menu;
    private readonly GameModes _gameModes;
    private readonly IOutputProvider _output;
    public Game( ConsoleMenu menu, GameModes gameModes, IOutputProvider output )
    {
        _menu = menu;
        _gameModes = gameModes;
        _output = output;
    }
    public void Run()
    {
        List<IFighter> allFighters = new List<IFighter>();
        bool flagEndGame = false;
        while ( !flagEndGame )
        {
            string comand = _menu.ReadCommand(
                "Выберите команду:",
                new List<MenuCommand>()
                {
                    new MenuCommand { Key = '1', Command = "add-fighter", Description = "Добавить игрока" },
                    new MenuCommand { Key = '2', Command = "play", Description = "Начать бой" },
                    new MenuCommand { Key = '3', Command = "show", Description = "Вывести всех игроков" },
                    new MenuCommand { Key = '4', Command = "end", Description = "Выйти" }
                } );
            switch ( comand )
            {
                case "add-fighter": { _gameModes.AddFighter( allFighters ); break; }
                case "play": { _gameModes.Play( allFighters ); break; }
                case "show": { _gameModes.Show( allFighters ); break; }
                case "end": { _gameModes.EndGame( ref flagEndGame ); break; }
                default: { _output.Print( "Неизвестная команда." ); break; }
            }
        }
    }
}