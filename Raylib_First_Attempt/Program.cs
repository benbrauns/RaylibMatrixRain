using Raylib_cs;

namespace Raylib_First_Attempt
{
    static class Program
    {
        public static void Main()
        {
            const int WIDTH = 1920;
            const int HEIGHT = 1080;
            const int FPS = 240;


            const int MAX_TRAILS = 100;



            Game game = new Game(WIDTH, HEIGHT, MAX_TRAILS);
            Raylib.InitWindow(WIDTH, HEIGHT, "Hello World");
            Raylib.SetTargetFPS(FPS);

            while (!Raylib.WindowShouldClose())
            {
                game.Run();
            }

            Raylib.CloseWindow();
        }
    }
}