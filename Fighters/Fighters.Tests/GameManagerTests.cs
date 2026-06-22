using Moq;
public class GameManagerTests
{
    private readonly Mock<IOutputProvider> _mockOutput;
    private readonly Mock<IRandomProvider> _mockRandom;
    private readonly GameManager _gameManager;
    public GameManagerTests()
    {
        _mockOutput = new Mock<IOutputProvider>();
        _mockRandom = new Mock<IRandomProvider>();
        _gameManager = new GameManager( _mockOutput.Object, _mockRandom.Object );
    }
    private (Mock<IFighter> fighter1, Mock<IFighter> fighter2) CreateTwoFighters()
    {
        var f1 = new Mock<IFighter>();
        var f2 = new Mock<IFighter>();
        f1.SetupGet( f => f.Name ).Returns( "Боец1" );
        f2.SetupGet( f => f.Name ).Returns( "Боец2" );
        return (f1, f2);
    }

    [Fact]
    public void StartBattles_OneFighterDead_ReturnsWinnerName()
    {
        var (f1, f2) = CreateTwoFighters();

        f1.Setup( f => f.IsAlive() ).Returns( true );
        f1.SetupGet( f => f.Name ).Returns( "Победитель" );
        f1.SetupGet( f => f.Initiative ).Returns( 1 );

        f2.Setup( f => f.IsAlive() ).Returns( false );
        f2.SetupGet( f => f.Name ).Returns( "Проигравший" );
        f2.SetupGet( f => f.Initiative ).Returns( 2 );

        _mockRandom.Setup( r => r.Next( It.IsAny<int>(), It.IsAny<int>() ) ).Returns( 1 );
        var fighters = new List<IFighter> { f1.Object, f2.Object };

        var result = _gameManager.StartBattles( fighters );

        Assert.Equal( "Победитель", result );
    }

    [Fact]
    public void SetInitiative_AllFightersHaveUniqueInitiatives()
    {
        var fighters = new List<IFighter>();
        for ( int i = 0; i < 4; i++ )
        {
            var mock = new Mock<IFighter>();
            mock.SetupProperty( f => f.Initiative );
            mock.Setup( f => f.IsAlive() ).Returns( true );
            mock.Setup( f => f.TakeDamage( It.IsAny<IFighter>(), It.IsAny<double>() ) ).Returns( 0 );
            fighters.Add( mock.Object );
        }

        int callCount = 0;
        foreach ( var f in fighters )
        {
            var mock = Mock.Get( f );
            mock.Setup( f => f.IsAlive() ).Returns( () => callCount < 1 );
        }

        var randomValues = new Queue<int>( new[] { 5, 5, 3, 7 } );
        _mockRandom.Setup( r => r.Next( It.IsAny<int>(), It.IsAny<int>() ) )
            .Returns( () => randomValues.Count > 0 ? randomValues.Dequeue() : 1 );
        _mockRandom.Setup( r => r.Next( -20, 50 ) ).Returns( 0 );

        fighters[ 0 ].TakeDamage( It.IsAny<IFighter>(), It.IsAny<double>() );
        var f0Mock = Mock.Get( fighters[ 0 ] );
        f0Mock.Setup( f => f.TakeDamage( It.IsAny<IFighter>(), It.IsAny<double>() ) )
            .Callback( () => callCount++ )
            .Returns( 0 );

        _gameManager.StartBattles( fighters );

        var initiatives = fighters.Select( f => f.Initiative ).ToList();
        Assert.Equal( 4, initiatives.Distinct().Count() );
    }
}