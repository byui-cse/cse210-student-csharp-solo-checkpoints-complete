using System;

namespace _07_snake
{
    class Food : Actor
    {
        private int _points;

        public Food()
        {
            Reset();
        }

        public int GetPoints()
        {
            return _points;
        }

        public void Reset()
        {
            Random randomGenerator = new Random();
            _points = randomGenerator.Next(1, 5);
            _text = _points.ToString();

            int x = randomGenerator.Next(0, Constants.MAX_X);
            int y = randomGenerator.Next(0, Constants.MAX_Y);

            _position = new Point(x, y);
        }
    }

}