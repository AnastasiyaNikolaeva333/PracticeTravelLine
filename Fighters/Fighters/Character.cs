public class Character
{
    private static HashSet<string> _allNickName = new HashSet<string>();
    public static IFighter CreateFighter()
    {
        Console.WriteLine( "Введите имя(никнейм) персонажа(оно должно быть уникальным):" );
        string name = GetUniqueNickname();
        IRace race = GetRace();
        IRole role = GetRole();
        IFighter fighter = new Fighter( name, race, role );
        ChangeWeapon( fighter );
        ChangeArmor( fighter );
        return fighter;

    }
    private static IRace GetRace()
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
    private static IRole GetRole()
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
    private static string GetUniqueNickname()
    {
        string name = Response.GetResponseFromUser();
        while ( _allNickName.Contains( name ) )
        {
            Console.WriteLine( "Никнейм должен быть уникальным. Введи ещё раз" );
            name = Response.GetResponseFromUser();
        }
        _allNickName.Add( name );
        return name;
    }
    private static void ChangeArmor( IFighter fighter )
    {
        List<IArmor> armors = new List<IArmor>()
        {
            new NoArmor(),
            new Shield(),
            new ChainMail(),
            new IronArmor()

        };
        IArmor armor = ConsoleMenu.Select(
            "Вы можете выбрать броню персонажу(По умолчанию: броня отсутствует)",
            armors,
            armor => armor.Name,
            0 );
        fighter.SetArmor( armor );
    }
    private static void ChangeWeapon( IFighter fighter )
    {
        List<IWeapon> weapons = new List<IWeapon>()
        {
            new Fists(),
            new Knife(),
            new Gun(),
            new Sword(),
            new MachineGun(),

        };
        IWeapon weapon = ConsoleMenu.Select(
            "Вы можете выбрать оружие персонажу(По умолчанию: кулаки)",
            weapons,
            weapon => weapon.Name,
            0 );
        fighter.SetWeapon( weapon );
    }
}
