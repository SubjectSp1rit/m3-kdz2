namespace ClassLibrary
{
    /// <summary>
    /// Выводит данные в консоль
    /// </summary>
    public class OutputData
    {
        /// <summary>
        /// Главное меню
        /// </summary>
        /// <returns>Число - НОМЕР нажатой кнопки</returns>
        public static int MainMenu()
        {
            // Элементы главного меню.
            string[] menuItems = { "1. Ввести путь до файла с данными.",
                                   "2. Завершить работу."
            };
            int selectedIndex = 0;
            ConsoleKey keyPressed;

            // Пользователь перемещается по меню стрелочками вверх и вниз, нажатием Enter выбирает пункт меню.
            do
            {
                Console.Clear();
                Console.WriteLine("=====================================================================");
                Console.WriteLine("|                       МЕНЮ ВЫБОРА ДЕЙСТВИЙ                        |");
                Console.WriteLine("=====================================================================");
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("> ");
                        Console.Write(menuItems[i]);
                        Console.WriteLine(" < ");
                        Console.ResetColor();
                        continue;
                    }
                    Console.Write("  ");
                    Console.WriteLine(menuItems[i]);
                    Console.ResetColor();
                }

                Console.WriteLine("=====================================================================");

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                keyPressed = keyInfo.Key;

                // Обрабатываем нажатые пользователем кнопки.

                // Двигаемся вверх по меню при нажатой стрелочке вверх.
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex < 0)
                    {
                        selectedIndex = menuItems.Length - 1;
                    }
                }
                // Двигаемся вниз по меню при нажатой стрелочке вниз.
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex >= menuItems.Length)
                    {
                        selectedIndex = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);

            // Возвращаем номер нажатой кнопки (индекс + 1)
            Console.Clear();
            return selectedIndex + 1;
        }
    }
}
