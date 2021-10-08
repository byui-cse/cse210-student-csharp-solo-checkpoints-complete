using System;
using System.Collections.Generic;

namespace _05_hide_and_seek
{
    public class Hider
    {
        // In the future, we'll make some of these member variables/functions private,
        // but for now, we'll just make everything public, until we discuss it in more detail.

        public int _location;
        public List<int> _distances;

        public Hider()
        {
            // Start at a new random position from 1-1000
            Random randomGenerator = new Random();
            _location = randomGenerator.Next(1, 1001);

            _distances = new List<int>();
        }

        public void Watch(int seekerLocation)
        {
            // Compute the distance from the seeker
            int distance = Math.Abs(_location - seekerLocation);

            // Add this distance to the end of our list
            _distances.Add(distance);
        }

        public string GetHint()
        {
            string hint = "";

            if (_distances.Count < 2)
            {
                // we don't have enough information to know if they are getting
                // warmer or colder, so just give a generic message
                hint = "(-.-) Maybe I'll take a nap.";
            }
            else
            {
                if (IsFound())
                {
                    hint = "(;.;) You found me!";
                }
                else if (_distances[_distances.Count - 1] > _distances[_distances.Count - 2])
                {
                    // the latest distance is further away than before
                    hint = "(^.^) Getting colder!";
                }
                else
                {
                    // The latest distance is the same or closer
                    hint = "(>.<) Getting warmer!";
                }
            }

            return hint;
        }

        public bool IsFound()
        {
            return _distances[_distances.Count - 1] == 0;
        }
    }
}
