using System;
using System.Runtime.CompilerServices;

namespace HenrysLib
{
    public class Basket
    {
        private const decimal SoupPrice = 0.65M;
        private const decimal BreadPrice = 0.8M;
        private const decimal MilkPrice = 1.30M;
        private const decimal HalfLoafOfBread = -.40M;
        private const decimal ApplePrice = 0.10M;
        private static readonly DateTime _appleDiscountStart = DateTime.Today.AddDays(3);
        private static readonly DateTime NextMonth = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar.AddMonths(DateTime.Now, 1);
        private static readonly int DaysInNextMonth = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar.GetDaysInMonth(NextMonth.Year, NextMonth.Month);
        private static readonly DateTime AppleDiscountEnd = new DateTime(NextMonth.Year, NextMonth.Month, DaysInNextMonth);

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

        public decimal Cost => Decimal.Multiply(Soup, SoupPrice) +
                               Decimal.Multiply(Bread, BreadPrice) +
                               Decimal.Multiply(Milk, MilkPrice) +
                               ApplyAppleDiscount() +
                               ApplySoupDiscount();

        private decimal ApplyAppleDiscount()
        {
            if (AppleDateRangeApplies())
            {
                var discountedPrice = Decimal.Multiply(ApplePrice, 0.9M);
                return Decimal.Multiply(Apples, discountedPrice);
            }
            else
            {
                return Decimal.Multiply(Apples, ApplePrice);
            }
        }

        private decimal ApplySoupDiscount()
        {
            if (SoupDiscountApplies())
            {
                return HalfLoafOfBread;
            }
            return 0.0M;
        }
        public bool AppleDateRangeApplies()
        {
            return DateOfSale.Date >= _appleDiscountStart && DateOfSale.Date <= AppleDiscountEnd;
        }
        private bool SoupDiscountApplies()
        {
            return SoupDateRangeApplies() && SoupQuantitiesApply();
        }

        private bool SoupQuantitiesApply()
        {
            return Soup >= 2 && Bread >= 1;
        }

        private bool SoupDateRangeApplies()
        {
            return DateOfSale.Date > DateTime.Today.AddDays(-2) && DateOfSale.Date < DateTime.Today.AddDays(8);
        }

        public DateTime DateOfSale { get; set; }

        public void AddSoup(int count)
        {
            Soup += count;
            if (Soup < 0)
            {
                Soup = 0;
            }
        }

        public void AddBread(int count)
        {
            Bread += count;
            if (Bread < 0)
            {
                Bread = 0;
            }
        }

        public void AddMilk(int count)
        {
            Milk += count;
            if (Milk < 0)
            {
                Milk = 0;
            }
        }

        public void AddApples(int count)
        {
            Apples += count;
            if (Apples < 0)
            {
                Apples = 0;
            }
        }
    }
}
