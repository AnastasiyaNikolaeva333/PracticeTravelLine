public class GameManager
{
    public static string StartBattles( List<IFighter> allFighter )
    {
        int numRound = 1;
        int countFighter = allFighter.Count;
        while ( countFighter > 1 )
        {
            Console.WriteLine( $"{numRound} РАУНД" );
            allFighter = DefineInitiative( allFighter );
            for ( int i = 0; i < countFighter / 2; i++ )
            {
                int firstFighter = i;
                int secondFighter = countFighter - i - 1;
                ProcessRound( allFighter, firstFighter, secondFighter );
                if ( !allFighter[ firstFighter ].IsAlive() )
                {
                    Console.WriteLine( $"{allFighter[ firstFighter ].Name} погибает" );
                }
                if ( !allFighter[ secondFighter ].IsAlive() )
                {
                    Console.WriteLine( $"{allFighter[ secondFighter ].Name} погибает" );
                }
            }
            ++numRound;
            allFighter = allFighter.Where( f => f.IsAlive() ).ToList();
            countFighter = allFighter.Count;
        }
        return allFighter[ 0 ].Name;
    }

    private static List<IFighter> DefineInitiative( List<IFighter> allFighter )
    {
        int countKnight = allFighter.Count;
        int initiative = Random.Shared.Next( 1, countKnight * 10 );
        var sortedList = new SortedList<int, int>();
        HashSet<int> allInitiative = new HashSet<int>();
        for ( int i = 0; i < countKnight; i++ )
        {
            while ( allInitiative.Contains( initiative ) )
            {
                initiative = Random.Shared.Next( 1, countKnight * 10 );
            }
            allInitiative.Add( initiative );
            sortedList.Add( initiative, i );
        }
        List<IFighter> sortedKnight = new List<IFighter>();
        foreach ( var i in sortedList )
        {
            sortedKnight.Add( allFighter[ i.Value ] );
        }
        return sortedKnight;
    }

    private static void ProcessRound( List<IFighter> allFighter, int indexFirstKnight, int indexSecondKnight )
    {
        string nameFirstKnight = allFighter[ indexFirstKnight ].Name;
        int damageOfFirst = allFighter[ indexFirstKnight ].CalculateDamage();
        int armorOfFirst = allFighter[ indexFirstKnight ].CalculateArmor();

        string nameSecondKnight = allFighter[ indexSecondKnight ].Name;
        int armorOfSecond = allFighter[ indexSecondKnight ].CalculateArmor();

        int criticalDamage = Random.Shared.Next( 1, 6 ) == 2 ? 2 : 1;
        if ( criticalDamage == 2 )
        {
            Console.WriteLine( $"Бойцу {nameFirstKnight} выпала удача! Критический урон." );
        }
        double damageRatio = 1.0 - Random.Shared.Next( -20, 50 ) / 100.0;
        int maxDamageOfFirst = ( int )( Math.Max( ( damageOfFirst - armorOfSecond ) * criticalDamage, 0 ) * damageRatio );
        allFighter[ indexSecondKnight ].TakeDamage( maxDamageOfFirst );

        int isSecondLive = allFighter[ indexSecondKnight ].IsAlive() ? 1 : 0;
        int damageOfSecond = allFighter[ indexSecondKnight ].CalculateDamage() * isSecondLive;
        criticalDamage = Random.Shared.Next( 1, 8 ) == 2 ? 2 : 1;
        if ( criticalDamage == 2 && isSecondLive == 1 )
        {
            Console.WriteLine( $"Бойцу {nameSecondKnight} выпала удача! Критический урон." );
        }
        int maxDamageOfSecond = ( int )( Math.Max( ( damageOfSecond - armorOfFirst ) * criticalDamage, 0 ) * damageRatio );
        allFighter[ indexFirstKnight ].TakeDamage( maxDamageOfSecond );

        Console.WriteLine( $"{nameFirstKnight} наносит {maxDamageOfFirst} урона, получает {maxDamageOfSecond}" );
        Console.WriteLine( $"{nameSecondKnight} наносит {maxDamageOfSecond} урона, получает {maxDamageOfFirst}" );
    }
}