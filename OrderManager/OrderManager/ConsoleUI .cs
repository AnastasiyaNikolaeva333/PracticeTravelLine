internal class ConsoleUI
{
    private const string AnswerYes = "y";
    private const string AnswerNo = "n";
    public static void RequestDataFromUser( Order order )
    {
        Console.WriteLine( "Введите имя пользователя:" );
        order.Name = DeleteExtraSpaces( Console.ReadLine() );

        Console.WriteLine( "Введите название товара:" );
        order.Product = DeleteExtraSpaces( Console.ReadLine() );

        Console.WriteLine( "Введите количество товара:" );
        order.ProductQuantity = GetInputInt();

        Console.WriteLine( "Введите aдрес доставки:" );
        order.Address = DeleteExtraSpaces( Console.ReadLine() );
    }
    private static int GetInputInt()
    {
        string input = DeleteExtraSpaces( Console.ReadLine() );
        int cout;
        while ( string.IsNullOrWhiteSpace( input ) || !int.TryParse( input, out cout ) )
        {
            Console.WriteLine( "Пункт количества товара должен быть числом" );
            input = DeleteExtraSpaces( Console.ReadLine() );
        }
        return cout;
    }
    private static string DeleteExtraSpaces( string str )
    {
        str = string.Join( " ", str.Split( ' ', StringSplitOptions.RemoveEmptyEntries ) );
        return str.Trim();
    }

    public static bool IsOrderAgreed( Order order )
    {
        Console.WriteLine( $"\nЗдравствуйте, {order.Name}, вы заказали {order.ProductQuantity} " +
            $"{order.Product} на адрес {order.Address}, все верно?(y/n)" );

        string answer = ( Console.ReadLine() ).ToLower();
        while ( !( answer == AnswerYes || answer == AnswerNo ) )
        {
            Console.WriteLine( "Все верно?(y/n)" );
            answer = ( Console.ReadLine() ).ToLower();
        }
        return answer == AnswerYes;
    }
}