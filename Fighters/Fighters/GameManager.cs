public class GameManager
{
    public static string StartBattles( List<IFighter> allFighters )
    {
        int numRound = 1;
        while ( allFighters.All( f => f.IsAlive() ) )
        {
            ConsoleLogger.Print( $"\n{numRound++} РАУНД" );
            DefineInitiative( allFighters );
            ProcessRounds( allFighters );
        }
        return allFighters[ 0 ].Name;
    }
    private static void DefineInitiative( List<IFighter> allFighters )
    {
        SetInitiativeFighters( allFighters );
        allFighters.Sort( ( x, y ) => x.Initiative.CompareTo( y.Initiative ) );
    }
    private static void SetInitiativeFighters( List<IFighter> allFighters )
    {
        int countFighter = allFighters.Count;
        HashSet<int> uniqueInitiatives = new HashSet<int>();
        int initiative = Random.Shared.Next( 1, countFighter * 10 );
        for ( int i = 0; i < countFighter; i++ )
        {
            while ( uniqueInitiatives.Contains( initiative ) )
            {
                initiative = Random.Shared.Next( 1, countFighter * 10 );
            }
            uniqueInitiatives.Add( initiative );
            allFighters[ i ].Initiative = initiative;
        }
    }
    private static void ProcessRounds( List<IFighter> allFighters )
    {
        int countFighter = allFighters.Count;
        for ( int i = 0; i < countFighter / 2; i++ )
        {
            IFighter firstFighter = allFighters[ i ];
            IFighter secondFighter = allFighters[ countFighter - i - 1 ];
            ProcessRound( firstFighter, secondFighter );
            if ( !firstFighter.IsAlive() )
            {
                ConsoleLogger.Print( $"{firstFighter.Name} погибает" );
            }
            if ( !secondFighter.IsAlive() )
            {
                ConsoleLogger.Print( $"{secondFighter.Name} погибает" );
            }
        }
    }
    private static void ProcessRound( IFighter attackerFighter, IFighter receivingFighter )
    {
        double damageRatio = 1.0 - Random.Shared.Next( -20, 50 ) / 100.0;

        int damageOfFirst = receivingFighter.TakeDamage( attackerFighter, damageRatio );
        int damageOfSecond = attackerFighter.TakeDamage( receivingFighter, damageRatio );

        string nameAttacker = attackerFighter.Name;
        string nameReceiving = receivingFighter.Name;
        ConsoleLogger.Print( $"{nameAttacker} наносит {damageOfFirst} урона, получает {damageOfSecond}" );
        ConsoleLogger.Print( $"{nameReceiving} наносит {damageOfSecond} урона, получает {damageOfFirst}" );
    }
}