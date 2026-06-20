public class GameModes
{
    public static void AddFighter( List<IFighter> allFighters )
    {
        var builder = new CharacterBuilder();
        IFighter character = builder
            .AddName()
            .ChangeRace()
            .ChangeRole()
            .ChangeWeapon()
            .ChangeArmor()
            .Build();
        allFighters.Add( character );
    }
    public static void Show( List<IFighter> allFighters )
    {
        if ( allFighters.Count < 1 )
        {
            ConsoleLogger.Print( "Бойцы отсутствуют" );
            return;
        }
        for ( int i = 0; i < allFighters.Count; i++ )
        {
            ConsoleLogger.Print( $"{i + 1}. {allFighters[ i ].GetAllInformation()}" );
        }
    }
    public static void Play( List<IFighter> allFighters )
    {
        if ( allFighters.Count < 2 || allFighters.Count % 2 != 0 )
        {
            ConsoleLogger.Print( $"Игра невозможна. Персонажей должно быть больше 2 и " +
                $"чётное количество. Сейчас их {allFighters.Count()}" );
            return;
        }
        string nameWinner = GameManager.StartBattles( allFighters );
        ConsoleLogger.Print( $"\n{nameWinner} ОДЕРЖАЛ ПОБЕДУ!!!\n" );
        foreach ( IFighter fighter in allFighters )
        {
            fighter.RestoreHealth();
        }
    }
    public static void EndGame( ref bool flagEndGame )
    {
        flagEndGame = true;
        ConsoleLogger.Print( "Игра окончена. До новой встречи!" );
    }
}