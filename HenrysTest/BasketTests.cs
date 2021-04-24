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
        public void AddingApplesToBasketProducesCorrectPrice()
        {
            basket.AddApples(2);
            Assert.AreEqual(0.20, basket.Cost);
        }

        [Test]
        public void ABasketWithOneMilkHasCorrectPrice()
        {
            basket.AddMilk(2);
            Assert.AreEqual(2.60, basket.Cost);
        }

        [Test]
        public void ABasketWithOneCanOfSoupHasCorrectPrice()
        {
            basket.AddSoup(2);
            Assert.AreEqual(1.30, basket.Cost);
        }

        [Test]
        public void ABasketWithOneLoafOfBreadHasCorrectPrice()
        {
            basket.AddBread(2);
            Assert.AreEqual(1.60, basket.Cost);
        }

        [Test]
        public void ABasketWithOneOfEachItemHasCorrectPrice()
        {
            basket.AddBread(1);
            basket.AddApples(1);
            basket.AddMilk(1);
            basket.AddSoup(1);
            Assert.AreEqual(2.85, basket.Cost);
        }
    }
}
