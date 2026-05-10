public class Response
{
    public static string GetResponseFromUser()
    {
        string response = Console.ReadLine();
        while ( string.IsNullOrWhiteSpace( response ) )
        {
            Console.WriteLine( "Ввод пустой. Введите ещё раз." );
            response = Console.ReadLine();
        }
        return response.Trim();
    }
}