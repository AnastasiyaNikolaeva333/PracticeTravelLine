public class Fighter : IFighter
{
    public string Name { get; private set; }
    private readonly IRace _race;
    private readonly IRole _role;
    private IArmor _armor = new NoArmor();
    private IWeapon _weapon = new Fists();
    private int _currentHealth;
    public Fighter( string name, IRace race, IRole role )
    {
        Name = name;
        _role = role;
        _race = race;
        _currentHealth = GetMaxHealth();
    }
    public int GetCurrentHealth() => _currentHealth;
    public int GetMaxHealth() => _race.Health + _role.Health;
    public int CalculateDamage() => _weapon.Damage + _race.Damage + _role.Damage;
    public int CalculateArmor() => _armor.Armor + _race.Armor;
    public void SetArmor( IArmor armor ) => _armor = armor;
    public void SetWeapon( IWeapon weapon ) => _weapon = weapon;
    public void TakeDamage( int damage )
    {
        int newHealth = _currentHealth - damage;
        if ( newHealth < 0 )
        {
            newHealth = 0;
        }
        _currentHealth = newHealth;
    }
    public void RestoreHealth() => _currentHealth = GetMaxHealth();
    public bool IsAlive() => GetCurrentHealth() > 0;
    public string GetAllInformation()
    {
        return $"{Name}\n" +
            $"Роль: {_role.Name}\n" +
            $"Раса: {_race.Name}\n" +
            $"Броня: {_armor.Name}\n" +
            $"Оружие: {_weapon.Name}\n" +
            $"Здоровье: {_currentHealth}\n" +
            $"Ущерб: {CalculateDamage()}\n";
    }
}