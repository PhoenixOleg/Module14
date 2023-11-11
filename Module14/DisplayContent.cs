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
            string input;

            //Рассчитываем минимальное количество записей на страницу из расчета, что максимальное количество страниц (почему-то, например, по ТЗ) равно 9
            int minRecordsPerPage = (int)Math.Ceiling((double)RecordsCount / 9.0);

            do
            {
                Console.Write($"Выберите количество отображаемых записей на страницу (минимум {minRecordsPerPage}) или 0 для выхода: ");
                input = Console.ReadLine();
            }
            while ((!Int32.TryParse(input, out recordsPerPage) && (recordsPerPage == 0)) || (recordsPerPage < minRecordsPerPage) && (recordsPerPage != 0)) ;
            
            if (recordsPerPage == 0)
            {
                Final.GoodBye(0, "");
            }

            settings.recordsPerPage = recordsPerPage;
            settings.maxPageNumber = (int)Math.Ceiling((double)RecordsCount / settings.recordsPerPage);

            return settings;
        }
    }
}
