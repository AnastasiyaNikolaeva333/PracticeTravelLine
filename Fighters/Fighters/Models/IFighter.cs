public interface IFighter : ICharacter
{
    public string Name { get; }
    public int CalculateDamage();
    public int CalculateArmor();
    public void SetArmor( IArmor armor );
    public void SetWeapon( IWeapon weapon );
    public void TakeDamage( int damage );
    public void RestoreHealth();
    public bool IsAlive();
}