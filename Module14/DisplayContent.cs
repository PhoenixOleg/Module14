using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module14
{
    internal struct Settings
    {
        internal static readonly int recordsOnPage;
    }
    internal class DisplayContent
    {
        internal static int PrepareFormat(int RecordsCount, int recordsOnPage)
        {
            //Рассчитываем минимальное количество записей на страницу из расчета, что максимальное количество страниц (почему-то, например, по ТЗ) равно 9
            int minRecordsOnPage = (int)Math.Ceiling((double)RecordsCount / 9.0);

            do
            {
                Console.Write($"Выберите количество отображаемых записей на страницу (минимум {minRecordsOnPage}): ");
            }
            while (!Int32.TryParse(Console.ReadLine(), out recordsOnPage) || (recordsOnPage < minRecordsOnPage));

            return (int)Math.Ceiling((double)RecordsCount / recordsOnPage);
        }
    }
}
