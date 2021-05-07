using System;
using System.Data.SqlTypes;
using CommandLine;
using HenrysLib;

namespace Henrys
{
    internal class Program
    {
        private static readonly Basket Basket = new();

        private static void Main(string[] args)
        {
            Console.WriteLine("'help' to list commands, Control-C to quit");
            while (true)
            {
                Console.Write("Enter Command: ");
                args = Console.ReadLine()?.Split(" ");
                Parser.Default.ParseArguments<StatusCommand, AddCommand, DateCommand>(args)
                    .WithParsed<Program.ICommand>(t => t.Execute());
            }
        }

        private interface ICommand
        {
            void Execute();
        }

        [Verb("add", HelpText = "Add or remove items from the basket")]
        private class AddCommand : ICommand
        {
            [Option('i', "item", Required = true, HelpText = "Specifies Which Item to Add")]
            public string Item { get; set; }
            [Option('c', "count", Required = true, HelpText = "How Many Items to Add")]
            public int Count { get; set; }
            public void Execute()
            {
                try
                {
                    Basket.AddToBasket(Item,Count);
                    Console.WriteLine(Basket.ToString());
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e.Data["Henrys"] + " : " + Item + " is not a valid inventory item.");
                    
                }
            }
        }
    
        [Verb("date", HelpText = "Set the basket sale date")]
        private class DateCommand : ICommand
        {
            [Option('s',"date", HelpText = "Specify a specific sale date")]
            public string Date { get; set; }

            [Option('c',"count", HelpText = "Add or subtract days from the current sale date")]
            public int Count { get; set; }
            public void Execute()
            {
                if (Count != 0)
                {
                  Basket.DateOfSale = Basket.DateOfSale.AddDays(Count);
                  Console.WriteLine("Sale Date: " + Basket.DateOfSale);
                  return;
                }

                try
                {
                    var date = DateTime.Parse(Date);
                    Basket.DateOfSale = date.Date;
                    Console.WriteLine("Sale Date: " + Basket.DateOfSale);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid sale date options");
                }
            }
        }

        [Verb("status", HelpText = "Display the current status")]
        private class StatusCommand : ICommand
        {
            public void Execute()
            {
                Console.WriteLine(Basket.ToString());
            }
        }
    }
}
