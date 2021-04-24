using System;
using System.Runtime.CompilerServices;

namespace HenrysLib
{
    public class Basket
    {
        public Basket()
        {
            DateOfSale = DateTime.Today;
        }

        public Basket(DateTime saleDate)
        {
            DateOfSale = saleDate;
        }

        public int Soup { get; private set; }

        public int Bread { get; private set; }

        public int Milk { get; private set; }

        public int Apples { get; private set; }

        public double Cost => Soup * 0.65 + Bread * 0.8 + Milk * 1.30 + Apples * 0.10;
        public DateTime DateOfSale { get; set; }

        public void AddSoup(int count)
        {
            Soup = Soup + count;
        }
        public void AddBread(int count)
        {
            Bread = Bread + count;
        }

        public void AddMilk(int count)
        {
            Milk = Milk + count;
        }

        public void AddApples(int count)
        {
            Apples = Apples + count;
        }
    }
}
