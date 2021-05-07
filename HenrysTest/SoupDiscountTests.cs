using System;
using HenrysLib;
using NUnit.Framework;

namespace HenrysTests
{
    public class SoupDiscountTests
    {
        private Basket _basket;

        [SetUp]
        public void Setup()
        {
            _basket = new Basket();
        }

        private static readonly DateTime[] DiscountCases =
        {
            DateTime.Today,
            DateTime.Today.AddDays(-1),
            DateTime.Today.AddDays(7),
        };

        private static readonly DateTime[] NonDiscountCases =
        {
            DateTime.Today.AddDays(-2),
            DateTime.Today.AddDays(8)

        };

        private static readonly DateTime[] AllCases =
        {
            DateTime.Today.AddDays(-2),
            DateTime.Today.AddDays(8),
            DateTime.Today,
            DateTime.Today.AddDays(-1),
            DateTime.Today.AddDays(7),
        };

        [TestCaseSource(nameof(DiscountCases))]
        public void SoupDiscountAppliesOnAppropriateDays(DateTime date)
        {
            _basket.DateOfSale = date;
            _basket.AddToBasket("Soup",2);
            _basket.AddToBasket("Bread",1);
            Assert.AreEqual(1.70M, _basket.BasketCost);
        }

        [TestCaseSource(nameof(NonDiscountCases))]
        public void SoupDiscountNotAppliedOnAppropriateDays(DateTime date)
        {
            _basket.DateOfSale = date;
            _basket.AddToBasket("Soup",2);
            _basket.AddToBasket("Bread",1);
            Assert.AreEqual(2.10M, _basket.BasketCost);
        }

        [TestCaseSource(nameof(AllCases))]
        public void BuyingTwoTinsOfSoupAndNoBreadGetsNoDiscount(DateTime date)
        {
            _basket.DateOfSale = date;
            _basket.AddToBasket("Soup",2);
            Assert.AreEqual(1.30M, _basket.BasketCost);
        }

        [TestCaseSource(nameof(AllCases))]
        public void BuyingBreadGetsNoDiscount(DateTime date)
        {
            _basket.DateOfSale = date;
            _basket.AddToBasket("Bread",2);
            Assert.AreEqual(1.60M, _basket.BasketCost);
        }
    }
}
