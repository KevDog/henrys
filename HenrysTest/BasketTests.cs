using HenrysLib;
using NUnit.Framework;

namespace HenrysTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanCreateABasket()
        {
            var basket = new Basket();
            Assert.NotNull(basket);
        }
    }
}
