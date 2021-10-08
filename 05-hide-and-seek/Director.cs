using System;

namespace _05_hide_and_seek
{
    public class Director
    {
        // In the future, we'll make some of these member variables/functions private,
        // but for now, we'll just make everything public, until we discuss it in more detail.
        public bool _keepPlaying;
        public Seeker _seeker;
        public Hider _hider;
        public UserService _userService;

        public Director()
        {
            _keepPlaying = true;
            _seeker = new Seeker();
            _hider = new Hider();
            _userService = new UserService();
        }

        public void StartGame()
        {
            while (_keepPlaying)
            {
                GetInputs();
                DoUpdates();
                DoOutputs();
            }
        }

        public void GetInputs()
        {
            string message = _seeker.GetMessage();
            _userService.DisplayText(message);

            string prompt = "Enter a location [1-1000]: ";
            int location = _userService.GetNumberChoice(prompt);

            _seeker.Move(location);
        }

        public void DoUpdates()
        {
            _hider.Watch(_seeker._location);
            
            // Keep playing if the hider is not found (the ! symbol means not)
            _keepPlaying = !_hider.IsFound();

        }

        public void DoOutputs()
        {
            string hint = _hider.GetHint();
            _userService.DisplayText(hint);
        }
    }
}
