using System;
using Raylib_cs;

namespace _07_snake
{
    public class PhysicsService
    {
        public PhysicsService()
        {

        }

        public bool IsCollision(Actor first, Actor second)
        {
            // This is really simplistic... it would be better
            // to see if there is any overlap in the rectangles. But that would be
            // a problem for the way the snake is constructed as a series of overlapping
            // segments.
            //return first.GetPosition() == second.GetPosition();

            int x1 = first.GetX();
            int y1 = first.GetY();
            int width1 = first.GetWidth();
            int height1 = first.GetHeight();

            Raylib_cs.Rectangle rectangle1
                = new Raylib_cs.Rectangle(x1, y1, width1, height1);

            int x2 = second.GetX();
            int y2 = second.GetY();
            int width2 = second.GetWidth();
            int height2 = second.GetHeight();

            Raylib_cs.Rectangle rectangle2
                = new Raylib_cs.Rectangle(x2, y2, width2, height2);

            return Raylib.CheckCollisionRecs(rectangle1, rectangle2);
        }
    }

}