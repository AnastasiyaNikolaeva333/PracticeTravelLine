internal class Program
{
    private const string _header =
        "##### ##### ##### ##### #   # #####\n" +
        "#     #   # #       #   #   # #   #\n" +
        "#     #   # #       #   ##  # #   #\n" +
        "#     ##### #####   #   # # # #   #\n" +
        "#     #   #     #   #   #  ## #   #\n" +
        "##### #   # ##### ##### #   # #####";
    private static List<string> _menuOptions = [
            "1. Пополнить баланс",
            "2. Показать баланс",
            "3. Сыграть",
            "4. Выйти"
            ];
    private static double _balance = 0;
    public static void Main( string[] args )
    {
        Console.WriteLine( _header );
        bool endGame = false;
        while ( !endGame )
        {
            _menuOptions.ForEach( Console.WriteLine );
            string option = Console.ReadLine();
            OptionHandleResult result = HandleOption( option );
            if ( result != OptionHandleResult.Success )
            {
                Console.WriteLine( Error.GetErrorMessage( result ) );
            }
            else if ( result == OptionHandleResult.End )
            {
                endGame = true;
            }
        }
    }
    private static OptionHandleResult HandleOption( string option )
    {
        switch ( option )
        {
            case "1":
                return MakeDeposit();
            case "2":
                ShowBalance();
                break;
            case "3":
                return Play();
            case "4":
                Exit();
                break;
            default:
                return OptionHandleResult.InvalidOption;
        }
        return OptionHandleResult.Success;
    }
    private static void Exit()
    {
        Console.WriteLine( "Вы закончили игру." );
    }
    private static OptionHandleResult Play()
    {
        if ( _balance <= 0 )
        {
            return OptionHandleResult.InvalidBalance;
        }
        ShowBalance();
        int bet = PlaceBet();
        if ( bet < 0 )
        {
            return OptionHandleResult.InvalidBet;
        }
        PrintResult( bet );
        ShowBalance();
        return OptionHandleResult.Success;
    }

    private static void PrintResult( int bet )
    {
        int seed = Random.Shared.Next( 1, 21 );
        Console.WriteLine( seed );
        if ( seed >= 18 && seed <= 20 )
        {
            int winAmout = CalculateWinAmount( bet, seed );
            _balance += winAmout;
            Console.WriteLine( "Вы выйграли!!!" );
        }
        else
        {
            _balance -= bet;
            Console.WriteLine( "Вы проиграли(((" );
        }
    }
    private static int PlaceBet()
    {
        Console.WriteLine( "Введите ставку:" );
        string input = Console.ReadLine();
        int bet;
        if ( !int.TryParse( input, out bet ) || bet <= 0 || bet > _balance )
        {
            return -1;
        }
        return bet;
    }
    private static int CalculateWinAmount( int bet, int seed )
    {
        const int multiplicator = 25;
        int winPercent = multiplicator * ( seed % 17 );
        if ( winPercent <= 0 )
        {
            return 0;
        }
        if ( winPercent > 0 && bet > int.MaxValue / winPercent )
        {
            Console.WriteLine( "Переполнение! Слишком большой выигрыш" );
            return 0;
        }
        return bet * winPercent / 100;
    }
    private static void ShowBalance()
    {
        Console.WriteLine( $"Текущий баланс: {_balance}" );
    }
    private static OptionHandleResult MakeDeposit()
    {
        ShowBalance();
        Console.WriteLine( "Введите депозит:" );
        string input = Console.ReadLine();
        if ( !int.TryParse( input, out int deposit ) || deposit <= 0 )
        {
            return OptionHandleResult.InvalidDepositValue;
        }
        if ( int.MaxValue - deposit < _balance )
        {
            return OptionHandleResult.InvalidDepositValue;
        }
        _balance += deposit;
        return OptionHandleResult.Success;
    }
}