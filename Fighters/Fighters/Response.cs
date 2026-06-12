public class Response
{
    private static HashSet<string> _allNickName = new HashSet<string>();
    public static IRace GetRace()
    {
        List<IRace> races = new List<IRace>()
        {
            new Human(),
            new Dragon(),
            new Avatar(),
            new Beastmen()
        };
        return ConsoleMenu.Select(
            "Выберите расу из списка ниже:",
            races,
            race => race.Name );
    }
    public static IRole GetRole()
    {
        List<IRole> roles = new List<IRole>()
        {
            new Destroyer(),
            new Healer(),
            new Knight(),
            new Universal(),

        };
        return ConsoleMenu.Select(
            "Выберете роль персонажу",
            roles,
            role => role.Name );
    }
    public static string GetUniqueNickname()
    {
        Console.WriteLine( "Введите имя(никнейм) персонажа(оно должно быть уникальным):" );
        string name = Response.GetResponseFromUser();
        while ( _allNickName.Contains( name ) )
        {
            Console.WriteLine( "Никнейм должен быть уникальным. Введи ещё раз" );
            name = Response.GetResponseFromUser();
        }
        _allNickName.Add( name );
        return name;
    }
    public static IArmor GetArmor()
    {
        List<IArmor> armors = new List<IArmor>()
        {
            new NoArmor(),
            new Shield(),
            new ChainMail(),
            new IronArmor()

        };
        return ConsoleMenu.Select(
            "Вы можете выбрать броню персонажу(По умолчанию: броня отсутствует)",
            armors,
            armor => armor.Name,
            0 );
    }
    public static IWeapon GetWeapon()
    {
        List<IWeapon> weapons = new List<IWeapon>()
        {
            new Fists(),
            new Knife(),
            new Gun(),
            new Sword(),
            new MachineGun(),

        };
        return ConsoleMenu.Select(
            "Вы можете выбрать оружие персонажу(По умолчанию: кулаки)",
            weapons,
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
