using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module14
{
    internal struct Settings
    {
        internal int recordsPerPage;
        internal int maxPageNumber;
    }

    internal static class DisplayContent
    {
        internal static Settings PrepareFormat(int RecordsCount)
        {
            Settings settings = new();
            int recordsPerPage;

            //Рассчитываем минимальное количество записей на страницу из расчета, что максимальное количество страниц (почему-то, например, по ТЗ) равно 9
            int minRecordsPerPage = (int)Math.Ceiling((double)RecordsCount / 9.0);

            do
            {
                Console.Write($"Выберите количество отображаемых записей на страницу (минимум {minRecordsPerPage}) или 0 для выхода: ");
            }
            while ((!Int32.TryParse(Console.ReadLine(), out recordsPerPage) && (recordsPerPage == 0)) || (recordsPerPage < minRecordsPerPage) && (recordsPerPage != 0)) ;
            
            if (recordsPerPage == 0)
            {
                Final.GoodBye(0, "");
            }

            settings.recordsPerPage = recordsPerPage;
            settings.maxPageNumber = (int)Math.Ceiling((double)RecordsCount / settings.recordsPerPage);

            return settings;
        }

        internal static void Show(List<Contact> phoneBook, Settings settings)
        {
            while (true)
            {
                // Читаем введенный с консоли символ
                Console.WriteLine($"\nВыберите номер страницы для отображения контента (от 1 до {settings.maxPageNumber}) или нажмите Esc для выхода");

                var input = Console.ReadKey().KeyChar;

                if (input == 27) //Если Escape - выходим
                {
                    break;
                }

                // Проверяем, число ли это и если не соответствует критериям - показываем ошибку
                if (!Int32.TryParse(input.ToString(), out int pageNumber) || pageNumber < 1 || pageNumber > settings.maxPageNumber)
                {
                    Console.WriteLine("\nСтраницы не существует");
                }
                // если соответствует - запускаем вывод
                else
                {
                    // Сначала сортируем, затем пропускаем нужное количество элементов и берем 2 для показа на странице
                    var pageContent = phoneBook.OrderBy(x => x.Name).ThenBy(x => x.LastName).Skip((pageNumber - 1) * settings.recordsPerPage).Take(settings.recordsPerPage);
                    Console.WriteLine();

                    // выводим результат
                    foreach (var entry in pageContent)
                        Console.WriteLine(entry.Name + " " + entry.LastName + ": " + entry.PhoneNumber);

                    Console.WriteLine();
                }
            }

        }
    }
}
