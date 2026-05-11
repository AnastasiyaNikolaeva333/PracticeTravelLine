public class Game
{
    public static void Run()
    {
        List<IFighter> allFighters = new List<IFighter>();
        bool flagEndGAme = false;
        while ( !flagEndGAme )
        {
            string comand = ConsoleMenu.ReadCommand(
                "Выберите команду:",
                new List<(char Key, string Command, string Description)>()
                {
                    ( '1', "add-fighter", "Добавить игрока" ),
                    ( '2', "play", "Начать бой" ),
                    ( '3', "show", "Вывести всех игроков" ),
                    ( '4', "end", "Выйти" )
                } );
            switch ( comand )
            {
                case "add-fighter": { allFighters.Add( Character.CreateFighter() ); break; }
                case "play": { Play( allFighters ); break; }
                case "show": { Show( allFighters ); break; }
                case "end":
                    {
                        flagEndGAme = true;
                        Console.WriteLine( "Игра окончена. До новой встречи!" );
                        break;
                    }
                default: { Console.WriteLine( "Неизвестная команда." ); break; }
            }
        }
    }

    private static void Show( List<IFighter> allFighters )
    {
        if ( allFighters.Count < 1 )
        {
            Console.WriteLine( "Бойцы отсутствуют" );
            return;
        }
        for ( int i = 0; i < allFighters.Count; i++ )
        {
            Console.WriteLine( $"{i + 1}. {allFighters[ i ].GetAllInformation()}" );
        }
    }

    private static void Play( List<IFighter> allFighters )
    {
        if ( allFighters.Count < 2 || allFighters.Count % 2 != 0 )
        {
            Console.WriteLine( $"Игра невозможна. Персонажей должно быть больше 2 и " +
                $"чётное количество. Сейчас их {allFighters.Count()}" );
            return;
        }
        string nameWinner = GameManager.StartBattles( allFighters );
        Console.WriteLine( $"{nameWinner} ОДЕРЖАЛ ПОБЕДУ!!!" );
        foreach ( IFighter fighter in allFighters )
        {
            fighter.RestoreHealth();
        }
    }
}
