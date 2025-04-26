using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Monogame2
{
    public class Bullet
    {
        protected Vector2 position;
        protected Texture2D texture;
        protected float velocity;
        protected int size;
        protected int damage;
        protected Color color;
        protected Vector2 direction;

        public Bullet(Vector2 position, Texture2D texture, float velocity, int size, int damage, Vector2 direction){
            this.position = position;
            this.texture = texture;
            this.velocity = velocity;
            this.size = size;
            this.damage = damage;
            color = Color.Black;
            this.direction = direction;
        }

        public void Update(MouseState mState){
            position += direction * velocity;
        }

        public void Draw(SpriteBatch spriteBatch){
            Rectangle rectangle = new Rectangle((int)position.X,(int)position.Y,size,size);
            spriteBatch.Draw(texture, rectangle, color);
        }
    }
}