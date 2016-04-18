using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMaker
{
    public class SodaMachine
    {
        //Using proper code design, write a SodaMachine class that accepts coins as payment, returns coins from its limited register as change, and dispenses soda cans from its limited inventory.
        //Make a class for each coin(penny, nickel, dime, quarter) that sets its value in its constructor.Allow payment via passing a List of coins into a public function on the SodaMachine class.
        //If not enough money is passed in, don't complete transaction: give the money back
        //If exact change is passed in, accept payment and dispense a soda from the limited inventory.
        //If too much money is passed in, accept the payment, return change as a list of coins from internal, limited register, and return a soda instance from internal, limited inventory.
        //If too much money is passed in but there isn't sufficient change in the machine's internal register, don't complete transaction: give the money back
        //If exact or too much money is passed in but there isn't sufficient inventory for that soda, don't complete the transaction: give the money back

        //The machine should start with:
        //Coins: 20 quarters, 10 dimes, 20 nickels, 50 pennies
        //Cans: Grape-flavored(60¢ per), Orange-flavored(35¢ per), Meat-flavored(6¢ per)
        public List<Can> machineInventory = new List<Can>();
        public List<Coin> machineRegister = new List<Coin>();
        
        
        public SodaMachine()
        {
            spawnCans();
            spawnCoins();
        }
        private void spawnCoins()
        {
            for (int i = 0; i < 20; i++)
            {
                machineRegister.Add(new Quarter());
                machineRegister.Add(new Nickel());
            }
            for (int i = 0; i < 10; i++)
            {
                machineRegister.Add(new Dime());
            }
            for (int i = 0; i < 50; i++)
            {
                machineRegister.Add(new Penny());
            }
        }
        private void spawnCans()
        {
            for (int i = 0; i < 15; i++)
            {
                machineInventory.Add(new OrangeCan());
                machineInventory.Add(new MeatCan());
                machineInventory.Add(new GrapeCan());
            }
        }
        public void checkSodas()
        {
            int orangeCount=0;
            int grapeCount=0;
            int meatCount=0;
            foreach (Can can in machineInventory)
            {
                if (can.flavor.Equals("Orange"))
                {
                    orangeCount++;
                }else if (can.flavor.Equals("Grape"))
                {
                    grapeCount++;
                } else
                {
                    meatCount++;
                }
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("You have " + orangeCount + " cans of orange left!");
            Console.WriteLine("You have " + grapeCount + " cans of grape left!");
            Console.WriteLine("You have " + meatCount + " cans of meat left!");
        }
        public void checkCoins()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            int quarterCount=0;
            int dimeCount = 0;
            int nickelCount = 0;
            int pennyCount = 0;

            foreach (Coin coin in machineRegister)
            {
                if (coin.value.Equals(.25))
                {
                    quarterCount++;
                } else if (coin.value.Equals(.1))
                {
                    dimeCount++;
                } else if (coin.value.Equals(.05))
                {
                    nickelCount++;
                } else
                {
                    pennyCount++;
                }
            }
            double quarterTotal = (quarterCount * .25);
            double dimeTotal = (dimeCount * .1);
            double nickelTotal = (nickelCount * .05);
            double pennyTotal = (pennyCount * .01);
            Console.WriteLine("You have $" + quarterTotal + " in quarters!");
            Console.WriteLine("You have $" + dimeTotal + " in dimes!");
            Console.WriteLine("You have $" + nickelTotal + " in nickels!");
            Console.WriteLine("You have $" + pennyTotal + " in pennys!");
        }
        }
    }
