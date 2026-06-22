using Moq;
public class DamageFighterTests
{
    private readonly Mock<IOutputProvider> _mockOutput;
    private readonly DamageFighter _damageFighter;
    public DamageFighterTests()
    {
        _mockOutput = new Mock<IOutputProvider>();
        _damageFighter = new DamageFighter( _mockOutput.Object );
    }

    [Fact]
    public void DetermineDamage_FighterIsDead_ReturnsZero()
    {
        var fighter = new Mock<IFighter>();
        fighter.Setup( f => f.IsAlive() ).Returns( false );

        var result = _damageFighter.DetermineDamage( fighter.Object, 1.0, 0 );

        Assert.Equal( 0, result );
    }

    [Fact]
    public void DetermineDamage_ArmorMoreThanDamage_ReturnsZero()
    {
        var fighter = new Mock<IFighter>();
        fighter.Setup( f => f.IsAlive() ).Returns( true );
        fighter.SetupGet( f => f.Name ).Returns( "Test" );
        fighter.SetupGet( f => f.FullDamage ).Returns( 10 );

        var result = _damageFighter.DetermineDamage( fighter.Object, 1.0, 100 );

        Assert.Equal( 0, result );
    }

    [Theory]
    [InlineData( 0.5 )]
    [InlineData( 1.0 )]
    [InlineData( 2.0 )]
    public void DetermineDamage_WithDamageRatio_ReturnsCorrectRange( double ratio )
    {
        var fighter = new Mock<IFighter>();
        fighter.Setup( f => f.IsAlive() ).Returns( true );
        fighter.SetupGet( f => f.Name ).Returns( "Test" );
        fighter.SetupGet( f => f.FullDamage ).Returns( 100 );

        var result = _damageFighter.DetermineDamage( fighter.Object, ratio, 0 );

        int normal = ( int )( 100 * ratio );
        int critical = ( int )( 200 * ratio );
        Assert.True( result == normal || result == critical );
    }
}