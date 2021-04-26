using System;
using System.Windows.Input;
using CommandLine;
using HenrysLib;

namespace Henrys
{
    class Program
    {
        private static Basket _basket = new Basket();

        static void Main(string[] args)
        {
            Console.WriteLine("Control-C to quit");
            while (true)
            {
                Console.Write("Enter Command: ");
                args = Console.ReadLine()?.Split(" ");
                //ParserResult<ICommand> parserResult =
                Parser.Default.ParseArguments<CostCommand, ApplesCommand, BreadCommand, SoupCommand, BreadCommand, DateCommand>(args)
                    .WithParsed<Program.ICommand>(t => t.Execute());

            }
        }

        interface ICommand
        {
            void Execute();
        }

            [Verb("date", HelpText = "Display or set the basket sale date")]
        public class DateCommand : ICommand
        {
            [Option('s',"date", HelpText = "Set the sale date of the basket")]
            public String Date { get; set; }

            [Option('c',"count", HelpText = "Add or subtract days from the sale date")]
            public int? Count { get; set; }
            public void Execute()
            {
                if (Count != null)
                {
                  _basket.DateOfSale = _basket.DateOfSale.AddDays((int) Count);
                }
                if (string.IsNullOrEmpty(Date))
                {
                    Console.WriteLine("Sale Date: " + _basket.DateOfSale);
                }
                else
                {
                    try
                    {
                        var date = DateTime.Parse(Date);
                        _basket.DateOfSale = date.Date;
                        Console.WriteLine("Sale Date: " + _basket.DateOfSale);
                    
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Invalid sale date");
                    }
                }

            }
        }

        [Verb("cost", HelpText = "Display the current cost of the basket")]
        public class CostCommand : ICommand
        {
            public void Execute()
            {
                
                Console.WriteLine("Current Basket Cost: " + _basket.Cost);
            }
        }

        [Verb("apples", HelpText = "Display Current Amount of Apples or Add Apples to the basket")]
        class ApplesCommand : ICommand
        {
            [Option('c',"count", Required = false, HelpText = "How Many Apples to Add")]
            public int Count { get; set; }
            public void Execute()
            {
                if (Count > 0)
                {
                    _basket.AddApples(Count);
                    Console.WriteLine("Current Apple Count: " + _basket.Apples);
                }
                else
                {
                   Console.WriteLine("Current Apple Count: " + _basket.Apples);
                }
            }
        }

        [Verb("bread", HelpText = "Display Current Amount of Bread or Add Bread to the basket")]
        class BreadCommand : ICommand
        {
            [Option('c', "count",Required = false, HelpText = "How Many Loaves of Bread to Add")]
            public int Count { get; set; }
            public void Execute()
            {
                if (Count > 0)
                {
                    _basket.AddBread(Count);
                    Console.WriteLine("Current Bread Count: " + _basket.Bread);
                }
                else
                {
                    Console.WriteLine("Current Bread Count: " + _basket.Bread);
                }
            }
        }

        [Verb("soup", HelpText = "Display Current Amount of Soup or Add Soup to the basket")]
        class SoupCommand : ICommand
        {
            [Option('c', "count", Required = false, HelpText = "How Many Tins of Soup to Add")]
            public int Count { get; set; }
            public void Execute()
            {
                if (Count > 0)
                {
                    _basket.AddSoup(Count);
                    Console.WriteLine("Current Soup Count: " + _basket.Soup);
                }
                else
                {
                    Console.WriteLine("Current Soup Count: " + _basket.Soup);
                }
            }
        }

        [Verb("Milk", HelpText = "Display Current Amount of Milk or Add Milk to the basket")]
        class MilkCommand : ICommand
        {
            [Option('c', "count", Required = false, HelpText = "How Much Milk to Add")]
            public int Count { get; set; }
            public void Execute()
            {
                if (Count > 0)
                {
                    _basket.AddMilk(Count);
                    Console.WriteLine("Current Milk Count: " + _basket.Milk);
                }
                else
                {
                    Console.WriteLine("Current Milk Count: " + _basket.Milk);
                }
            }
        }
    }
}
