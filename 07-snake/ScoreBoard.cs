using System;

namespace _07_snake
{
    class ScoreBoard : Actor
    {
        private int _points = 0;

        public ScoreBoard()
        {
            _position = new Point(1, 0);
            _width = 0;
            _height = 0;
            
            UpdateText();
        }

        public void AddPoints(int points)
        {
            _points += points;
            UpdateText();
        }

        private void UpdateText()
        {
            _text = $"Score: {_points}";
        }
    }

}