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
        private static DateTime _nextMonth = DateTimeFormatInfo.CurrentInfo.Calendar.AddMonths(DateTime.Now, 1);
        private static int _daysInThisMonth = DateTimeFormatInfo.CurrentInfo.Calendar.GetDaysInMonth(_nextMonth.Year, _nextMonth.Month);
        private static DateTime _lastDayOfNextMonth = new(_nextMonth.Year, _nextMonth.Month, _daysInThisMonth);
        private static DateTime _firstDayOfMonthAfterNext = _lastDayOfNextMonth.AddDays(1);
        private static DateTime _threeDaysFromNow = DateTime.Today.AddDays(3);

        [SetUp]
        public void Setup()
        {
            _basket = new Basket();
        }

        private static DateTime[] _discountDates =
        {
            _threeDaysFromNow,
            _lastDayOfNextMonth
        };

        private static DateTime[] _nonDiscountDates =
        {
            DateTime.Today, 
            DateTime.Today.AddDays(2),
            DateTime.Today.AddDays(-1),
            _firstDayOfMonthAfterNext
        };

        [Test]
        public void DateRangeForDiscountDatesReturnsTrue()
        {
            foreach (var date in EachDay(_threeDaysFromNow, _lastDayOfNextMonth))
            {
                _basket = new Basket(date);
                _basket.AddApples(10);
                _basket.DateOfSale = date;
                Assert.True(_basket.AppleDateRangeApplies());
                Assert.AreEqual(0.9M,_basket.Cost);
            }
        }

        [TestCaseSource(nameof(_nonDiscountDates))]
        public void DateRangeForNonDiscountDatesReturnsFalse(DateTime date)
        {
            _basket.DateOfSale = date;
            _basket.AddApples(10);
            Assert.AreEqual(1.0M, _basket.Cost);
        }

        private IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }
     
    }
}
