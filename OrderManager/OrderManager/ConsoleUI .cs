internal class ConsoleUI
{
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
        int coutProduct;
        while ( string.IsNullOrWhiteSpace( input ) || !int.TryParse( input, out coutProduct ) )
        {
            Console.WriteLine( "\"Количество товара\" должено быть числом" );
            input = DeleteExtraSpaces( Console.ReadLine() );
        }
        return coutProduct;
    }
    private static string DeleteExtraSpaces( string input )
    {
        input = string.Join( " ", input.Split( ' ', StringSplitOptions.RemoveEmptyEntries ) );
        return input.Trim();
    }
}