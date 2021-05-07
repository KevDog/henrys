using System;
using System.Collections.Generic;
using System.Globalization;
using HenrysLib;
using NUnit.Framework;

namespace HenrysTests
{
    public class AppleDiscountTests
    {
        private Basket _basket;
        private static readonly DateTime NextMonth = DateTimeFormatInfo.CurrentInfo.Calendar.AddMonths(DateTime.Now, 1);
        private static readonly int DaysInThisMonth = DateTimeFormatInfo.CurrentInfo.Calendar.GetDaysInMonth(NextMonth.Year, NextMonth.Month);
        private static readonly DateTime LastDayOfNextMonth = new(NextMonth.Year, NextMonth.Month, DaysInThisMonth);
        private static readonly DateTime FirstDayOfMonthAfterNext = LastDayOfNextMonth.AddDays(1);
        private static readonly DateTime ThreeDaysFromNow = DateTime.Today.AddDays(3);

        [SetUp]
        public void Setup()
        {
            _basket = new Basket();
        }

        private static readonly DateTime[] NonDiscountDates =
        {
            DateTime.Today, 
            DateTime.Today.AddDays(2),
            DateTime.Today.AddDays(-1),
            FirstDayOfMonthAfterNext
        };

        [Test]
        public void DateRangeForDiscountDatesReturnsTrue()
        {
            foreach (var date in EachDay(ThreeDaysFromNow, LastDayOfNextMonth))
            {
                _basket = new Basket(date);
                _basket.AddToBasket("Apples",10);
                _basket.DateOfSale = date;
                Assert.True(_basket.AppleDateRangeApplies());
                Assert.AreEqual(0.9M,_basket.BasketCost);
            }
        }

        [TestCaseSource(nameof(NonDiscountDates))]
        public void DateRangeForNonDiscountDatesReturnsFalse(DateTime date)
        {
            _basket.DateOfSale = date;
            _basket.AddToBasket("Apples",10);
            Assert.AreEqual(1.0M, _basket.BasketCost);
        }

        private static IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }
    }
}
