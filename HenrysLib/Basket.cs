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
        public double Cost => _soup * 0.65 + _bread * 0.8 + _milk * 1.30 + _apples * 0.10;

        public void AddSoup(int count)
        {
            _soup = _soup + count;
        }
        public void AddBread(int count)
        {
            _bread = _bread + count;
        }

        public void AddMilk(int count)
        {
            _milk = _milk + count;
        }

        public void AddApples(int count)
        {
            _apples = _apples + count;
        }
    }
}
