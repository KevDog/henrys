using System;
using HenrysLib;
using NUnit.Framework;

namespace HenrysTests
{
    public class AcceptanceTests
    {
        private Basket _basket;
        private DateTime _fiveDaysFromNow = DateTime.Now.AddDays(5);

        [SetUp]
        public void Setup()
        {
            _basket = new Basket();
        }

        [Test]
        public void ThreeTinsOfSoupAndTwoLoavesOfBreadBoughtToday()
        {
            _basket.AddSoup(3);
            _basket.AddBread(2);
            Assert.AreEqual(3.15M,_basket.Cost);
        }

        [Test]
        public void SixApplesAndABottleOfMilkBoughtToday()
        {
            _basket.AddApples(6);
            _basket.AddMilk(1);
            Assert.AreEqual(1.90M,_basket.Cost);
        }

        [Test]
        public void SixApplesAndABottleOfMilkBoughtInFiveDaysTime()
        {
            _basket.DateOfSale = _fiveDaysFromNow;
            _basket.AddApples(6);
            _basket.AddMilk(1);
            Assert.AreEqual(1.84M, _basket.Cost);
        }

        [Test]
        public void ThreeApplesAndTwoTinsOfSoupBoughtInFiveDaysTime()
        {
            _basket.DateOfSale = _fiveDaysFromNow;
            _basket.AddApples(6);
            _basket.AddMilk(1);
            Assert.AreEqual(1.84M, _basket.Cost);
        }
    }
}
