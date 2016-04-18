using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SodaMaker
{
    public class MainInterface
    {
        //look at menu
        //see how much change is in register
        //se how many cans are in machine
        public SodaMachine sodaMachine = new SodaMachine(); 
        public void mainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to SodaCode!");
            Console.WriteLine("Enter 1 to buy a soda!");
            Console.WriteLine("Enter 2 to check sodas in inventory!");
            Console.WriteLine("Enter 3 to check change register!");
            Console.WriteLine("Enter 4 to check your wallet amount!");
            Console.WriteLine("Enter 5 to exit!");
            int menuChoice = Convert.ToInt32(Console.ReadLine());
            switch (menuChoice)
            {
                case 1:
                    Console.Clear();
                    
                    break;
                case 2:
                    Console.Clear();
                    sodaMachine.checkSodas();
                    break;
                case 3:
                    Console.Clear();
                    sodaMachine.checkCoins();
                    break;
                case 4:
                    Console.Clear();
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Come back soon!");
                    for(int i = 0; i < 10; i++)
                    {
                        Thread.Sleep(200);
                        Console.Write(". ");
                    }                    
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
