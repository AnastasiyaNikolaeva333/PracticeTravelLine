internal class Order
{
    private string name;
    private string product;
    private int productQuantity;
    private string address;

    public string Name
    {
        get => name;
        set => name = GoodValue( value, "Имя" );
    }
    public string Product
    {
        get => product;
        set => product = GoodValue( value, "Название товара" );
    }
    public int ProductQuantity
    {
        get => productQuantity;
        set
        {
            productQuantity = value > 0
                ? value
                : throw new ArgumentException( "Количество товара должно быть больше 0" );
        }
    }
    public string Address
    {
        get => address;
        set => address = GoodValue( value, "Адресс" );
    }

    private string GoodValue( string value, string identifier )
    {
        return !string.IsNullOrWhiteSpace( value )
            ? value
            : throw new ArgumentException( $"{identifier} не может быть пустым" );
    }
}