using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module14
{
    /// <summary>
    /// Класс завершения работы приложения
    /// </summary>
    internal class Final
    {
        /// <summary>
        /// Метод выхода из приложения
        /// </summary>
        /// <param name="exitCode">Код выхода</param>
        /// <param name="msg">Сообщение в консоль в случае ошибки (когда код выхода не равен 0)</param>
        internal static void GoodBye(int exitCode, string msg)
        {
            if (exitCode != 0)
            {
                Console.WriteLine(msg);
            }
            System.Environment.Exit(exitCode);
        }
    }
}
