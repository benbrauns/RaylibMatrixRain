using Raylib_cs;
using static Raylib_cs.Raylib;
namespace Raylib_First_Attempt
{
    static class Program
    {
        public static void Main()
        {
            const int WIDTH = 1920;
            const int HEIGHT = 1080;
            const int FPS = 60;


            const int MAX_TRAILS = 100;
            const int screenWidth = WIDTH;
            const int screenHeight = HEIGHT;

            SetConfigFlags(ConfigFlags.FLAG_MSAA_4X_HINT);


            InitWindow(WIDTH, HEIGHT, "Hello World");
            Font font = LoadFontEx("resources/fonts/lucon.ttf", 95, null, 250);
            Game game = new Game(WIDTH, HEIGHT, MAX_TRAILS, font);
            SetTargetFPS(FPS);

            

            while (!WindowShouldClose())
            {
                game.Run();
            }
            UnloadShader(game.blurShader);
            CloseWindow();
        }
    }
}