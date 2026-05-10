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
    private static IRole GetRole()
    {
        List<IRole> roles = new List<IRole>()
        {
            new Destroyer(),
            new Healer(),
            new Knight(),
            new Universal(),

        };
        Console.WriteLine( "Выберете роль персонажу" );
        for ( int i = 0; i < roles.Count; i++ )
        {
            Console.WriteLine( $"{i}. {roles[ i ].Name}" );
        }
        string role = Response.GetResponseFromUser();
        HashSet<string> allRoles = new HashSet<string> { "0", "1", "2", "3" };
        while ( !allRoles.Contains( role ) )
        {
            Console.WriteLine( "Вы должны ввести число от 0-4" );
            role = Response.GetResponseFromUser();
        }
        switch ( role )
        {
            case "0": return roles[ 0 ];
            case "1": return roles[ 1 ];
            case "2": return roles[ 2 ];
            case "3": return roles[ 3 ];
            default: throw new ArgumentException();
        }
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
        Console.WriteLine( "Вы можете выбрать броню персонажу(По умолчанию: броня отсутствует)" );
        for ( int i = 0; i < armors.Count; i++ )
        {
            Console.WriteLine( $"{i}. {armors[ i ].Name}" );
        }
        string armor = Response.GetResponseFromUser();
        HashSet<string> allArmor = new HashSet<string> { "0", "1", "2", "3" };
        while ( !allArmor.Contains( armor ) )
        {
            Console.WriteLine( "Вы должны ввести число от 0-4" );
            armor = Response.GetResponseFromUser();
        }
        switch ( armor )
        {
            case "0": break;
            case "1": { fighter.SetArmor( armors[ 1 ] ); break; }
            case "2": { fighter.SetArmor( armors[ 2 ] ); break; }
            case "3": { fighter.SetArmor( armors[ 3 ] ); break; }
            default: throw new ArgumentException();
        }
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
        Console.WriteLine( "Вы можете выбрать оружие персонажу(По умолчанию: кулаки)" );
        for ( int i = 0; i < weapons.Count; i++ )
        {
            Console.WriteLine( $"{i}. {weapons[ i ].Name}" );
        }
        string weapon = Response.GetResponseFromUser();
        HashSet<string> allWeapon = new HashSet<string> { "0", "1", "2", "3", "4" };
        while ( !allWeapon.Contains( weapon ) )
        {
            Console.WriteLine( "Вы должны ввести число от 0-4" );
            weapon = Response.GetResponseFromUser();
        }
        switch ( weapon )
        {
            case "0": break;
            case "1": { fighter.SetWeapon( weapons[ 1 ] ); break; }
            case "2": { fighter.SetWeapon( weapons[ 2 ] ); break; }
            case "3": { fighter.SetWeapon( weapons[ 3 ] ); break; }
            case "4": { fighter.SetWeapon( weapons[ 4 ] ); break; }
            default: throw new ArgumentException();
        }
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
        Console.WriteLine( "Выберите расу из списка ниже:" );
        for ( int i = 0; i < races.Count; i++ )
        {
            Console.WriteLine( $"{i}. {races[ i ].Name}" );
        }
        string race = Response.GetResponseFromUser();
        HashSet<string> allRace = new HashSet<string> { "0", "1", "2", "3" };
        while ( !allRace.Contains( race ) )
        {
            Console.WriteLine( "Вы должны ввести число от 0-3" );
            race = Response.GetResponseFromUser();
        }
        switch ( race )
        {
            case "0": return races[ 0 ];
            case "1": return races[ 1 ];
            case "2": return races[ 2 ];
            case "3": return races[ 3 ];
            default: throw new ArgumentException();
        }
    }
}