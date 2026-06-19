public class DamageFighter
{
    public static int DetermineDamage( IFighter fighter, double damageRatio, int armor )
    {
        string nameAttacker = fighter.Name;
        bool isAttackerLive = fighter.IsAlive();
        int damage = fighter.FullDamage;
        int damageOfAttacker = isAttackerLive
            ? CalculateFullDamage( nameAttacker, isAttackerLive, damage )
            : 0;
        return ( int )( Math.Max( ( damageOfAttacker - armor ), 0 ) * damageRatio );

    }
    private static int CalculateFullDamage( string name, bool isLive, int damage )
    {
        int criticalDamage = Random.Shared.Next( 1, 6 ) == 2 ? 2 : 1;
        if ( isLive && criticalDamage == 2 )
        {
            ConsoleLogger.Print( $"Бойцу {name} выпала удача! Критический урон." );
        }
        criticalDamage *= damage;
        return criticalDamage;
    }
}