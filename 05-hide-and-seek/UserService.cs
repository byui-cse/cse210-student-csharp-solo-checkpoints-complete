using System;

namespace _05_hide_and_seek
{
    public class UserService
    {
        public void DisplayText(string text)
        {
            Console.WriteLine(text);
        }

        public int GetNumberChoice(string promptText)
        {
            Console.Write(promptText);
            string userInput = Console.ReadLine();

            // One of the benefits of abstracting this user i/o into this service class
            // is that we could add extra functionality here, such as checking
            // for a valid number and re-prompting if the user entered something invalid.
            
            // For simplicity, right now, it assumes proper input.
            int numericChoice = int.Parse(userInput);
            return numericChoice;
        }
    }
}
