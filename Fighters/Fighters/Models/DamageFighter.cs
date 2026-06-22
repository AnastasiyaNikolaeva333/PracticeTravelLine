public class DamageFighter : IDamageCalculator
{
    private readonly IOutputProvider _output;
    public DamageFighter( IOutputProvider output )
    {
        _output = output;
    }
    public int DetermineDamage( IFighter fighter, double damageRatio, int armor )
    {
        string nameAttacker = fighter.Name;
        bool isAttackerLive = fighter.IsAlive();
        int damage = fighter.FullDamage;
        int damageOfAttacker = isAttackerLive
            ? CalculateFullDamage( nameAttacker, isAttackerLive, damage )
            : 0;
        return ( int )( Math.Max( ( damageOfAttacker - armor ), 0 ) * damageRatio );
    }
    private int CalculateFullDamage( string name, bool isLive, int damage )
    {
        int criticalDamage = Random.Shared.Next( 1, 6 ) == 2 ? 2 : 1;
        if ( isLive && criticalDamage == 2 )
        {
            _output.Print( $"Бойцу {name} выпала удача! Критический урон." );
        }
        criticalDamage *= damage;
        return criticalDamage;
    }
}