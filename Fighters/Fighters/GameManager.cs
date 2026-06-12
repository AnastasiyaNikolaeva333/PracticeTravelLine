public class GameManager
{
    public static string StartBattles( List<IFighter> allFighters )
    {
        int numRound = 1;
        while ( allFighters.Count > 1 )
        {
            Console.WriteLine( $"{numRound} РАУНД" );
            allFighters = DefineInitiative( allFighters );
            ProcessRounds( allFighters );
            ++numRound;
            allFighters = allFighters.Where( f => f.IsAlive() ).ToList();
        }
        return allFighters[ 0 ].Name;
    }
    private static void ProcessRounds( List<IFighter> allFighters )
    {
        int countFighter = allFighters.Count;
        for ( int i = 0; i < countFighter / 2; i++ )
        {
            int firstFighter = i;
            int secondFighter = countFighter - i - 1;
            ProcessRound( allFighters, firstFighter, secondFighter );
            if ( !allFighters[ firstFighter ].IsAlive() )
            {
                Console.WriteLine( $"{allFighters[ firstFighter ].Name} погибает" );
            }
            if ( !allFighters[ secondFighter ].IsAlive() )
            {
                Console.WriteLine( $"{allFighters[ secondFighter ].Name} погибает" );
            }
        }
    }
    private static List<IFighter> DefineInitiative( List<IFighter> allFighters )
    {
        SortedList<int, int> allInitiatives = GetInitiativeFighters( allFighters );
        return GetSortedFighters( allFighters, allInitiatives );
    }
    private static SortedList<int, int> GetInitiativeFighters( List<IFighter> allFighters )
    {
        int countFighter = allFighters.Count;
        var sortedFighters = new SortedList<int, int>();
        HashSet<int> uniqueInitiatives = new HashSet<int>();
        int initiative = Random.Shared.Next( 1, countFighter * 10 );
        for ( int i = 0; i < countFighter; i++ )
        {
            while ( uniqueInitiatives.Contains( initiative ) )
            {
                initiative = Random.Shared.Next( 1, countFighter * 10 );
            }
            uniqueInitiatives.Add( initiative );
            sortedFighters.Add( initiative, i );
        }
        return sortedFighters;
    }
    private static List<IFighter> GetSortedFighters( List<IFighter> allFighters, SortedList<int, int> allInitiatives )
    {
        List<IFighter> sortedFighters = new List<IFighter>();
        foreach ( var i in allInitiatives )
        {
            sortedFighters.Add( allFighters[ i.Value ] );
        }
        return sortedFighters;
    }
    private static void ProcessRound( List<IFighter> allFighters, int indexFirstFighter, int indexSecondFighter )
    {
        double damageRatio = 1.0 - Random.Shared.Next( -20, 50 ) / 100.0;
        string nameFirstFighter = allFighters[ indexFirstFighter ].Name;
        string nameSecondFighter = allFighters[ indexSecondFighter ].Name;

        int maxDamageOfFirst = DetermineMaxDamage( damageRatio, allFighters, indexFirstFighter, indexSecondFighter );
        allFighters[ indexSecondFighter ].TakeDamage( maxDamageOfFirst );

        int maxDamageOfSecond = DetermineMaxDamage( damageRatio, allFighters, indexSecondFighter, indexFirstFighter );
        allFighters[ indexFirstFighter ].TakeDamage( maxDamageOfSecond );

        Console.WriteLine( $"{nameFirstFighter} наносит {maxDamageOfFirst} урона, получает {maxDamageOfSecond}" );
        Console.WriteLine( $"{nameSecondFighter} наносит {maxDamageOfSecond} урона, получает {maxDamageOfFirst}" );
    }

    private static int DetermineMaxDamage( double damageRatio, List<IFighter> allFighters, int indexAttacker, int indexWounded )
    {
        string nameAttacker = allFighters[ indexAttacker ].Name;
        bool isAttackerLive = allFighters[ indexAttacker ].IsAlive();
        int damageOfAttacker = isAttackerLive
            ? allFighters[ indexAttacker ].CalculateDamage()
            : 0;
        int armorOfAttacker = allFighters[ indexAttacker ].CalculateArmor();

        int criticalDamage = DetermineCriticalDamage( nameAttacker );
        return ( int )( Math.Max( ( damageOfAttacker - armorOfAttacker ) * criticalDamage, 0 ) * damageRatio );

    }
    private static int DetermineCriticalDamage( string name, bool isLive = true )
    {
        int criticalDamage = Random.Shared.Next( 1, 6 ) == 2 ? 2 : 1;
        if ( isLive && criticalDamage == 2 )
        {
            Console.WriteLine( $"Бойцу {name} выпала удача! Критический урон." );
        }
        return criticalDamage;
    }
}