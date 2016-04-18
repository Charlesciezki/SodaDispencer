using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMaker
{
    public class SodaMachine
    {
        //ORANGE SODA IS [0] MEAT SODA IS [1] GRAPE IS [2]
        //QUARTERS=[0] DIMES=[1] NICKELS=[2] PENNYS=[3]

        public List<List<Can>> machineInventory = new List<List<Can>>();

        public List<List<Coin>> machineRegister = new List<List<Coin>>();

        public Quarter quarter = new Quarter();
        public Dime dime = new Dime();
        public Nickel nickel = new Nickel();
        public Penny penny = new Penny();

        public OrangeCan orangeSoda = new OrangeCan();
        public GrapeCan grapeSoda = new GrapeCan();
        public MeatCan meatSoda = new MeatCan();

        public int quarters;
        public int dimes;
        public int nickels;
        public int pennys;
        public double totalchange;
        public SodaMachine()
        {
            spawnCans();
            spawnCoins();
        }
        private void spawnCoins()
        {
            List<Coin> quarters = new List<Coin>();
            List<Coin> dimes = new List<Coin>();
            List<Coin> nickels = new List<Coin>();
            List<Coin> pennys = new List<Coin>();
            machineRegister.Add(quarters);
            machineRegister.Add(dimes);
            machineRegister.Add(nickels);
            machineRegister.Add(pennys);

            for (int i = 0; i < 20; i++)
            {
                machineRegister[0].Add(quarter);
                machineRegister[2].Add(nickel);
            }
            for (int i = 0; i < 10; i++)
            {
                machineRegister[1].Add(dime);
            }
            for (int i = 0; i < 50; i++)
            {
                machineRegister[3].Add(penny);
            }
        }
        private void spawnCans()
        {
        List<Can> grapeSodaList = new List<Can>();
        List<Can> orangeSodaList = new List<Can>();
        List<Can> meatSodaList = new List<Can>();

            machineInventory.Add(orangeSodaList); // [0][x]
            machineInventory.Add(meatSodaList); // [1][x]
            machineInventory.Add(grapeSodaList); // [2][x]
            for (int i = 0; i < 15; i++)
            {
                machineInventory[0].Add(orangeSoda);
                machineInventory[1].Add(meatSoda);
                machineInventory[2].Add(grapeSoda);
            }
        }
        public void checkSodas()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("You have " + machineInventory[0].Count + " cans of orange left! Selling at $.35");
            Console.WriteLine("You have " + machineInventory[2].Count + " cans of grape left! Selling at $.60");
            Console.WriteLine("You have " + machineInventory[1].Count + " cans of meat left! Selling at $.06");
        }
        public void checkCoins()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            double quarterTotal = (machineRegister[0].Count * .25);
            double dimeTotal = (machineRegister[1].Count * .1);
            double nickelTotal = (machineRegister[2].Count * .05);
            double pennyTotal = (machineRegister[3].Count * .01);
            Console.WriteLine("You have $" + quarterTotal + " in quarters!");
            Console.WriteLine("You have $" + dimeTotal + " in dimes!");
            Console.WriteLine("You have $" + nickelTotal + " in nickels!");
            Console.WriteLine("You have $" + pennyTotal + " in pennys!");
        }
        public int buySoda()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to SodaCode!");
            Console.WriteLine("What will you buy today?");
            checkSodas();
            Console.ForegroundColor = ConsoleColor.Yellow;
            string sodaChoice = Console.ReadLine().ToLower();
            if (sodaChoice == "grape")
            {
                buyGrapeSoda();
            } else if (sodaChoice == "orange")
            {
                buyOrangeSoda();
            } else if (sodaChoice == "meat")
            {
                buyMeatSoda();
            } else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR!");
                return buySoda();
            }
            return 1;
        }
        public int buyGrapeSoda()
        {
            Console.ForegroundColor = ConsoleColor.Blue;          
            Console.WriteLine("You have " + machineInventory[2].Count + " grape sodas left");
            Console.WriteLine("Grape soda costs $.60 per can");
            Console.WriteLine("How many quarters will you put in?");
            quarters = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many dimes will you put in?");
            dimes = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many nickels will you put in?");
            nickels = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many pennys will you put in?");
            pennys = Convert.ToInt32(Console.ReadLine());
            double totalCoins = (quarters * .25) + (dimes * .1) + (nickels * .05) + (pennys * .01);
            Console.WriteLine("You put in $" + totalCoins);
            if (totalCoins > 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("BZZT! ERROR! CANNOT ACCEPT OVER $1");
                Console.WriteLine("CLUNK! Your change was returned!");
                return 1;
            }
            if (machineInventory[2].Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Out of stock! Sorry!");
                Console.WriteLine("CLUNK! Your money was returned!");
                return 1;
            }
            if (totalCoins == grapeSoda.value)
            {
                Console.WriteLine("You put in exact change");
                for (int i = 0; i < quarters; i++)
                {
                    machineRegister[0].Add(quarter);
                }
                for (int i = 0; i < dimes; i++)
                {
                    machineRegister[1].Add(dime);
                }
                for (int i = 0; i < nickels; i++)
                {
                    machineRegister[2].Add(nickel);
                }
                for (int i = 0; i < pennys; i++)
                {
                    machineRegister[3].Add(penny);
                }
                Console.WriteLine("CLUNK! A grape soda dispenced!");
                machineInventory[2].RemoveAt(0);
            } else if (totalCoins > grapeSoda.value)
            {
                totalchange = (totalCoins - grapeSoda.value);
                Console.WriteLine("You need $" + totalchange + " back!");
                giveChange(totalchange);
                Console.WriteLine("CLUNK You get your grape soda!");
                machineInventory[2].RemoveAt(0);
            } else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You put too little in!");
                Console.WriteLine("CLUNK! You get your coins back!");
                return buyGrapeSoda();
            }
            return 1;
        }
        public int buyOrangeSoda()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("You have " + machineInventory[0].Count + " orange sodas left");
            Console.WriteLine("Orange soda costs $.35 per can");
            Console.WriteLine("How many quarters will you put in?");
            quarters = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many dimes will you put in?");
            dimes = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many nickels will you put in?");
            nickels = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many pennys will you put in?");
            pennys = Convert.ToInt32(Console.ReadLine());
            double totalCoins = (quarters * .25) + (dimes * .1) + (nickels * .05) + (pennys * .01);
            Console.WriteLine("You put in $" + totalCoins);
            if (totalCoins > 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("BZZT! ERROR! CANNOT ACCEPT OVER $1");
                Console.WriteLine("CLUNK! Your change was returned!");
                return 1;
            }
            if (machineInventory[0].Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Out of stock! Sorry!");
                Console.WriteLine("CLUNK! Your money was returned!");
                return 1;
            }
            if (totalCoins == orangeSoda.value)
            {
                Console.WriteLine("You put in exact change");
                for (int i = 0; i < quarters; i++)
                {
                    machineRegister[0].Add(quarter);
                }
                for (int i = 0; i < dimes; i++)
                {
                    machineRegister[1].Add(dime);
                }
                for (int i = 0; i < nickels; i++)
                {
                    machineRegister[2].Add(nickel);
                }
                for (int i = 0; i < pennys; i++)
                {
                    machineRegister[3].Add(penny);
                }
                Console.WriteLine("CLUNK! A orange soda dispenced!");
                machineInventory[0].RemoveAt(0);
            }
            else if (totalCoins > orangeSoda.value)
            {
                totalchange = (totalCoins - orangeSoda.value);
                Console.WriteLine("You need $" + totalchange + " back!");
                giveChange(totalchange);
                Console.WriteLine("CLUNK You get your orange soda!");
                machineInventory[0].RemoveAt(0);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You put too little in!");
                Console.WriteLine("CLUNK! You get your coins back!");
                return buyOrangeSoda();
            }
            return 1;
        }
        public int buyMeatSoda()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You have " + machineInventory[1].Count + " meat sodas left");
            Console.WriteLine("Meat soda costs $.06 per can:");
            Console.WriteLine("How many quarters will you put in?");
            quarters = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many dimes will you put in?");
            dimes = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many nickels will you put in?");
            nickels = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many pennys will you put in?");
            pennys = Convert.ToInt32(Console.ReadLine());
            double totalCoins = (quarters * .25) + (dimes * .1) + (nickels * .05) + (pennys * .01);
            Console.WriteLine("You put in $" + totalCoins);
            if (totalCoins > 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("BZZT! ERROR! CANNOT ACCEPT OVER $1");
                Console.WriteLine("CLUNK! Your change was returned!");
                return 1;
            }
            if (machineInventory[1].Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Out of stock! Sorry!");
                Console.WriteLine("CLUNK! Your money was returned!");
                return 1;
            }
            if (totalCoins == meatSoda.value)
            {
                Console.WriteLine("You put in exact change");
                for (int i = 0; i < quarters; i++)
                {
                    machineRegister[0].Add(quarter);
                }
                for (int i = 0; i < dimes; i++)
                {
                    machineRegister[1].Add(dime);
                }
                for (int i = 0; i < nickels; i++)
                {
                    machineRegister[2].Add(nickel);
                }
                for (int i = 0; i < pennys; i++)
                {
                    machineRegister[3].Add(penny);
                }
                Console.WriteLine("CLUNK! A meat soda dispenced!");
                machineInventory[1].RemoveAt(0);
            }
            else if (totalCoins > meatSoda.value)
            {
                totalchange = (totalCoins - meatSoda.value);
                machineInventory[1].RemoveAt(0);
                Console.WriteLine("You need $" + totalchange + " back!");
                giveChange(totalchange);
                Console.WriteLine("CLUNK You get your meat soda!");
                
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You put too little in!");
                Console.WriteLine("CLUNK! You get your coins back!");
                return buyMeatSoda();
            }
            return 1;
        }
        public void giveChange(double TotalChange)
        {
            totalchange = TotalChange;
            if (machineRegister[0].Count == 0 && machineRegister[1].Count == 0 && machineRegister[2].Count == 0 && machineRegister[3].Count == 0)
            {
                Console.WriteLine("No more change!");
                
            }
            while(totalchange > quarter.value && machineRegister[0].Count > 0)
            {
                totalchange = totalchange - quarter.value;
                machineRegister[0].RemoveAt(0);
            }
            while (totalchange > dime.value && machineRegister[1].Count > 0)
            {
                totalchange = totalchange - dime.value;
                machineRegister[1].RemoveAt(0);
            }
            while (totalchange > nickel.value && machineRegister[2].Count > 0)
            {
                totalchange = totalchange - nickel.value;
                machineRegister[2].RemoveAt(0);
            }
            while (totalchange > penny.value && machineRegister[3].Count > 0)
            {
                totalchange = totalchange - penny.value;
                machineRegister[3].RemoveAt(0);
            }
            Console.WriteLine("CLUNK! You get your change back");
        }
        }
    }
