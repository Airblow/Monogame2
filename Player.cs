
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;

namespace Monogame2
{
    public class Player : BaseClass
    {
        public Player(Vector2 position, Texture2D texture, int size, int health, int damage): base(position, texture, size, health, damage){
            color = Color.Green;
        }

        private float velocity;

        public override void Update()
        {
            KeyboardState kState = Keyboard.GetState();
            Vector2 movement = Vector2.Zero;

            if(kState.IsKeyDown(Keys.W)){
                movement.Y -= 2;
            }
            if(kState.IsKeyDown(Keys.S)){
                movement.Y += 2;
            }
            if(kState.IsKeyDown(Keys.A)){
                movement.X -= 2;
            }
            if(kState.IsKeyDown(Keys.D)){
                movement.X += 2;
            }
          
            if(kState.IsKeyDown(Keys.LeftShift)){
                velocity = 5f;
            }
            else{
                velocity = 3f;
            }

            if(movement.Length() > 0){
                movement.Normalize();
            }
            position += movement * velocity;
        }
    }
}