using Moq;
public class FighterTests
{
    private readonly Mock<IRace> _mockRace;
    private readonly Mock<IRole> _mockRole;
    private readonly Mock<IDamageCalculator> _mockDamageFighter;
    private readonly Mock<IWeapon> _mockWeapon;
    private readonly Mock<IArmor> _mockArmor;
    public FighterTests()
    {
        _mockRace = new Mock<IRace>();
        _mockRole = new Mock<IRole>();
        _mockDamageFighter = new Mock<IDamageCalculator>();
        _mockWeapon = new Mock<IWeapon>();
        _mockArmor = new Mock<IArmor>();
    }
    private Fighter CreateFighter( string name = "Test", int raceHealth = 100, int roleHealth = 50 )
    {
        _mockRace.SetupGet( r => r.Health ).Returns( raceHealth );
        _mockRole.SetupGet( r => r.Health ).Returns( roleHealth );
        _mockRace.SetupGet( r => r.Damage ).Returns( 0 );
        _mockRole.SetupGet( r => r.Damage ).Returns( 0 );
        _mockRace.SetupGet( r => r.Armor ).Returns( 0 );
        _mockRace.SetupGet( r => r.Name ).Returns( "TestRace" );
        _mockRole.SetupGet( r => r.Name ).Returns( "TestRole" );
        return new Fighter( name, _mockRace.Object, _mockRole.Object, _mockDamageFighter.Object );
    }


    [Fact]
    public void Initiative_SetZero_ReturnsZero()
    {
        var fighter = CreateFighter();

        fighter.Initiative = 0;

        Assert.Equal( 0, fighter.Initiative );
    }

    [Fact]
    public void Initiative_SetNegativeValue_ReturnsZero()
    {
        var fighter = CreateFighter();

        fighter.Initiative = -5;

        Assert.Equal( 0, fighter.Initiative );
    }

    [Fact]
    public void TakeDamage_ExactHealthDamage_FighterDies()
    {
        var fighter = CreateFighter( raceHealth: 50, roleHealth: 0 );
        var attacker = new Mock<IFighter>();

        _mockDamageFighter
            .Setup( d => d.DetermineDamage( attacker.Object, 1.0, It.IsAny<int>() ) )
            .Returns( 50 );

        fighter.TakeDamage( attacker.Object, 1.0 );

        Assert.False( fighter.IsAlive() );
    }

    [Fact]
    public void TakeDamage_MultipleAttacks_HealthDecreasesCorrectly()
    {
        var fighter = CreateFighter( raceHealth: 100, roleHealth: 0 );
        var attacker = new Mock<IFighter>();

        _mockDamageFighter
            .Setup( d => d.DetermineDamage( attacker.Object, 1.0, It.IsAny<int>() ) )
            .Returns( 30 );

        fighter.TakeDamage( attacker.Object, 1.0 );

        Assert.True( fighter.IsAlive() ); // 100 - 30 = 70 > 0
    }

    [Fact]
    public void RestoreHealth_AfterFatalDamage_RestoresToFull()
    {
        var fighter = CreateFighter( raceHealth: 100, roleHealth: 50 );
        var attacker = new Mock<IFighter>();

        _mockDamageFighter
            .Setup( d => d.DetermineDamage( attacker.Object, 1.0, It.IsAny<int>() ) )
            .Returns( 500 );

        fighter.TakeDamage( attacker.Object, 1.0 );
        Assert.False( fighter.IsAlive() );

        fighter.RestoreHealth();

        Assert.True( fighter.IsAlive() );
    }

    [Fact]
    public void GetAllInformation_ReturnsCorrectFormat()
    {
        _mockRace.SetupGet( r => r.Name ).Returns( "Человек" );
        _mockRole.SetupGet( r => r.Name ).Returns( "Разрушитель" );
        _mockRace.SetupGet( r => r.Health ).Returns( 100 );
        _mockRole.SetupGet( r => r.Health ).Returns( 30 );
        _mockRace.SetupGet( r => r.Damage ).Returns( 5 );
        _mockRole.SetupGet( r => r.Damage ).Returns( 10 );
        _mockRace.SetupGet( r => r.Armor ).Returns( 0 );

        _mockWeapon.SetupGet( w => w.Name ).Returns( "Нож" );
        _mockWeapon.SetupGet( w => w.Damage ).Returns( 15 );
        _mockArmor.SetupGet( a => a.Name ).Returns( "Щит" );
        _mockArmor.SetupGet( a => a.Armor ).Returns( 10 );

        var fighter = new Fighter( "Герой", _mockRace.Object, _mockRole.Object, _mockDamageFighter.Object );
        fighter.SetWeapon( _mockWeapon.Object );
        fighter.SetArmor( _mockArmor.Object );

        var info = fighter.GetAllInformation();

        Assert.Contains( "Герой", info );
        Assert.Contains( "Роль: Разрушитель", info );
        Assert.Contains( "Раса: Человек", info );
        Assert.Contains( "Броня: Щит", info );
        Assert.Contains( "Оружие: Нож", info );
        Assert.Contains( "Здоровье: 130", info );
        Assert.Contains( "Ущерб: 30", info ); // 15 + 5 + 10 = 30
    }
}