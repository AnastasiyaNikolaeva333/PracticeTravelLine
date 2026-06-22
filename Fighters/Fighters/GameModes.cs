public class GameModes
{
    private readonly IOutputProvider _output;
    private readonly ComponentFactory _factory;
    private readonly GameManager _gameManager;
    private readonly DamageFighter _damageFighter;
    public GameModes(
        IOutputProvider output,
        ComponentFactory factory,
        GameManager gameManager,
        DamageFighter damageFighter )
    {
        _output = output;
        _factory = factory;
        _gameManager = gameManager;
        _damageFighter = damageFighter;
    }
    public void AddFighter( List<IFighter> allFighters )
    {
        var builder = new CharacterBuilder( _factory, _damageFighter );
        IFighter character = builder
            .AddName()
            .ChangeRace()
            .ChangeRole()
            .ChangeWeapon()
            .ChangeArmor()
            .Build();
        allFighters.Add( character );
    }
    public void Show( List<IFighter> allFighters )
    {
        if ( allFighters.Count < 1 )
        {
            _output.Print( "Бойцы отсутствуют" );
            return;
        }
        for ( int i = 0; i < allFighters.Count; i++ )
        {
            _output.Print( $"{i + 1}. {allFighters[ i ].GetAllInformation()}" );
        }
    }
    public void Play( List<IFighter> allFighters )
    {
        if ( allFighters.Count < 2 || allFighters.Count % 2 != 0 )
        {
            _output.Print( $"Игра невозможна. Персонажей должно быть больше 2 и " +
                $"чётное количество. Сейчас их {allFighters.Count()}" );
            return;
        }
        string nameWinner = _gameManager.StartBattles( allFighters );
        _output.Print( $"\n{nameWinner} ОДЕРЖАЛ ПОБЕДУ!!!\n" );
        foreach ( IFighter fighter in allFighters )
        {
            fighter.RestoreHealth();
        }
    }
    public void EndGame( ref bool flagEndGame )
    {
        flagEndGame = true;
        _output.Print( "Игра окончена. До новой встречи!" );
    }
}