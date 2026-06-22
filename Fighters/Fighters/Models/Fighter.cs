public class Fighter : IFighter
{
    private readonly IDamageCalculator _damageFighter;
    public string Name { get; private set; }
    private int _initiative;
    public int Initiative
    {
        get => _initiative;
        set
        {
            _initiative = value >= 0 ? value : 0;
        }
    }
    private readonly IRace _race;
    private readonly IRole _role;
    private readonly Health _health;
    private IArmor _armor = new NoArmor();
    private IWeapon _weapon = new Fists();
    public int FullDamage => _weapon.Damage + _race.Damage + _role.Damage;
    private int FullArmor => _armor.Armor + _race.Armor;
    public Fighter( string name, IRace race, IRole role, IDamageCalculator damageFighter )
    {
        Name = name;
        _role = role;
        _race = race;
        _damageFighter = damageFighter;
        _health = new Health( _race.Health, _role.Health );
    }
    public void SetArmor( IArmor armor ) => _armor = armor;
    public void SetWeapon( IWeapon weapon ) => _weapon = weapon;
    public int TakeDamage( IFighter fighter, double damageRatio )
    {
        int damage = _damageFighter.DetermineDamage( fighter, damageRatio, FullArmor );
        _health.UndermineHealth( damage );
        return damage;
    }
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
            $"Ущерб: {FullDamage}\n";
    }
}