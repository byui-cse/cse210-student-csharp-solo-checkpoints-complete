using System;
using System.Collections.Generic;

namespace _07_snake
{
    /// <summary>
    /// The director is responsible to direct the game, including to keep track of all
    /// the actors and to control the sequence of play.
    /// 
    /// Stereotype:
    ///     Controller
    /// </summary>
    public class Director
    {
        private bool _keepPlaying = true;

        OutputService _outputService = new OutputService();
        InputService _inputService = new InputService();
        PhysicsService _physicsService = new PhysicsService();

        Food _food = new Food();
        Snake _snake = new Snake();
        ScoreBoard _scoreBoard = new ScoreBoard();

        /// <summary>
        /// This method starts the game and continues running until it is finished.
        /// </summary>
        public void StartGame()
        {
            PrepareGame();

            while (_keepPlaying)
            {
                GetInputs();
                DoUpdates();
                DoOutputs();
            }

            Console.WriteLine("Game over!");
        }

        /// <summary>
        /// Performs any initial setup for the game.
        /// </summary>
        private void PrepareGame()
        {
            _outputService.OpenWindow(Constants.MAX_Y, Constants.MAX_X, "Snake Game", Constants.FRAME_RATE);
        }

        /// <summary>
        /// Get any input needed from the user.
        /// </summary>
        private void GetInputs()
        {
            if (_inputService.IsLeftPressed())
            {
                _snake.TurnHead(new Point(-1, 0));
            }
            else if (_inputService.IsRightPressed())
            {
                _snake.TurnHead(new Point(1, 0));
            }
            else if (_inputService.IsUpPressed())
            {
                _snake.TurnHead(new Point(0, -1));
            }
            else if (_inputService.IsDownPressed())
            {
                _snake.TurnHead(new Point(0, 1));
            }
        }

        /// <summary>
        /// Update any of the actors.
        /// </summary>
        private void DoUpdates()
        {
            _snake.Move();

            HandleFoodCollision();
            HandleBodyCollision();
        }

        /// <summary>
        /// Display the updated state of the game to the user.
        /// </summary>
        private void DoOutputs()
        {
            _outputService.StartDrawing();

            _outputService.DrawActor(_scoreBoard);
            _outputService.DrawActor(_food);
            _outputService.DrawActors(_snake.GetAllSegments());

            _outputService.EndDrawing();
        }

        private void HandleBodyCollision()
        {
            Actor head = _snake.GetHead();

            List<Actor> segments = _snake.GetCollidableSegments();

            foreach(Actor segment in segments)
            {
                if (_physicsService.IsCollision(head, segment))
                {
                    // There is a collision
                    _keepPlaying = false;
                    break;
                }
            }
        }

        private void HandleFoodCollision()
        {
            Actor head = _snake.GetHead();
            
            if (_physicsService.IsCollision(head, _food))
            {
                int points = _food.GetPoints();

                _snake.GrowTail(points);
                _scoreBoard.AddPoints(points);
                _food.Reset();
            }
        }

    }
}
