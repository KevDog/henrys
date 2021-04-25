using System;
using System.Runtime.CompilerServices;

namespace HenrysLib
{
    public class Basket
    {
        private decimal _soupPrice = 0.65M;
        private decimal _breadPrice = 0.8M;
        private decimal _milkPrice = 1.30M;
        private decimal _halfLoafOfBread = -.40M;
        private decimal _applePrice = 0.10M;

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

        public decimal Cost => Decimal.Multiply(Soup, _soupPrice) + 
                               Decimal.Multiply(Bread, _breadPrice) + 
                               Decimal.Multiply(Milk, _milkPrice) + 
                               Decimal.Multiply(Apples, _applePrice) + 
                               ApplySoupDiscount();

        private decimal ApplySoupDiscount()
        {
            if (SoupDiscountApplies())
            {
                return _halfLoafOfBread;
            }
            else
            {
                return 0.0M;
            }
        }

        private bool SoupDiscountApplies()
        {
            return DateRangeApplies() && QuantitiesApply();
        }

        private bool QuantitiesApply()
        {
            return Soup >= 2 && Bread >= 1;
        }

        private bool DateRangeApplies()
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
