public class GameManager
{
    private readonly IOutputProvider _output;
    private readonly IRandomProvider _random;
    public GameManager( IOutputProvider output, IRandomProvider random )
    {
        _output = output;
        _random = random;
    }
    public string StartBattles( List<IFighter> allFighters )
    {
        int numRound = 1;
        while ( allFighters.All( f => f.IsAlive() ) )
        {
            _output.Print( $"\n{numRound++} РАУНД" );
            DefineInitiative( allFighters );
            ProcessRounds( allFighters );
        }
        return allFighters[ 0 ].Name;
    }
    private void DefineInitiative( List<IFighter> allFighters )
    {
        SetInitiativeFighters( allFighters );
        allFighters.Sort( ( x, y ) => x.Initiative.CompareTo( y.Initiative ) );
    }
    private void SetInitiativeFighters( List<IFighter> allFighters )
    {
        int countFighter = allFighters.Count;
        HashSet<int> uniqueInitiatives = new HashSet<int>();
        int initiative = _random.Next( 1, countFighter * 10 );
        for ( int i = 0; i < countFighter; i++ )
        {
            while ( uniqueInitiatives.Contains( initiative ) )
            {
                initiative = _random.Next( 1, countFighter * 10 );
            }
            uniqueInitiatives.Add( initiative );
            allFighters[ i ].Initiative = initiative;
        }
    }
    private void ProcessRounds( List<IFighter> allFighters )
    {
        int countFighter = allFighters.Count;
        for ( int i = 0; i < countFighter / 2; i++ )
        {
            IFighter firstFighter = allFighters[ i ];
            IFighter secondFighter = allFighters[ countFighter - i - 1 ];
            ProcessRound( firstFighter, secondFighter );
            if ( !firstFighter.IsAlive() )
            {
                _output.Print( $"{firstFighter.Name} погибает" );
            }
            if ( !secondFighter.IsAlive() )
            {
                _output.Print( $"{secondFighter.Name} погибает" );
            }
        }
    }
    private void ProcessRound( IFighter attackerFighter, IFighter receivingFighter )
    {
        double damageRatio = 1.0 - _random.Next( -20, 50 ) / 100.0;

        int damageOfFirst = receivingFighter.TakeDamage( attackerFighter, damageRatio );
        int damageOfSecond = attackerFighter.TakeDamage( receivingFighter, damageRatio );

        string nameAttacker = attackerFighter.Name;
        string nameReceiving = receivingFighter.Name;
        _output.Print( $"{nameAttacker} наносит {damageOfFirst} урона, получает {damageOfSecond}" );
        _output.Print( $"{nameReceiving} наносит {damageOfSecond} урона, получает {damageOfFirst}" );
    }
}