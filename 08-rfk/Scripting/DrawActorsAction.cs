using System.Collections.Generic;
using _08_rfk.Casting;
using _08_rfk.Services;


namespace _08_rfk.Scripting
{
    /// <summary>
    /// An action to draw all of the actors in the game.
    /// </summary>
    public class DrawActorsAction : Action
    {
        private OutputService _outputService;

        public DrawActorsAction(OutputService outputService)
        {
            _outputService = outputService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            _outputService.StartDrawing();

            foreach (List<Actor> group in cast.Values)
            {
                _outputService.DrawActors(group);
            }

            _outputService.EndDrawing();
        }

    }
}