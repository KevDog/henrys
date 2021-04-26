using System;
using System.Windows.Input;
using CommandLine;
using HenrysLib;

namespace Henrys
{
    internal class Program
    {
        private static Basket _basket = new Basket();

        private static void Main(string[] args)
        {
            Console.WriteLine("'help' to list commands, Control-C to quit");
            while (true)
            {
                Console.Write("Enter Command: ");
                args = Console.ReadLine()?.Split(" ");
                Parser.Default.ParseArguments<CostCommand, ApplesCommand, BreadCommand, SoupCommand, MilkCommand, DateCommand>(args)
                    .WithParsed<Program.ICommand>(t => t.Execute());
            }
        }

        private interface ICommand
        {
            void Execute();
        }

        [Verb("date", HelpText = "Display or set the basket sale date")]
        public class DateCommand : ICommand
        {
            [Option('s',"date", HelpText = "Set the sale date of the basket")]
            public string Date { get; set; }

            [Option('c',"count", HelpText = "Add or subtract days from the sale date")]
            public int Count { get; set; }
            public void Execute()
            {
                if (Count != 0)
                {
                  _basket.DateOfSale = _basket.DateOfSale.AddDays(Count);
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
        private class CostCommand : ICommand
        {
            public void Execute()
            {
                Console.WriteLine("Current Basket Cost: " + _basket.Cost);
            }
        }

        [Verb("apples", HelpText = "Display Current Amount of Apples or Add Apples to the basket")]
        private class ApplesCommand : ICommand
        {
            [Option('c',"count", Required = false, HelpText = "How Many Apples to Add")]
            public int Count { get; set; }
            public void Execute()
            {
                if (Count != 0)
                {
                    _basket.AddApples(Count);
                }
                Console.WriteLine("Current Apple Count: " + _basket.Apples);
            }
        }

        [Verb("bread", HelpText = "Display Current Amount of Bread or Add Bread to the basket")]
        private class BreadCommand : ICommand
        {
            [Option('c', "count", Required = false, HelpText = "How Many Loaves of Bread to Add")]
            public int Count { get; set; }
            public void Execute()
            {
                if (Count != 0)
                {
                    _basket.AddBread(Count);
                }
                Console.WriteLine("Current Bread Count: " + _basket.Bread);
            }
        }

        [Verb("soup", HelpText = "Display Current Amount of Soup or Add Soup to the basket")]
        private class SoupCommand : ICommand
        {
            [Option('c', "count", Required = false, HelpText = "How Many Tins of Soup to Add")]
            public int Count { get; set; }
            public void Execute()
            {
                if (Count != 0)
                {
                    _basket.AddSoup(Count);
                }
                Console.WriteLine("Current Soup Count: " + _basket.Soup);
            }
        }

        [Verb("milk", HelpText = "Display Current Amount of Milk or Add Milk to the basket")]
        private class MilkCommand : ICommand
        {
            [Option('c', "count", Required = false, HelpText = "How Much Milk to Add")]
            public int Count { get; set; }
            public void Execute()
            {
                if (Count != 0)
                {
                    _basket.AddMilk(Count);
                }
                Console.WriteLine("Current Milk Count: " + _basket.Milk);
            }
        }
    }
}
