using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame2
{
    public class PlayerShot
    {
        protected Vector2 position;
        protected Texture2D texture;
        protected float velocity;
        protected float size;
        protected float damage;
        protected Color color;

        public PlayerShot(Vector2 position, Texture2D texture, float velocity, float size, float damage){
            this. position = position;
            this.texture = texture;
            this.velocity = velocity;
            this.size = size;
            this.damage = damage;
            color = Color.Black;
        }

        public void Update(){
            MouseState mState = Mouse GetState();
            if(mState.LeftButton == buttonState.pressed){

                direction = mState.Position.ToVector2(); 

            }
        }
    }
}