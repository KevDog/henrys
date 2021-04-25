using System;
using HenrysLib;
using NUnit.Framework;

namespace HenrysTests
{
    public class BasketTests
    {
        private Basket basket;

        [SetUp]
        public void Setup()
        {
            basket = new Basket();
        }

        [Test]
        public void BasketSaleDateIsTodayByDefault()
        {
            basket = new Basket();
            Assert.AreEqual(DateTime.Today,basket.DateOfSale);
        }

        [Test]
        public void CanSetSaleDateAtCreation()
        {
            basket = new Basket(new DateTime(2021,1,1));
            Assert.AreEqual(new DateTime(2021, 1, 1), basket.DateOfSale);
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
