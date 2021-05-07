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
        public void CannotHaveNegativeBasketItemCount()
        {
            //It might seem that this is a good candidate for
            //parametrization, but going from the string to the
            //property would make for an overly complicated test,
            //I think. If the inventory count for the store
            //expanded, I would probably put the items into
            //a separate class and parametrize using instances
            //of those.
            const int adding = 10;
            const int subtracting = -11;

            _basket.AddToBasket("Apples",adding);
            _basket.AddToBasket("Apples",subtracting);
            Assert.AreEqual(0,_basket.Apples);

            _basket.AddToBasket("Milk",adding);
            _basket.AddToBasket("Milk",subtracting);
            Assert.AreEqual(0, _basket.Milk);
        
            _basket.AddToBasket("Soup",adding);
            _basket.AddToBasket("Soup",subtracting);
            Assert.AreEqual(0, _basket.Soup);

            _basket.AddToBasket("Bread",adding);
            _basket.AddToBasket("Bread",subtracting);
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
            _basket.AddToBasket("Bread",1);
            _basket.AddToBasket("Apples",1);
            _basket.AddToBasket("Milk",1);
            _basket.AddToBasket("Soup",1);
            Assert.AreEqual(2.85, _basket.BasketCost);
        }

        [TestCase("apples", 2, 0.20)]
        [TestCase("milK", 2, 2.60)]
        [TestCase("soUp", 2, 1.30)]
        [TestCase("bREad", 2, 1.60)]
        public void BadCasingOfValidItemsStillAddsItem(string item, int count, decimal expectedCost)
        {
            _basket.AddToBasket(item, count);
            Assert.AreEqual(expectedCost, _basket.BasketCost);
        }

        [Test]
        public void CanCorrectBadInputText()
        {
            Assert.AreEqual("Teststring", Basket.ToTitleCase("testSTRING"));
        }
    }
}
