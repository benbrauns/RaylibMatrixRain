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
        private Font font;
        private Vector2 position;
        private Vector2 velocity;
        private const int letterPadding = 2;


        public Trail(Game parent, int width, int height, Font Font)
        {
            game = parent;
            windowWidth = width;
            windowHeight = height;
            font = Font;
            Random rnd = new Random();
            length = rnd.Next(10, 30);
            letterSize = rnd.Next(0, 43) * 2 + 10;
            position = new Vector2(rnd.Next(0,width), -1 * ((letterSize * length) + (letterPadding * (length - 1))));
            velocity = new Vector2(0, letterSize * 4);
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

        private void Move(float dt)
        {
            position += velocity * dt;
        }


        public void Draw()
        {
            foreach (Letter letter in letters)
            {
                /*Raylib.DrawText(letter.letter,(int)letter.position.X,(int)letter.position.Y,letterSize,Color.GREEN);*/
                Raylib.DrawTextEx(font, letter.letter, letter.position, letterSize, letterPadding, Color.GREEN);
            }
        }



        public void Update(float dt)
        {
            Move(dt);
            checkPosition();
            foreach (Letter letter in letters)
            {
                letter.Update(dt);
            }
        }


    }
}
