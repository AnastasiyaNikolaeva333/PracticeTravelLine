public class Fighter : IFighter
{
    public string Name { get; private set; }
    private readonly IRace _race;
    private readonly IRole _role;
    private readonly Health _health;
    private IArmor _armor = new NoArmor();
    private IWeapon _weapon = new Fists();
    private int _fullDamage;
    private int _fullArmor;
    public Fighter( string name, IRace race, IRole role )
    {
        Name = name;
        _role = role;
        _race = race;
        _health = new Health( _race.Health, _role.Health );
        _fullDamage = _weapon.Damage + _race.Damage + _role.Damage;
        _fullArmor = _armor.Armor + _race.Armor;
    }
    public int CalculateDamage() => _fullDamage;
    public int CalculateArmor() => _fullArmor;
    public void SetArmor( IArmor armor ) => _armor = armor;
    public void SetWeapon( IWeapon weapon ) => _weapon = weapon;
    public void TakeDamage( int damage ) => _health.UndermineHealth( damage );
    public void RestoreHealth() => _health.RestoreHealth( _race.Health, _role.Health );
    public bool IsAlive() => _health.GetCurrentHealth() > 0;
    public string GetAllInformation()
    {
        return $"{Name}\n" +
            $"Роль: {_role.Name}\n" +
            $"Раса: {_race.Name}\n" +
            $"Броня: {_armor.Name}\n" +
            $"Оружие: {_weapon.Name}\n" +
            $"Здоровье: {_health.GetCurrentHealth()}\n" +
            $"Ущерб: {CalculateDamage()}\n";
    }
}