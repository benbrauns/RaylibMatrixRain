using Raylib_cs;
using System.Numerics;

namespace Raylib_First_Attempt
{
    internal class Trail
    {
        private Game game;
        private List<Letter> letters = new List<Letter>();
        private int length, letterSize, windowWidth;
        public int windowHeight;
        private Vector2 position;
        private Vector2 velocity;
        private const int letterPadding = 2;


        public Trail(Game parent, int width, int height)
        {
            game = parent;
            windowWidth = width;
            windowHeight = height;
            Random rnd = new Random();
            length = rnd.Next(10, 30);
            letterSize = rnd.Next(0, 43) * 2 + 10;
            position = new Vector2(rnd.Next(0,width), -1 * ((letterSize * length) + (letterPadding * (length - 1))));
            velocity = new Vector2(0, rnd.Next(1, 5));
            CreateLetters();
        }


        private void CreateLetters()
        {
            for (int i = 0; i < length; i++)
            {
                Vector2 pos = new Vector2(position.X,(position.Y + (i * letterSize) + (i * letterPadding)));
                Letter letter = new Letter(this, pos,velocity);
                letters.Add(letter);
            }
        }


        public void RemoveLetter(Letter letter)
        {
            letters.Remove(letter);
        }

        private void Kill()
        {
            game.RemoveTrail(this);
        }



        private void checkPosition()
        {
            if (position.Y > windowHeight)
            {
                Kill();
            }
        }

        private void Move()
        {
            position += velocity;
        }


        public void Draw()
        {
            foreach (Letter letter in letters)
            {
                /*Raylib.DrawTextEx(Raylib.GetFontDefault,)*/
                /*Raylib.DrawText("Hello, world!", 12, 12, 20, Color.WHITE);*/
                Raylib.DrawText(letter.letter,(int)letter.position.X,(int)letter.position.Y,letterSize,Color.GREEN);
            }
        }



        public void Update()
        {
            Move();
            foreach (Letter letter in letters)
            {
                letter.Update();
            }
        }


    }
}
