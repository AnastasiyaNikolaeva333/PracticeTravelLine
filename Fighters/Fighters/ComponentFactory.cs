public class ComponentFactory
{
    private static readonly ComponentRepository _repository = ComponentRepository.AllObjects;
    private static HashSet<string> _allNickName = new HashSet<string>();
    public static IRace GetRace()
    {
        return ConsoleMenu.Select(
           "Выберите расу из списка ниже:",
           _repository.Races,
           race => race.Name );
    }
    public static IRole GetRole()
    {
        return ConsoleMenu.Select(
            "Выберете роль персонажу",
            _repository.Roles,
            role => role.Name );
    }
    public static string GetUniqueNickname()
    {
        Console.WriteLine( "Введите имя(никнейм) персонажа(оно должно быть уникальным):" );
        string name = GetResponseFromUser();
        while ( _allNickName.Contains( name ) )
        {
            Console.WriteLine( "Никнейм должен быть уникальным. Введи ещё раз" );
            name = GetResponseFromUser();
        }
        _allNickName.Add( name );
        return name;
    }
    public static IArmor GetArmor()
    {
        return ConsoleMenu.Select(
            "Вы можете выбрать броню персонажу(По умолчанию: броня отсутствует)",
            _repository.Armors,
            armor => armor.Name,
            0 );
    }
    public static IWeapon GetWeapon()
    {
        return ConsoleMenu.Select(
            "Вы можете выбрать оружие персонажу(По умолчанию: кулаки)",
            _repository.Weapons,
            weapon => weapon.Name,
            0 );
    }
    private static string GetResponseFromUser()
    {
        string response = Console.ReadLine();
        while ( string.IsNullOrWhiteSpace( response ) )
        {
            Console.WriteLine( "Ввод пустой. Введите ещё раз." );
            response = Console.ReadLine();
        }
        return response.Trim();
    }
}
