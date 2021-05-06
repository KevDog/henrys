using System;
using System.Reflection;
using static System.Globalization.DateTimeFormatInfo;

namespace HenrysLib
{
    public class Basket
    {
        private const decimal SoupPrice = 0.65M;
        private const decimal BreadPrice = 0.8M;
        private const decimal MilkPrice = 1.30M;
        private const decimal HalfLoafOfBread = -.40M;
        private const decimal ApplePrice = 0.10M;
        
        private static readonly DateTime AppleDiscountStart = DateTime.Today.AddDays(3);
        private static readonly DateTime NextMonth = CurrentInfo.Calendar.AddMonths(DateTime.Now, 1);
        private static readonly int DaysInNextMonth = CurrentInfo.Calendar.GetDaysInMonth(NextMonth.Year, NextMonth.Month);
        private static readonly DateTime AppleDiscountEnd = new(NextMonth.Year, NextMonth.Month, DaysInNextMonth);

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

        public DateTime DateOfSale { get; set; }

        public void AddSoup(int count)
        {
           AddToBasket("Soup",count);
        }

        public void AddBread(int count)
        {
            AddToBasket("Bread",count);
        }

        public void AddMilk(int count)
        {
           AddToBasket("Milk", count);
        }

        public void AddApples(int count)
        {
            AddToBasket("Apples",count);
        }

        public void AddToBasket(string prop, int count )
        {
            try
            {
                var property = GetType().GetProperty(prop);
           

                var current =(int) GetType().GetProperty(prop).GetValue(this);
                var sum = count + current;
                if (sum < 0)
                {
                    property.SetValue(this, 0);
                }
                else
                {
                    property.SetValue(this, sum);
                }
            }
            catch (NullReferenceException e)
            {
                e.Data.Add("Henrys","Can only add inventory items to basket");
                throw;
            }
            
        }
        public decimal BasketCost => Math.Round(CalculateBasketCost(),2);

        private decimal CalculateBasketCost()
        {
            return decimal.Multiply(Soup, SoupPrice) +
                   decimal.Multiply(Bread, BreadPrice) +
                   decimal.Multiply(Milk, MilkPrice) +
                   ApplyAppleDiscount() +
                   ApplySoupDiscount();
        }

        private decimal ApplyAppleDiscount()
        {
            if (AppleDateRangeApplies())
            {
                var discountedPrice = decimal.Multiply(ApplePrice, 0.9M);
                return decimal.Multiply(Apples, discountedPrice);
            }
            return decimal.Multiply(Apples, ApplePrice);
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
            return DateOfSale.Date >= AppleDiscountStart && DateOfSale.Date <= AppleDiscountEnd;
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
    }
}
