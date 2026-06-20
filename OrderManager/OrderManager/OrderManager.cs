internal class OrderManager
{
    private const int DeliveryDays = 3;
    public static void CreateOrder()
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
        Console.WriteLine( PlaceOrder( order ) );
    }

    public static string PlaceOrder( Order order )
    {
        DateTime deliveryDate = DateTime.Today.AddDays( DeliveryDays );
        return !ConsoleUI.IsOrderAgreed( order )
            ? "Заказ отменён"
            : $"\n{order.Name}! Ваш заказ {order.Product} в количестве {order.ProductQuantity} " +
            $"оформлен! Ожидайте доставку по адресу {order.Address} к {deliveryDate:d}";
    }
}