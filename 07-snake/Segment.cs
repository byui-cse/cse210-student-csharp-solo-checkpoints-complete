using System;

namespace _07_snake
{
    class Segment : Actor
    {
        
        public Segment(Point position, Point velocity)
        {
            _position = position;
            _velocity = velocity;
        }
        
    }

}