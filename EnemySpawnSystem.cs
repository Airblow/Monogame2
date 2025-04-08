using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame2
{
    public class EnemySpawnSystem
    {
        List<BaseClass> enemiesList = new List<BaseClass>();
        Random random = new Random();

        public void ESpawnSystem(Texture2D baseEnemyTexture){
            BaseClass newObject = null;
            Vector2 spawnPoint = new Vector2(random.Next(0,800), random.Next(10, 50));
            int enemyType = 1; //random.Next();

            switch(enemyType){
                case 1:
                    newObject = new Enemy(spawnPoint, baseEnemyTexture, 10);
                break;
            }

            if(newObject != null){
                enemiesList.Add(newObject);
            }
        }

        public void Update(){
            foreach(BaseClass bc in enemiesList){
                bc.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch){
            foreach(BaseClass bc in enemiesList){
                bc.Draw(spriteBatch);
            }
        }
                
    }
}