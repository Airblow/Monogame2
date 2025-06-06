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
        float shotCD = 0.2f;

        public void BulletShootSystem(Vector2 position, Texture2D baseBulletTexture, GameTime gameTime){
            Bullet newObject = null;
            MouseState mState = Mouse.GetState();
            timeLastShot +=(float)gameTime.ElapsedGameTime.TotalSeconds;
          
            if(mState.LeftButton == ButtonState.Pressed && timeLastShot >= shotCD){ //&& previousMouseState.LeftButton == ButtonState.Released
                Vector2 mPosition = new Vector2(mState.X, mState.Y);
                Vector2 direction = mPosition - position;
                direction.Normalize();


                newObject = new Bullet(position, baseBulletTexture, 10, 10, 50, direction);
                if(newObject != null){
                    bulletsList.Add(newObject);
                    timeLastShot = 0f;
                }
            }
        }

        private void RemoveShot(){
            for(int i = 0; i < bulletsList.Count; i++){
                if(bulletsList[i].isActiveProjectile != true){
                    bulletsList.RemoveAt(i);
                }
            }
        }

        public void Update(EnemySpawnSystem enemySpawn){
            foreach (Bullet blts in bulletsList)
            {
                blts.Update(Mouse.GetState());
            }

            for (int i = 0; i < bulletsList.Count; i++)
            {
                enemySpawn.CheckCollision(bulletsList[i]);
            }
            RemoveShot();
        }   

        public void Draw(SpriteBatch spriteBatch){
            foreach(Bullet blts in bulletsList){
                blts.Draw(spriteBatch);
            }
        }
    }
}