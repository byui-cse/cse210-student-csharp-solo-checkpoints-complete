using System;

namespace _07_snake
{
    public class Point
    {
        private int _x;
        private int _y;

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int GetX()
        {
            return _x;
        }

        public int GetY()
        {
            return _y;
        }

        public Point Add(Point other)
        {
            int newX = _x + other._x;
            int newY = _y + other._y;

            return new Point(newX, newY);
        }

        public Point Reverse()
        {
            int newX = _x * -1;
            int newY = _y * -1;

            return new Point(newX, newY);
        }

        public override bool Equals(object obj)
        {
            return obj is Point point &&
                   _x == point._x &&
                   _y == point._y;
        }

        // If you ever override the Equals function, you should also override the GetHashCode function
        public override int GetHashCode()
        {
            return HashCode.Combine(_x, _y);
        }
    }

}