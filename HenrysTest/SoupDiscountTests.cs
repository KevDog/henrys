using System;
using HenrysLib;
using NUnit.Framework;

namespace HenrysTests
{
    public class SoupDiscountTests
    {
        private Basket basket;

        [SetUp]
        public void Setup()
        {
            basket = new Basket();
        }

        private static DateTime[] _discountCases =
        {
            DateTime.Today,
            DateTime.Today.AddDays(-1),
            DateTime.Today.AddDays(7),
        };

        private static DateTime[] _nonDiscountCases =
        {
            DateTime.Today.AddDays(-2),
            DateTime.Today.AddDays(8)

        };

        private static DateTime[] _allCases =
        {
            DateTime.Today.AddDays(-2),
            DateTime.Today.AddDays(8),
            DateTime.Today,
            DateTime.Today.AddDays(-1),
            DateTime.Today.AddDays(7),
        };

        [TestCaseSource(nameof(_discountCases))]
        public void SoupDiscountAppliesOnAppropriateDays(DateTime date)
        {
            basket.DateOfSale = date;
            basket.AddSoup(2);
            basket.AddBread(1);
            Assert.AreEqual(1.70M, basket.BasketCost);
        }


        [TestCaseSource(nameof(_nonDiscountCases))]
        public void SoupDiscountNotAppliedOnAppropriateDays(DateTime date)
        {
            basket.DateOfSale = date;
            basket.AddSoup(2);
            basket.AddBread(1);
            Assert.AreEqual(2.10M, basket.BasketCost);
        }

        [TestCaseSource(nameof(_allCases))]
        public void BuyingTwoTinsOfSoupAndNoBreadGetsNoDiscount(DateTime date)
        {
            basket.DateOfSale = date;
            basket.AddSoup(2);
            Assert.AreEqual(1.30M, basket.BasketCost);
        }


        [TestCaseSource(nameof(_allCases))]
        public void BuyingBreadGetsNoDiscount(DateTime date)
        {
            basket.DateOfSale = date;
            basket.AddBread(2);
            Assert.AreEqual(1.60M, basket.BasketCost);
        }
    }


}
