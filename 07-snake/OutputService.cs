using System;
using System.Collections.Generic;
using Raylib_cs;

namespace _07_snake
{
    public class OutputService
    {
        private Raylib_cs.Color _backgroundColor = Raylib_cs.Color.WHITE;

        public OutputService()
        {

        }

        public void OpenWindow(int width, int height, string title, int frameRate)
        {
            Raylib.InitWindow(width, height, title);
            Raylib.SetTargetFPS(frameRate);
        }

        public void CloseWindow()
        {
            Raylib.CloseWindow();
        }

        public bool IsWindowClosing()
        {
            return Raylib.WindowShouldClose();
        }

        public void StartDrawing()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(_backgroundColor);
        }

        public void EndDrawing()
        {
            Raylib.EndDrawing();
        }

        public void DrawBox(int x, int y, int width, int height)
        {
            Raylib.DrawRectangle(x, y, width, height, Raylib_cs.Color.BLUE);            
        }

        public void DrawText(int x, int y, string text, bool darkText)
        {
            Raylib_cs.Color color = Raylib_cs.Color.WHITE;

            if (darkText)
            {
                color = Raylib_cs.Color.BLACK;
            }

            Raylib.DrawText(text,
                x + Constants.DEFAULT_TEXT_OFFSET,
                y + Constants.DEFAULT_TEXT_OFFSET,
                Constants.DEFAULT_FONT_SIZE,
                color);
        }

        public void DrawActor(Actor actor)
        {
            int x = actor.GetX();
            int y = actor.GetY();
            int width = actor.GetWidth();
            int height = actor.GetHeight();

            bool darkText = true;

            if (actor.HasBox())
            {
                DrawBox(x, y, width, height);
                darkText = false;
            }

            if (actor.HasText())
            {
                string text = actor.GetText();
                DrawText(x, y, text, darkText);
            }
        }

        public void DrawActors(List<Actor> actors)
        {
            foreach (Actor actor in actors)
            {
                DrawActor(actor);
            }
        }

    }

}