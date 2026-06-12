public class CharacterBuilder
{
    private string _nickname;
    private IRace _race;
    private IRole _role;
    private IWeapon _weapon;
    private IArmor _armor;
    public CharacterBuilder AddName()
    {
        _nickname = Response.GetUniqueNickname();
        return this;
    }
    public CharacterBuilder ChangeRace()
    {
        _race = Response.GetRace();
        return this;
    }
    public CharacterBuilder ChangeRole()
    {
        _role = Response.GetRole();
        return this;
    }
    public CharacterBuilder ChangeWeapon()
    {
        _weapon = Response.GetWeapon();
        return this;
    }
    public CharacterBuilder ChangeArmor()
    {
        _armor = Response.GetArmor();
        return this;
    }
    public IFighter Build()
    {
        IFighter character = new Fighter( _nickname, _race, _role );
        character.SetWeapon( _weapon );
        character.SetArmor( _armor );
        return character;
    }
}