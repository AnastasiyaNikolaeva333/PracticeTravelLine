public interface IFighter : ICharacter
{
    public string Name { get; }
    public int FullDamage { get; }
    public int Initiative { get; set; }
    public void SetArmor( IArmor armor );
    public void SetWeapon( IWeapon weapon );
    public int TakeDamage( IFighter fighter, double damageRatio );
    public void RestoreHealth();
    public bool IsAlive();
}