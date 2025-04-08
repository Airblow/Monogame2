using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame2
{
    public class Player : BaseClass
    {
        public Player(Vector2 position, Texture2D texture, int size): base(position, texture, size){
            color = Color.Green;
        }

        public override void Update()
        {
            KeyboardState kState = Keyboard.GetState();
            if(kState.IsKeyDown(Keys.W)){
                position.Y -= 2;
            }
            if(kState.IsKeyDown(Keys.W) && kState.IsKeyDown(Keys.LeftShift)){
                position.Y -=4;
            }
            if(kState.IsKeyDown(Keys.S)){
                position.Y += 2;
            }
            if(kState.IsKeyDown(Keys.S) && kState.IsKeyDown(Keys.LeftShift)){
                position.Y +=4;
            }
            if(kState.IsKeyDown(Keys.A)){
                position.X -= 2;
            }
            if(kState.IsKeyDown(Keys.A) && kState.IsKeyDown(Keys.LeftShift)){
                position.X -=4;
            }
            if(kState.IsKeyDown(Keys.D)){
                position.X += 2;
            }
            if(kState.IsKeyDown(Keys.D) && kState.IsKeyDown(Keys.LeftShift)){
                position.X +=4;
            }
        }
    }
}