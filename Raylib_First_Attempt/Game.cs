using Raylib_cs;

namespace Raylib_First_Attempt
{
    internal class Game
    {
        private int maxTrails, width, height;
        private List<Trail> trails = new List<Trail>();
        public Game(int Width, int Height, int MaxTrails)
        {
            width = Width;
            height = Height;
            maxTrails = MaxTrails;
        }


        private void AddTrails()
        {
            int curr_count = trails.Count();
            int amount = Math.Min(10, maxTrails - curr_count);
            for (int i = 0; i < amount; i++)
            {
                Trail trail = new Trail(this, width,height);
                trails.Add(trail);
            }
        }

        public void RemoveTrail(Trail trail)
        {
            trails.Remove(trail);
        }


        private void UpdateTrails()
        {
            AddTrails();
            List<Trail> ts = new List<Trail>(trails);
            foreach (Trail trail in ts)
            {
                trail.Update();
            }
        }

        private void DrawTrails()
        {
            foreach (Trail trail in trails)
            {
                trail.Draw();
            }
        }



        public void Run()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);

            UpdateTrails();
            DrawTrails();

            Raylib.DrawFPS(0, 0);
            Raylib.DrawText("Hello, world!", 12, 12, 20, Color.WHITE);

            Raylib.EndDrawing();
        }



    }
}
