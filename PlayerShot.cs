using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame2
{
    public class PlayerShot
    {
        List<Bullet> bulletsList = new List<Bullet>();
        float timeLastShot = 0f;
        float shotCD = 0.5f;
        MouseState previousMouseState;
        GameTime gameTime;

        public void BulletShootSystem(Vector2 position, Texture2D baseBulletTexture){
            Bullet newObject = null;
            MouseState mState = Mouse.GetState();
            timeLastShot +=(float)gameTime.ElapsedGameTime.TotalSeconds;
          
            if(mState.LeftButton == ButtonState.Pressed){ //&& previousMouseState.LeftButton == ButtonState.Released
                Vector2 mPosition = new Vector2(mState.X, mState.Y);
                Vector2 direction = mPosition - position;
                direction.Normalize();


                newObject = new Bullet(position, baseBulletTexture, 5, 10, 100, direction);
                if(newObject != null){
                    bulletsList.Add(newObject);
                }
            }
            previousMouseState = mState;
        }
        
        public void Update(){
            foreach(Bullet blts in bulletsList){
                blts.Update(Mouse.GetState());
            }
        }   

        public void Draw(SpriteBatch spriteBatch){
            foreach(Bullet blts in bulletsList){
                blts.Draw(spriteBatch);
            }
        }
    }
}