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
       
        public void CanOnlyAddItemsThatExistInStore()
        {
          var ex = Assert.Throws<NullReferenceException>(() => _basket.AddToBasket("Cookies", 1));
          Assert.AreEqual("Can only add inventory items to basket", ex.Data["Henrys"]);
        }


        [Test]
        public void CannotTakeOutMoreItemsThanWerePutIn()
        {
            var adding = 10;
            var subtracting = -11;

            _basket.AddApples(adding);
            _basket.AddApples(subtracting);
            Assert.AreEqual(0,_basket.Apples);

            _basket.AddMilk(adding);
            _basket.AddMilk(subtracting);
            Assert.AreEqual(0, _basket.Milk);
        
            _basket.AddSoup(adding);
            _basket.AddSoup(subtracting);
            Assert.AreEqual(0, _basket.Soup);

            _basket.AddBread(adding);
            _basket.AddBread(subtracting);
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



        [TestCase("Apples", 2, 0.20)]
        [TestCase("Milk",   2, 2.60)]
        [TestCase("Soup",   2, 1.30)]
        [TestCase("Bread", 2, 1.60)]
        public void AddingApplesToBasketProducesCorrectPrice(string item, int count, decimal expectedCost)
        {
            _basket.AddToBasket(item,count);
            Assert.AreEqual(expectedCost, _basket.BasketCost);
        }
        
        [Test]
        public void ABasketWithOneOfEachItemHasCorrectPrice()
        {
            _basket.AddBread(1);
            _basket.AddApples(1);
            _basket.AddMilk(1);
            _basket.AddSoup(1);
            Assert.AreEqual(2.85, _basket.BasketCost);
        }
    }
}
