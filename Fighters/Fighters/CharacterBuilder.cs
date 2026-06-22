public class CharacterBuilder
{
    private readonly ComponentFactory _factory;
    private readonly DamageFighter _damageFighter;
    private string _nickname;
    private IRace _race;
    private IRole _role;
    private IWeapon _weapon;
    private IArmor _armor;
    public CharacterBuilder( ComponentFactory factory, DamageFighter damageFighter )
    {
        _factory = factory;
        _damageFighter = damageFighter;
    }
    public CharacterBuilder AddName()
    {
        _nickname = _factory.GetUniqueNickname();
        return this;
    }
    public CharacterBuilder ChangeRace()
    {
        _race = _factory.GetRace();
        return this;
    }
    public CharacterBuilder ChangeRole()
    {
        _role = _factory.GetRole();
        return this;
    }
    public CharacterBuilder ChangeWeapon()
    {
        _weapon = _factory.GetWeapon();
        return this;
    }
    public CharacterBuilder ChangeArmor()
    {
        _armor = _factory.GetArmor();
        return this;
    }
    public IFighter Build()
    {
        IFighter character = new Fighter( _nickname, _race, _role, _damageFighter );
        character.SetWeapon( _weapon );
        character.SetArmor( _armor );
        return character;
    }
}