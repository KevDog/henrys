using System.Runtime.InteropServices.ComTypes;
using HenrysLib;
using NUnit.Framework;

namespace HenrysTests
{
    public class Tests
    {
        private Basket basket;
        [SetUp]
        public void Setup()
        {
            basket = new Basket();
        }

        [Test]
        public void CanCreateABasket()
        {
            Assert.NotNull(basket);
        }

        [Test]
        public void CanAddATinOfSoupToABasket()
        {
            basket.AddSoup();
            Assert.AreEqual(1,basket.Soup);
        }

        [Test]
        public void CanAddALoafOfBreadToABasket()
        {
            basket.AddBread();
            Assert.AreEqual(1,basket.Bread);
        }

        [Test]
        public void CanAddMilkToABasket()
        {
            basket.AddMilk();
            Assert.AreEqual(1,basket.Milk);
        }

        [Test]
        public void CanAddApplesToABasket()
        {
            basket.AddApples();
            Assert.AreEqual(1,basket.Apples);
        }
    }
}
