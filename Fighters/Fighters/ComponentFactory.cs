public class ComponentFactory
{
    private readonly IInputProvider _input;
    private readonly IOutputProvider _output;
    private readonly ComponentRepository _repository;
    private readonly ConsoleMenu _menu;
    private HashSet<string> _allNickName = new HashSet<string>();
    public ComponentFactory(
        IInputProvider input,
        IOutputProvider output,
        ComponentRepository repository,
        ConsoleMenu menu )
    {
        _input = input;
        _output = output;
        _repository = repository;
        _menu = menu;
    }
    public IRace GetRace()
    {
        return _menu.Select(
           "Выберите расу из списка ниже:",
           _repository.Races,
           race => race.Name );
    }
    public IRole GetRole()
    {
        return _menu.Select(
            "Выберете роль персонажу",
            _repository.Roles,
            role => role.Name );
    }
    public string GetUniqueNickname()
    {
        _output.Print( "Введите имя(никнейм) персонажа(оно должно быть уникальным):" );
        string name = GetResponseFromUser();
        while ( _allNickName.Contains( name ) )
        {
            _output.Print( "Никнейм должен быть уникальным. Введи ещё раз" );
            name = GetResponseFromUser();
        }
        _allNickName.Add( name );
        return name;
    }
    public IArmor GetArmor()
    {
        return _menu.Select(
            "Вы можете выбрать броню персонажу(По умолчанию: броня отсутствует)",
            _repository.Armors,
            armor => armor.Name,
            0 );
    }
    public IWeapon GetWeapon()
    {
        return _menu.Select(
            "Вы можете выбрать оружие персонажу(По умолчанию: кулаки)",
            _repository.Weapons,
            weapon => weapon.Name,
            0 );
    }
    private string GetResponseFromUser()
    {
        string response = _input.ReadLine();
        while ( string.IsNullOrWhiteSpace( response ) )
        {
            _output.Print( "Ввод пустой. Введите ещё раз." );
            response = _input.ReadLine();
        }
        return response.Trim();
    }
}