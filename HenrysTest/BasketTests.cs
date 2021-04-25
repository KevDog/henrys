using System;
using HenrysLib;
using NUnit.Framework;

namespace HenrysTests
{
    public class BasketTests
    {
        private Basket _basket;

        [SetUp]
        public void Setup()
        {
            _basket = new Basket();
        }

        [Test]
        public void CannotTakeOutMoreApplesThanWerePutIn()
        {
            _basket.AddApples(10);
            _basket.AddApples(-11);
            Assert.AreEqual(0,_basket.Apples);
        }


        [Test]
        public void CannotTakeOutMoreMilkThanWerePutIn()
        {
            _basket.AddMilk(10);
            _basket.AddMilk(-11);
            Assert.AreEqual(0, _basket.Milk);
        }


        [Test]
        public void CannotTakeOutMoreSoupThanWerePutIn()
        {
            _basket.AddSoup(10);
            _basket.AddSoup(-11);
            Assert.AreEqual(0, _basket.Soup);
        }

        [Test]
        public void CannotTakeOutMoreBreadThanWerePutIn()
        {
            _basket.AddBread(10);
            _basket.AddBread(-11);
            Assert.AreEqual(0, _basket.Bread);
        }

        [Test]
        public void BasketSaleDateIsTodayByDefault()
        {
            _basket = new Basket();
            Assert.AreEqual(DateTime.Today,_basket.DateOfSale);
        }

        [Test]
        public void CanSetSaleDateAtCreation()
        {
            _basket = new Basket(new DateTime(2021,1,1));
            Assert.AreEqual(new DateTime(2021, 1, 1), _basket.DateOfSale);
        }

        [Test]
        public void AddingApplesToBasketProducesCorrectPrice()
        {
            _basket.AddApples(2);
            Assert.AreEqual(0.20, _basket.Cost);
        }

        [Test]
        public void ABasketWithOneMilkHasCorrectPrice()
        {
            _basket.AddMilk(2);
            Assert.AreEqual(2.60, _basket.Cost);
        }

        [Test]
        public void ABasketWithOneCanOfSoupHasCorrectPrice()
        {
            _basket.AddSoup(2);
            Assert.AreEqual(1.30, _basket.Cost);
        }

        [Test]
        public void ABasketWithOneLoafOfBreadHasCorrectPrice()
        {
            _basket.AddBread(2);
            Assert.AreEqual(1.60, _basket.Cost);
        }

        [Test]
        public void ABasketWithOneOfEachItemHasCorrectPrice()
        {
            _basket.AddBread(1);
            _basket.AddApples(1);
            _basket.AddMilk(1);
            _basket.AddSoup(1);
            Assert.AreEqual(2.85, _basket.Cost);
        }
    }
}
