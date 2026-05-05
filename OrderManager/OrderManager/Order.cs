internal class Order
{
    private string _name;
    private string _product;
    private int _productQuantity;
    private int _deliveryDays;
    private string _address;
    private const string AnswerYes = "y";
    private const string AnswerNo = "n";

    public Order( int deliveryDays = 3 )
    {
        _deliveryDays = deliveryDays;
    }
    public string Name
    {
        get => _name;
        set
        {
            _name = ValidateInput(
            value,
            v => !string.IsNullOrWhiteSpace( value ),
            "Имя не может быть пустым"
            );
        }
    }
    public string Product
    {
        get => _product;
        set => _product = ValidateInput(
            value,
            v => !string.IsNullOrWhiteSpace( value ),
            "Название товара не может быть пустым" );
    }
    public int ProductQuantity
    {
        get => _productQuantity;
        set
        {
            _productQuantity = ValidateInput(
                value,
                v => value > 0,
                "Количество товара не может быть меньше 1" );
        }
    }
    public string Address
    {
        get => _address;
        set => _address = ValidateInput(
            value,
            v => !string.IsNullOrWhiteSpace( value ),
            "Адресс не может быть пустым" );
    }
    private T ValidateInput<T>( T value, Func<T, bool> check, string errorMessage )
    {
        return check( value ) ? value : throw new ArgumentException( errorMessage );
    }
    public override string ToString()
    {
        DateTime deliveryDate = DateTime.Today.AddDays( _deliveryDays );
        return IsOrderСonfirmed()
            ? $"{_name}! Ваш заказ {_product} в количестве {_productQuantity} " +
               $"оформлен! Ожидайте доставку по адресу {Address} к {deliveryDate:d}"
               : "Заказ отменён";
    }
    private bool IsOrderСonfirmed()
    {
        Console.WriteLine( $"\nЗдравствуйте, {_name}, вы заказали {_productQuantity} " +
            $"{_product} на адрес {Address}, все верно?(y/n)" );

        string answer = ( Console.ReadLine() ).ToLower();
        while ( !( answer == AnswerYes || answer == AnswerNo ) )
        {
            Console.WriteLine( "Все верно?(y/n)" );
            answer = ( Console.ReadLine() ).ToLower();
        }
        return answer == AnswerYes;
    }
}