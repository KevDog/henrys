using System;
using HenrysLib;
using NUnit.Framework;

namespace HenrysTests
{
    public class AcceptanceTests
    {
        private Basket basket;
        private DateTime fiveDaysFromNow = DateTime.Now.AddDays(5);

        [SetUp]
        public void Setup()
        {
            basket = new Basket();
        }

        [Test]
        public void ThreeTinsOfSoupAndTwoLoavesOfBreadBoughtToday()
        {
            basket.AddSoup(3);
            basket.AddBread(2);
            Assert.AreEqual(3.15,basket.Cost);
        }

        [Test]
        public void SixApplesAndABottleOfMilkBoughtToday()
        {
            basket.AddApples(6);
            basket.AddMilk(1);
            Assert.AreEqual(1.90,basket.Cost);
        }

        [Test]
        public void SixApplesAndABottleOfMilkBoughtInFiveDaysTime()
        {
            basket.DateOfSale = fiveDaysFromNow;
            basket.AddApples(6);
            basket.AddMilk(1);
            Assert.AreEqual(1.84, basket.Cost);
        }

        [Test]
        public void ThreeApplesAndTwoTinsOfSoupBoughtInFiveDaysTime()
        {
            basket.DateOfSale = fiveDaysFromNow;
            basket.AddApples(6);
            basket.AddMilk(1);
            Assert.AreEqual(1.84, basket.Cost);
        }
    }
}
