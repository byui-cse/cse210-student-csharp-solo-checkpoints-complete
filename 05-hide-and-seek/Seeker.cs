using System;
using System.Collections.Generic;

namespace _05_hide_and_seek
{
    public class Seeker
    {
        // In the future, we'll make some of these member variables/functions private,
        // but for now, we'll just make everything public, until we discuss it in more detail.

        public int _location;
        public List<int> _distances;

        public Seeker()
        {
            // Start at a new random position from 1-1000
            Random randomGenerator = new Random();
            _location = randomGenerator.Next(1, 1001);

            // Set up the list to track the distances we have traveled.            
            _distances = new List<int>();
        }

        public string GetMessage()
        {
            string message = "";
            
            if (_distances.Count < 2)
            {
                // We don't have enough information to know if we are closing in on them
                // or if we are running around in big steps, so we will just give a
                // generic message here.
                message = "I'm going to find you!";
            }
            else
            {
                if (_distances[_distances.Count - 1] <= _distances[_distances.Count - 2])
                {
                    // Our last movement amount was the same size or smaller than the time before,
                    // so we must be closing in on them.
                    message = "Shhh. I'm sneaking in now...";
                }
                else
                {
                    // Our last movement amount was the same or larger, so we are just wandering around
                    message = "I'm just running around, but I'll find you...";
                }
            }

            return message;
        }

        public void Move(int newLocation)
        {
            // Compute the distance we have moved since last time
            int distanceMoved = Math.Abs(_location - newLocation);
            _distances.Add(distanceMoved);

            // Update the current location
            _location = newLocation;
        }
    }
}
