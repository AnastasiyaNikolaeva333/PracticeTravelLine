class Program
{
    public static void Main()
    {
        Order order = new Order();
        bool isAllDataRequest = false;
        while ( !isAllDataRequest )
        {
            try
            {
                ConsoleUI.RequestDataFromUser( order );
                isAllDataRequest = true;
            }
            catch ( ArgumentException ex )
            {
                Console.WriteLine( $"Ошибка: {ex.Message}" );
            }
        }
        Console.WriteLine( order );
    }
}