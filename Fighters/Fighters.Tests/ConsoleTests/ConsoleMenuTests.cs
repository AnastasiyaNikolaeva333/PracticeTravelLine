using Moq;
public class ConsoleMenuTests
{
    private string _title = "Test";
    private Mock<IInputProvider> _mockInput;
    private Mock<IOutputProvider> _mockOutput;
    private ConsoleMenu _consoleMenu;
    public ConsoleMenuTests()
    {
        _mockInput = new Mock<IInputProvider>();
        _mockOutput = new Mock<IOutputProvider>();
        _consoleMenu = new ConsoleMenu( _mockInput.Object, _mockOutput.Object );
    }
    private List<MenuCommand> CreateTestOptions(
        int count = 5,
        string prefix = "Option",
        string commandPrefix = "command" )
    {
        var options = new List<MenuCommand>();
        for ( int i = 1; i <= count; i++ )
        {
            options.Add( new MenuCommand
            {
                Key = i.ToString()[ 0 ],
                Description = $"{prefix} {i}",
                Command = $"{commandPrefix}{i}"
            } );
        }
        return options;
    }
    [Fact]
    public void ReadCommand_IsEverythingDisplayedInConsole_AllMenu()
    {
        List<MenuCommand> options = CreateTestOptions();
        _mockInput.Setup( i => i.ReadLine() ).Returns( "1" );

        _consoleMenu.ReadCommand( _title, options );

        for ( int i = 1; i <= 5; i++ )
        {
            _mockOutput.Verify( o => o.Print( $"  {i}. Option {i}" ), Times.Once );
        }
        _mockOutput.Verify( o => o.Print( "Неверный ввод. Попробуйте снова." ), Times.Exactly( 0 ) );
    }
    [Fact]
    public void ReadCommand_Option5Selected_SelectedTeam()
    {
        var options = CreateTestOptions();
        _mockInput.Setup( i => i.ReadLine() ).Returns( "5" );

        var result = _consoleMenu.ReadCommand( _title, options );

        Assert.Equal( "command5", result );
        _mockOutput.Verify( o => o.Print( "Неверный ввод. Попробуйте снова." ), Times.Exactly( 0 ) );
    }
    [Fact]
    public void ReadCommand_InvalidInput_ShowsErrorMessage()
    {
        var options = CreateTestOptions();
        _mockInput.SetupSequence( i => i.ReadLine() )
            .Returns( "invalid" )
            .Returns( "99" )
            .Returns( "2" );

        var result = _consoleMenu.ReadCommand( _title, options );

        Assert.Equal( "command2", result );
        _mockOutput.Verify( o => o.Print( "Неверный ввод. Попробуйте снова." ), Times.Exactly( 2 ) );
    }
    [Fact]
    public void Select_DisplaysAllItems()
    {
        var items = new List<string> { "A", "B", "C" };
        _mockInput.Setup( i => i.ReadLine() ).Returns( "1" );

        _consoleMenu.Select( _title, items, x => x );

        _mockOutput.Verify( o => o.Print( _title ), Times.Once );
        _mockOutput.Verify( o => o.Print( "1. A" ), Times.Once );
        _mockOutput.Verify( o => o.Print( "2. B" ), Times.Once );
        _mockOutput.Verify( o => o.Print( "3. C" ), Times.Once );
    }
    [Fact]
    public void Select_ValidChoice_ReturnsCorrectItem()
    {
        var items = new List<string> { "A", "B", "C" };
        _mockInput.Setup( i => i.ReadLine() ).Returns( "2" );

        var result = _consoleMenu.Select( _title, items, x => x );

        Assert.Equal( "B", result );
    }
    [Fact]
    public void Select_EmptyInputWithDefault_ReturnsDefaultItem()
    {
        var items = new List<string> { "A", "B", "C" };
        _mockInput.Setup( i => i.ReadLine() ).Returns( "" );

        var result = _consoleMenu.Select( _title, items, x => x, defaultValue: 1 );

        Assert.Equal( "B", result );
    }
    [Fact]
    public void Select_EmptyInputWithoutDefault_ShowsError()
    {
        var items = new List<string> { "A", "B" };
        _mockInput.SetupSequence( i => i.ReadLine() )
            .Returns( "" )
            .Returns( "1" );

        var result = _consoleMenu.Select( _title, items, x => x );

        Assert.Equal( "A", result );
        _mockOutput.Verify( o => o.Print( "Неверный ввод. Попробуйте снова." ), Times.Once );
    }

    [Fact]
    public void Select_DefaultValueMinus1_NoDefaultMarker()
    {
        var items = new List<string> { "A", "B" };
        _mockInput.Setup( i => i.ReadLine() ).Returns( "1" );

        _consoleMenu.Select( _title, items, x => x );

        _mockOutput.Verify( o => o.Print( It.Is<string>( s => s.Contains( "(по умолчанию)" ) ) ), Times.Never );
    }

    [Fact]
    public void Select_MultipleInvalidInputs_ShowsErrorMultipleTimes()
    {
        var items = new List<string> { "A", "B" };
        _mockInput.SetupSequence( i => i.ReadLine() )
            .Returns( "" )
            .Returns( "abc" )
            .Returns( "0" )
            .Returns( "3" )
            .Returns( "1" );

        var result = _consoleMenu.Select( _title, items, x => x );

        Assert.Equal( "A", result );
        _mockOutput.Verify( o => o.Print( "Неверный ввод. Попробуйте снова." ), Times.Exactly( 4 ) );
    }
}