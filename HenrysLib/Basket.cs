using System;
using System.Runtime.CompilerServices;

namespace HenrysLib
{
    public class Basket
    {
        private int _soup;
        private int _bread;
        private int _milk;
        private int _apples;

        public int Soup   => _soup;
        public int Bread  => _bread;
        public int Milk   => _milk;
        public int Apples => _apples;
        
        public void AddSoup()
        {
            _soup = 1;
        }
        public void AddBread()
        {
            _bread = 1;
        }

        public void AddMilk()
        {
            _milk = 1;
        }

        public void AddApples()
        {
            _apples = 1;
        }
    }
}
