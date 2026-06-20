public class Health
{
    private int _currentHealth;
    public Health( int healthRace, int healthRole )
    {
        _currentHealth = healthRace + healthRole;
    }
    public int GetCurrentHealth() => _currentHealth;
    public void UndermineHealth( int damage )
    {
        _currentHealth = Math.Max( _currentHealth - damage, 0 );
    }
    public void RestoreHealth( int healthRace, int healthRole )
    {
        _currentHealth = healthRace + healthRole;
    }
}