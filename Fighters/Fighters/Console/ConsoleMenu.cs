public static class ConsoleMenu
{
    public static string ReadCommand(
        string title,
        IReadOnlyList<MenuCommand> options )
    {
        ConsoleLogger.Print( title );
        foreach ( MenuCommand option in options )
        {
            ConsoleLogger.Print( $"  {option.Key}. {option.Description}" );
        }

        while ( true )
        {
            string input = Console.ReadLine();
            MenuCommand match = options.FirstOrDefault( o => o.Key.ToString() == input );
            if ( match != null && match.Command != null )
            {
                return match.Command;
            }
            ConsoleLogger.Print( "Неверный ввод. Попробуйте снова." );
        }
    }
    public static T Select<T>(
        string title,
        IReadOnlyList<T> items,
        Func<T, string> getName,
        int defaultValue = -1 )
    {
        ConsoleLogger.Print( title );
        for ( int i = 0; i < items.Count; i++ )
        {
            string marker = ( i == defaultValue ) ? " (по умолчанию)" : "";
            ConsoleLogger.Print( $"{i + 1}. {getName( items[ i ] )}{marker}" );
        }

        while ( true )
        {
            string input = Console.ReadLine();
            if ( string.IsNullOrEmpty( input ) && defaultValue >= 0 )
            {
                return items[ defaultValue ];
            }

            if ( int.TryParse( input, out int choice ) && choice >= 1 && choice <= items.Count )
            {
                return items[ choice - 1 ];
            }
            ConsoleLogger.Print( "Неверный ввод. Попробуйте снова." );
        }
    }
}
