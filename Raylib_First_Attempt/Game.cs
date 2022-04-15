using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;
using System.IO;


namespace Raylib_First_Attempt
{

    

    internal class Game
    {
        private int maxTrails, width, height;
        private List<Trail> trails = new List<Trail>();
        Font font;
        public Shader blurShader;
        RenderTexture2D target;


        public Game(int Width, int Height, int MaxTrails, Font Font)
        {
            font = Font;
            width = Width;
            height = Height;
            maxTrails = MaxTrails;
            blurShader = LoadShader(null, "resources/shaders/glsl330/blur.fs");
            target = LoadRenderTexture(Width, Height);
        }


        private void AddTrails()
        {
            int curr_count = trails.Count();
            int amount = Math.Min(10, maxTrails - curr_count);
            for (int i = 0; i < amount; i++)
            {
                Trail trail = new Trail(this, width,height, font);
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
            float dt = GetFrameTime();
            List<Trail> ts = new List<Trail>(trails);
            foreach (Trail trail in ts)
            {
                trail.Update(dt);
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
            BeginDrawing();
            ClearBackground(Color.BLACK);

            BeginTextureMode(target);
            ClearBackground(Color.BLACK);
            UpdateTrails();
            DrawTrails();

            DrawFPS(0, 0);
            EndTextureMode();
            

           
            /*Raylib.DrawText("Hello, world!", 12, 12, 20, Color.WHITE);*/

            BeginShaderMode(blurShader);
            DrawTextureRec(target.texture, new Rectangle(0, 0, target.texture.width, -target.texture.height), new Vector2(0, 0), Color.WHITE);
            EndShaderMode();


            EndDrawing();

            
        }



    }
}
