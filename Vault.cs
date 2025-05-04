using System;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame2{
    public class Vault{

        protected Vector2 position;
        protected Texture2D texture;
        protected int size;
        protected Color color;
        protected int health; 

        public int Health{
            get => health;
            set => health = value;
        }

        public Vault(Vector2 position, Texture2D texture, int size, int health){
            this.position = position;
            this.texture = texture;
            this.size = size;
            this.health = health;
            color = Color.Yellow;
        }

        public void CheckCollision(EnemySpawnSystem eSpawn){
            for(int i = 0; i < eSpawn.Enemies.Count; i++){
                if(eSpawn.Enemies[i].GetBounds().Intersects(this.GetBounds())){
                    this.Health -= eSpawn.Enemies[i].Damage;
                    eSpawn.Enemies[i].isActiveEntity = false;
                }
            }
        }

        public void Update(EnemySpawnSystem eSpawn){
            CheckCollision(eSpawn);
        }

        public Rectangle GetBounds(){
            return new Rectangle((int)position.X, (int)position.Y, size, 480);
        }

        public void Draw(SpriteBatch spriteBatch){
            Rectangle rectangle = new Rectangle((int)position.X,(int)position.Y,size,480);
            spriteBatch.Draw(texture, rectangle, color);
        }
    }
}
