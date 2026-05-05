internal class Program
{
    private static double _balance = 0;
    private static Dictionary<OptionHandleResult, string> messageError = new()
    {
        [ OptionHandleResult.InvaliedOption ] = "Неправильный вариант управления. Только от 1-4",
        [ OptionHandleResult.InvaliedDepositValue ] = "Невалидное значение депозита",
        [ OptionHandleResult.InvaliedBet ] = "Невалидная ставка. Только от 1 до баланса",
        [ OptionHandleResult.InvaliedBalance ] = "Баланс слишком маленький. Пополните его."
    };
    private enum OptionHandleResult
    {
        Success = 0,
        InvaliedOption = 1,
        InvaliedDepositValue = 2,
        InvaliedBet = 3,
        InvaliedBalance = 4,
        End = 5
    };
    private static void Main( string[] args )
    {
        PrintHeader();
        bool endGame = false;
        while ( !endGame )
        {
            PrintMenu();
            string option = Console.ReadLine();
            OptionHandleResult result = HandleOption( option );
            if ( result != OptionHandleResult.Success )
            {
                Console.WriteLine( messageError[ result ] );
            }
            else if ( result == OptionHandleResult.End )
            {
                endGame = true;
            }
        }
    }
    private static void PrintHeader()
    {
        const string header = "Casino";
        Console.WriteLine( header );
    }
    private static void PrintMenu()
    {
        List<string> menuOptions = [
            "1. Пополнить баланс",
            "2. Показать баланс",
            "3. Сыграть",
            "4. Выйти"
            ];
        foreach ( string option in menuOptions )
        {
            Console.WriteLine( option );
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
                return OptionHandleResult.InvaliedOption;
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
            return OptionHandleResult.InvaliedBalance;
        }
        ShowBalance();
        Console.WriteLine( "Введите ставку:" );
        string betStr = Console.ReadLine();
        int bet;
        if ( !int.TryParse( betStr, out bet ) || bet <= 0 || bet > _balance )
        {
            return OptionHandleResult.InvaliedBet;
        }

        int seed = Random.Shared.Next( 1, 21 );
        Console.WriteLine( seed );
        if ( seed >= 18 && seed <= 20 )
        {
            int winAmout = CalculateWinAmount( bet, seed );
            _balance += winAmout;
            Console.WriteLine( "Вы выйграли!!!" );
            ShowBalance();
        }
        else
        {
            _balance -= bet;
            Console.WriteLine( "Вы проиграли(((" );
            ShowBalance();
        }
        return OptionHandleResult.Success;
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
        string denositStr = Console.ReadLine();
        if ( !int.TryParse( denositStr, out int deposit ) || deposit <= 0 )
        {
            return OptionHandleResult.InvaliedDepositValue;
        }
        if ( int.MaxValue - deposit < _balance )
        {
            return OptionHandleResult.InvaliedDepositValue;
        }
        _balance += deposit;
        return OptionHandleResult.Success;
    }
}