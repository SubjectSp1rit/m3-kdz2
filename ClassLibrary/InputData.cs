using System.IO;

namespace ClassLibrary
{
    public class InputData
    {
        /// <summary>
        /// Ввод пути к файлу
        /// </summary>
        /// <returns>Строка - путь до файла</returns>
        public static string? GetFilePath()
        {
            Console.Write("Введите путь до файла: ");
            string? path = Console.ReadLine();

            while (true)
            {
                if (!IsValidPath(path))
                {
                    Console.Write("Неправильный путь! Введите путь снова: ");
                    path = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }

            return path;
        }

        /// <summary>
        /// Проверяет путь на корректность
        /// </summary>
        /// <param name="path">Строка, содержащая путь</param>
        /// <returns>True - путь корректен; иначе false</returns>
        private static bool IsValidPath(string? path)
        {
            char[] invalidPathChars = Path.GetInvalidPathChars();

            if (path == null) return false;
            foreach (char c in invalidPathChars)
            {
                if (path.Contains(c))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Проверят название файла на корректность
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <returns>True - имя файла корректно; иначе false</returns>
        private static bool IsValidFileName(string? fileName)
        {
            char[] invalidFileNameChars = Path.GetInvalidFileNameChars();

            if (fileName == null) return false;
            foreach (char c in invalidFileNameChars)
            {
                if (fileName.Contains(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}