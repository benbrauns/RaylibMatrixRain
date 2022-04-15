using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;
namespace Raylib_First_Attempt
{
    internal class Letter
    {
        private Image image;
        public Texture2D texture;
        private Trail trail;
        public Vector2 position;
        private Vector2 velocity;
        private string choices = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&";
        public string letter;


        public Letter(Trail Trail, Vector2 pos, Vector2 vel)
        {
            Random rnd = new Random();
            int index = rnd.Next(0,choices.Length);
            letter = choices[index].ToString();
            trail = Trail;
            position = pos;
            velocity = vel;
            /*letter = "A";*/
            /*image = ImageText(letter, 32, Color.GREEN);
            texture = LoadTextureFromImage(image);*/

        }


        private void Kill()
        {
            trail.RemoveLetter(this);
        }



        private void checkPosition()
        {
            if (position.Y > trail.windowHeight)
            {

            }
        }

        private void Move(float dt)
        {
            position += velocity * dt;
        }



        public void Update(float dt)
        {
            Move(dt);
        }
    }
}
