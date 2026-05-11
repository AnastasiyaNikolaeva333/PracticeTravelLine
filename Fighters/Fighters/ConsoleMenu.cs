using System;
using System.Collections.Generic;
using System.Linq;

namespace Fighters.Fighters
{
    public static class ConsoleMenu
    {
        public static string ReadCommand(
            string title,
            IReadOnlyList<(char Key, string Command, string Description)> options)
        {
            Console.WriteLine(title);
            foreach (var option in options)
            {
                Console.WriteLine($"  {option.Key}. {option.Description}");
            }
            
            while (true)
            {
                string input = Console.ReadLine();
                var match = options.FirstOrDefault(o => o.Key.ToString() == input);
                if (match.Command != null)
                {
                    return match.Command;
                }
                Console.WriteLine("Неверный ввод. Попробуйте снова.");
            }
        }

        public static T Select<T>(
            string title,
            IReadOnlyList<T> items,
            Func<T, string> getName,
            int defaultValue = -1)
        {
            Console.WriteLine(title);
            for (int i = 0; i < items.Count; i++)
            {
                string marker = (i == defaultValue) ? " (по умолчанию)" : "";
                Console.WriteLine($"{i + 1}. {getName(items[i])}{marker}");
            }
            
            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input) && defaultValue >= 0)
                {
                    return items[defaultValue];
                }
                
                if (int.TryParse(input, out int choice) && choice >= 1 && choice <= items.Count)
                {
                    return items[choice - 1];
                }
                Console.WriteLine("Неверный ввод. Попробуйте снова.");
            }
        }
    }
}
