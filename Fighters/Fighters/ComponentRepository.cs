public class ComponentRepository
{
    public static readonly ComponentRepository AllObjects = new ComponentRepository();
    public List<IRace> Races { get; }
    public List<IRole> Roles { get; }
    public List<IWeapon> Weapons { get; }
    public List<IArmor> Armors { get; }
    private ComponentRepository()
    {
        Races = new List<IRace>
        {
            new Human(),
            new Dragon(),
            new Avatar(),
            new Beastmen()
        };

        Roles = new List<IRole>
        {
            new Destroyer(),
            new Healer(),
            new Knight(),
            new Universal()
        };

        Weapons = new List<IWeapon>
        {
            new Fists(),
            new Knife(),
            new Gun(),
            new Sword(),
            new MachineGun()
        };

        Armors = new List<IArmor>
        {
            new NoArmor(),
            new Shield(),
            new ChainMail(),
            new IronArmor()
        };
    }
}