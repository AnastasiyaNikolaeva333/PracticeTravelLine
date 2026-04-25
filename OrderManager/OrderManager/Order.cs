class Order
{
    private record DataOrder(string Name, string Product, int Count, string Address);
    private const int deliveryDays = 3;

    public static void Main()
    {
        DataOrder order = RequestDataFromUser();

        if (!IsOrderAgreed(order))
        {
            Console.WriteLine("Заказ отменён");
            return;
        }

        DateTime deliveryDate = DateTime.Today.AddDays(deliveryDays);
        Console.WriteLine($"\n{order.Name}! Ваш заказ {order.Product} в количестве {order.Count} " +
            $"оформлен! Ожидайте доставку по адресу {order.Address} к {deliveryDate:d}");
    }

    private static DataOrder RequestDataFromUser()
    {
        Console.WriteLine("Введите имя пользователя:");
        string name = GetInputString();

        Console.WriteLine("Введите название товара:");
        string product = GetInputString();

        Console.WriteLine("Введите количество товара:");
        int count = GetInputInt();

        Console.WriteLine("Введите aдрес доставки:");
        string address = GetInputString();

        return new DataOrder(name, product, count, address);
    }

    private static bool IsOrderAgreed(DataOrder order)
    {
        Console.WriteLine($"\nЗдравствуйте, {order.Name}, вы заказали {order.Count} " +
            $"{order.Product} на адрес {order.Address}, все верно?(y/n)");

        string answer = (Console.ReadLine() ?? "").ToLower();
        while (!(answer == "y" || answer == "n"))
        {
            Console.WriteLine("Все верно?(y/n)");
            answer = (Console.ReadLine() ?? "").ToLower();
        }
        return answer == "y";
    }
    private static int GetInputInt()
    {
        string input = Console.ReadLine() ?? "";
        int num;
        while (string.IsNullOrWhiteSpace(input)
            || !int.TryParse(input, out num)
            || num <= 0)
        {
            Console.WriteLine("Вы должны ввести число, которое будет больше 0.");
            input = Console.ReadLine() ?? "";
        }
        return num;
    }

    private static string GetInputString()
    {
        string input = Console.ReadLine() ?? "";
        while (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Ввод не может быть пустым.");
            input = Console.ReadLine() ?? "";
        }
        return DeleteExtraSpaces(input);
    }

    private static string DeleteExtraSpaces(string str)
    {
        return string.Join(" ", str.Split(' ', StringSplitOptions.RemoveEmptyEntries));
    }
}