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

        public decimal Cost => Decimal.Multiply(Soup, 0.65M) + 
                               Decimal.Multiply(Bread, 0.8M) + 
                               Decimal.Multiply(Milk, 1.30M) + 
                               Decimal.Multiply(Apples, 0.10M) + 
                               ApplySoupDiscount();

        private decimal ApplySoupDiscount()
        {
            if (SoupDiscountApplies())
            {
                return -.40M;
            }
            else
            {
                return 0.0M;
            }
        }

        private bool SoupDiscountApplies()
        {
            return DateRangeApplies() && (Soup >= 2 && Bread >= 1);
        }

        public bool DateRangeApplies()
        {
            return DateOfSale.Date > DateTime.Today.AddDays(-2) && DateOfSale.Date < DateTime.Today.AddDays(8);
        }

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
