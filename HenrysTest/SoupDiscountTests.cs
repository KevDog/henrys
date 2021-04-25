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

        [Test]
        public void BuyingTwoTinsOfSoupAndNoBreadGetsNoDiscount()
        {
                                
        }

        [Test]
        public void BuyingTwoTinsOfSoupAndALoafOfBreadTwoDaysAgoGetsNoDiscount()
        {
            
        }

        [Test]
        public void BuyingTwoTinsOfSoupAndALoafOfBreadYesterdayGetsADiscount()
        {
                
        }

        [Test]
        public void BuyingTwoTinsOfSoupAndALoafOfBreadTodayGetsADiscount()
        {
            
        }

        [Test]
        public void BuyingTwoTinsOfSoupAndALoafBreadInSevenDaysGetsADiscount()
        {
            
        }

        [Test]
        public void BuyingTwoTinsOfSoupAndALoafOfBreadInEightDaysGetsNoDiscount()
        {
            
        }
    }


}
