using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame2
{
    public class Player : BaseClass
    {
        public Player(Vector2 position, Texture2D texture): base(position, texture){
            color = Color.Green;
            
        }

        public override void Update()
        {
            KeyboardState kState = Keyboard.GetState();
            if(kState.IsKeyDown(Keys.W)){
                position.Y -= 2;
            }
            if(kState.IsKeyDown(Keys.S)){
                position.Y += 2;
            }
            if(kState.IsKeyDown(Keys.A)){
                position.X -= 2;
            }
            if(kState.IsKeyDown(Keys.D)){
                position.Y += 2;
            }
        }
    }
}