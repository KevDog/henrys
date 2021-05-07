using System;
//using System.Reflection;
using System.Globalization;
using System.Text;
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

        public void AddToBasket(string prop, int count )
        {
            prop = ToTitleCase(prop);
            try
            {
                var property = GetType().GetProperty(prop);
                
                var current =(int) property.GetValue(this);
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

        public static string ToTitleCase(string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
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
            if (!AppleDateRangeApplies()) return decimal.Multiply(Apples, ApplePrice);
            
            var discountedPrice = decimal.Multiply(ApplePrice, 0.9M);
            return decimal.Multiply(Apples, discountedPrice);
        }

        private decimal ApplySoupDiscount()
        {
            if (!SoupDiscountApplies()) return 0.0M;
            
            return HalfLoafOfBread;
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

        public override string ToString()
        {
            var builder = new StringBuilder();
            //This may seem a little over-complicated for a ToString method; however, it
            //provides the formatting to look good for the CLI. We pick out the compound
            //words and add spaces. For the goods, we set tabs as required. 
            foreach (var propertyInfo in GetType().GetProperties())
            {
                var type = propertyInfo.PropertyType;
                switch (true)
                {
                    case bool _ when type == typeof(DateTime):
                        var saleDate = (DateTime) propertyInfo.GetValue(this);
                        builder.AppendLine("Sale Date: \t" + saleDate.ToShortDateString());
                        break;
                    case bool _ when propertyInfo.Name == "BasketCost":
                        builder.AppendLine("Basket Cost: \t" + BasketCost);
                        break;
                    
                    default:
                        if(propertyInfo.Name.Length > 5)
                            builder.AppendLine(propertyInfo.Name + ": \t" + propertyInfo.GetValue(this));
                        else
                            builder.AppendLine(propertyInfo.Name + ": \t\t" + propertyInfo.GetValue(this) );
                        break;
                }
            }
            return builder.ToString();
        }
    }
}
