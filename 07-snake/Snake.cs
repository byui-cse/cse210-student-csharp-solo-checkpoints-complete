using System;
using System.Collections.Generic;

namespace _07_snake
{
    class Snake : Actor
    {
        private List<Actor> _segments = new List<Actor>();
        private int _canCollideIndex = Constants.DEFAULT_SQUARE_SIZE * 2 + 1;

        public Snake()
        {
            PrepareBody();
        }

        private void PrepareBody()
        {
            int x = Constants.MAX_X / 2;
            int y = Constants.MAX_Y / 2;

            for (int i = 0; i < Constants.SNAKE_LENGTH; i++)
            {
                int offsetFromHead = i * 1;
                //int offsetFromHead = i * Constants.DEFAULT_SQUARE_SIZE;

                Point position = new Point(x, y + offsetFromHead);
                Point velocity = new Point(0, -1);

                Segment segment = new Segment(position, velocity);
                _segments.Add(segment);
            }

        }

        public Actor GetHead()
        {
            return _segments[0];
        }

        // public List<Segment> GetBody()
        // {
        // }

        public List<Actor> GetAllSegments()
        {
            return _segments;
        }

        public List<Actor> GetCollidableSegments()
        {
            return _segments.GetRange(_canCollideIndex, _segments.Count - _canCollideIndex);
        }

        public void GrowTail(int amount)
        {
            amount *= 10;
            
            for (int i = 0; i < amount; i++)
            {
                GrowTailSingle();
            }
        }

        public void GrowTailSingle()
        {
            Actor tail = _segments[_segments.Count - 1];
            Point offsetAmount = tail.GetVelocity().Reverse();

            Point newPosition = tail.GetPosition().Add(offsetAmount);
            Point newVelocity = tail.GetVelocity();

            Segment newSegment = new Segment(newPosition, newVelocity);
            _segments.Add(newSegment);
        }

        public void Move()
        {
            // First move them all forward...
            foreach (Actor actor in _segments)
            {
                actor.MoveNext();
            }

            // Now update the velocity for each one to have the velocity of the segment before
            for (int i = _segments.Count - 1; i >= 0; i--)
            {
                if (i > 0) // Not the head
                {
                    Actor currentSegment = _segments[i];
                    Actor segmentBefore = _segments[i - 1];

                    Point velocity = segmentBefore.GetVelocity();
                    currentSegment.SetVelocity(velocity);
                }
            }
        }

        public void TurnHead(Point direction)
        {
            _segments[0].SetVelocity(direction);
        }

    }

}