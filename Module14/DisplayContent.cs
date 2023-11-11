using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Module14
{
    /// <summary>
    /// Структура с настройками форматирования страницы для отображения адресной книги 
    /// </summary>
    internal struct Settings
    {
        internal int recordsPerPage; //Количество записей на страницу для отображения
        internal int maxPageNumber; //Максимальное количество доступных страниц, исходя из значения recordsOnPage
    }

    /// <summary>
    /// Класс, реализующий настройку форматирования страницы с контентом и отображение контента адресной книги
    /// </summary>
    internal static class DisplayContent
    {
        /// <summary>
        /// Метод  форматирования страницы для отображения адресной книги 
        /// </summary>
        /// <param name="RecordsCount">Количество записей в адресной книги</param>
        /// <returns>Структура Settings с настройками форматирования отображения контента</returns>
        internal static Settings PrepareFormat(int RecordsCount)
        {
            Settings settings = new();
            int recordsPerPage;

            //Рассчитываем минимальное количество записей на страницу из расчета, что максимальное количество страниц (почему-то, например, по ТЗ) равно 9
            int minRecordsPerPage = (int)Math.Ceiling((double)RecordsCount / 9.0);

            bool res;
            do
            {
                Console.Write($"Выберите количество отображаемых записей на страницу (минимум {minRecordsPerPage}) или 0 для выхода: ");
                if ((!Int32.TryParse(Console.ReadLine(), out recordsPerPage) && (recordsPerPage == 0)) || (recordsPerPage < minRecordsPerPage) && (recordsPerPage != 0))
                {
                    Console.WriteLine("Значение задано неправильно\n");
                    res = true;
                }
                else
                { 
                    res = false;
                }
            }
            while (res);
            
            if (recordsPerPage == 0)
            {
                Final.GoodBye(0, "");
            }

            settings.recordsPerPage = recordsPerPage;
            settings.maxPageNumber = (int)Math.Ceiling((double)RecordsCount / settings.recordsPerPage);

            return settings;
        }

        /// <summary>
        /// Метод постраничного отображения адресной книги
        /// </summary>
        /// <param name="phoneBook">Адресная книга</param>
        /// <param name="settings">Настройки отображения</param>
        internal static void Show(List<Contact> phoneBook, Settings settings)
        {
            while (true)
            {
                // Читаем введенный с консоли символ
                Console.WriteLine($"Выберите номер страницы для отображения контента (от 1 до {settings.maxPageNumber}) или нажмите Esc для выхода");

                var input = Console.ReadKey(true).KeyChar; // Без параметра true подавляется первый символ в выводимой строке после нажатия Escape

                if (input == 27) //Если Escape - выходим
                {
                    Console.WriteLine();
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
