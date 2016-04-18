using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            MainInterface menu = new MainInterface();
            bool runMachine = true;
            while (runMachine)
            {
                menu.mainMenu();
            }
        }
    }
}
