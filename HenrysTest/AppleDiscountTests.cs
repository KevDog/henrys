using System;
using HenrysLib;
using NUnit.Framework;

namespace HenrysTests
{
    public class AppleDiscountTests
    {
        private Basket basket;

        [SetUp]
        public void Setup()
        {
            basket = new Basket();
        }

        [Test]
        public void ApplesSoldTodayHaveNoDiscount()
        {

        }

        [Test]
        public void ApplesSoldInThreeDaysHaveTenPercentDiscount()
        {

        }

        [Test]
        public void ApplesSoldOnLastDayOfNextMonthHaveTenPercentDiscount()
        {

        }

        [Test]
        public void ApplesSoldOnFirstDayTwoMonthFromNoHaveNoDiscount()
        {

        }

    }
}
