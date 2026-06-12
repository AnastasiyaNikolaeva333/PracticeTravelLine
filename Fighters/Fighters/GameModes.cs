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
            Console.WriteLine( "Бойцы отсутствуют" );
            return;
        }
        for ( int i = 0; i < allFighters.Count; i++ )
        {
            Console.WriteLine( $"{i + 1}. {allFighters[ i ].GetAllInformation()}" );
        }
    }
    public static void Play( List<IFighter> allFighters )
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
    public static void EndGame( ref bool flagEndGame )
    {
        flagEndGame = true;
        Console.WriteLine( "Игра окончена. До новой встречи!" );
    }
}