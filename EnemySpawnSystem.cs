using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Numerics;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame2
{
    public class EnemySpawnSystem
    {
        List<BaseClass> enemiesList = new List<BaseClass>();
        public List<BaseClass> Enemies => enemiesList;
        Random random = new Random();

        public void ESpawnSystem(Texture2D baseEnemyTexture){
            BaseClass newObject = null;
            Vector2 spawnPoint = new Vector2(800, random.Next(10, 440));

            if(random.Next(1, 60) == 1){
                int enemyType = 1; //random.Next();

                switch(enemyType){
                    case 1:
                        newObject = new Enemy(spawnPoint, baseEnemyTexture, 30, 100,100);
                    break;
                }

                if(newObject != null){
                    enemiesList.Add(newObject);
                }
            }
        }

        private void RemoveEnemy(){
            for(int i = enemiesList.Count - 1; i >=0; i--){
                if(enemiesList[i].Health <= 0){
                    enemiesList[i].isActiveEntity = false;
                }

                if(enemiesList[i].isActiveEntity == false){
                    enemiesList.RemoveAt(i);
                }
            }
        }

        public void CheckCollision(Bullet bullet){
            for (int i = 0; i < enemiesList.Count; i++)
            {
                if (enemiesList[i].GetBounds().Intersects(bullet.GetBounds()))
                {
                    enemiesList[i].Health -= bullet.Damage; 
                    bullet.isActiveProjectile = false; 
                }
            }
        }

        public void Update(){
            foreach (BaseClass bc in enemiesList)
            {
                bc.Update();
            }
            RemoveEnemy();
        }

        public void Draw(SpriteBatch spriteBatch){
            foreach(BaseClass bc in enemiesList){
                bc.Draw(spriteBatch);
            }
        }               
    }
}