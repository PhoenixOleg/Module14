using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module14
{
    internal class Final
    {
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
