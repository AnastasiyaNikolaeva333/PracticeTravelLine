public static class ConsoleMenu
{
    public static char ReadCommand(
        string title,
        IReadOnlyList<MenuCommand> options )
    {
        Console.WriteLine( title );
        foreach ( MenuCommand option in options )
        {
            Console.WriteLine( $"  {option.Key}. {option.Description}" );
        }

        while ( true )
        {
            string input = Console.ReadLine();
            MenuCommand match = options.FirstOrDefault( o => o.Key.ToString() == input );
            if ( match != null )
            {
                return match.Key;
            }
            Console.WriteLine( "Неверный ввод. Попробуйте снова." );
        }
    }
    public static T Select<T>(
        string title,
        IReadOnlyList<T> items,
        Func<T, string> getName )
    {
        Console.WriteLine( title );
        for ( int i = 0; i < items.Count; i++ )
        {
            Console.WriteLine( $"{i + 1}. {getName( items[ i ] )}" );
        }

        while ( true )
        {
            string input = Console.ReadLine();
            if ( int.TryParse( input, out int choice ) && choice >= 1 && choice <= items.Count )
            {
                return items[ choice - 1 ];
            }
            Console.WriteLine( "Неверный ввод. Попробуйте снова." );
        }
    }
}
