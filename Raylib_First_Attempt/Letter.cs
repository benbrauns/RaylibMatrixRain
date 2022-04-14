using Raylib_cs;
using System.Numerics;

namespace Raylib_First_Attempt
{
    internal class Letter
    {
        private Trail trail;
        public Vector2 position;
        private Vector2 velocity;
        public string letter = new string("A");


        public Letter(Trail Trail, Vector2 pos, Vector2 vel)
        {
            trail = Trail;
            position = pos;
            velocity = vel;
            /*letter = "A";*/
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

        private void Move()
        {
            position += velocity;
        }



        public void Update()
        {
            Move();
        }
    }
}
