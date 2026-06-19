public class Program
{
    public static void Main()
    {
        Console.WriteLine("Можно сконструировать свой автомобиль, выбрав ту или иную конфигурацию");
        while (true)
        {
            char command = ConsoleMenu.ReadCommand(
                "Выберите команду:",
                new List<MenuCommand>()
                {
                    new MenuCommand { Key = '1', Description = "Собрать самому" },
                    new MenuCommand { Key = '2', Description = "Выбрать уже готовый автомобиль" },
                    new MenuCommand { Key = '3', Description = "Выйти" }
                });

            switch (command)
            {
                case '1':
                    {
                        ICar car = Designer.BuildYourOwn();
                        Console.WriteLine(car);
                    }
                    break;
                case '2':
                    {
                        ICar car = Response.ChoosePrebuiltCars();
                        Console.WriteLine(car);
                    }
                    break;
                case '3':
                    Console.WriteLine("Конструирование автомобиля завершено!");
                    return;
                default:
                    Console.WriteLine("Неверная команда. Попробуйте снова.");
                    break;
            }
        }
    }
}