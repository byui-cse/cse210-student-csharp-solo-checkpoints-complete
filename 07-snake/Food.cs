using System;

namespace _07_snake
{
    /// <summary>
    /// A class to represent the food in the game.
    /// </summary>
    class Food : Actor
    {
        private int _points;

        public Food()
        {
            // Use the standard reset method to start the initial food.
            Reset();
        }

        public int GetPoints()
        {
            return _points;
        }

        /// <summary>
        /// Sets the food to a random point value from 1-10.
        /// Also puts it at a random location on the screen.
        /// </summary>
        public void Reset()
        {
            Random randomGenerator = new Random();
            _points = randomGenerator.Next(1, 10);
            _text = _points.ToString();

            int x = randomGenerator.Next(0, Constants.MAX_X);
            int y = randomGenerator.Next(0, Constants.MAX_Y);

            _position = new Point(x, y);
        }
    }

}