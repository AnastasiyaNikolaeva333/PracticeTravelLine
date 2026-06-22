public class ConsoleMenu
{
    private readonly IInputProvider _input;
    private readonly IOutputProvider _output;
    public ConsoleMenu( IInputProvider input, IOutputProvider output )
    {
        _input = input;
        _output = output;
    }
    public string ReadCommand(
        string title,
        IReadOnlyList<MenuCommand> options )
    {
        _output.Print( title );
        foreach ( MenuCommand option in options )
        {
            _output.Print( $"  {option.Key}. {option.Description}" );
        }

        while ( true )
        {
            string input = _input.ReadLine();
            MenuCommand match = options.FirstOrDefault( o => o.Key.ToString() == input );
            if ( match != null && match.Command != null )
            {
                return match.Command;
            }
            _output.Print( "Неверный ввод. Попробуйте снова." );
        }
    }
    public T Select<T>(
        string title,
        IReadOnlyList<T> items,
        Func<T, string> getName,
        int defaultValue = -1 )
    {
        _output.Print( title );
        for ( int i = 0; i < items.Count; i++ )
        {
            string marker = ( i == defaultValue ) ? " (по умолчанию)" : "";
            _output.Print( $"{i + 1}. {getName( items[ i ] )}{marker}" );
        }

        while ( true )
        {
            string input = _input.ReadLine();
            if ( string.IsNullOrEmpty( input ) && defaultValue >= 0 )
            {
                return items[ defaultValue ];
            }

            if ( int.TryParse( input, out int choice ) && choice >= 1 && choice <= items.Count )
            {
                return items[ choice - 1 ];
            }
            _output.Print( "Неверный ввод. Попробуйте снова." );
        }
    }
}