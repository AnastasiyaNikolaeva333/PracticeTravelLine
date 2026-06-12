public class Game
{
    public static void Run()
    {
        List<IFighter> allFighters = new List<IFighter>();
        bool flagEndGame = false;
        while ( !flagEndGame )
        {
            string comand = ConsoleMenu.ReadCommand(
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
                case "add-fighter": { GameModes.AddFighter( allFighters ); break; }
                case "play": { GameModes.Play( allFighters ); break; }
                case "show": { GameModes.Show( allFighters ); break; }
                case "end": { GameModes.EndGame( ref flagEndGame ); break; }
                default: { Console.WriteLine( "Неизвестная команда." ); break; }
            }
        }
    }
}
