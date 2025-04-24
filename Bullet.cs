using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using Microsoft.Xna.Framework.Graphics;

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

        public Bullet(Vextor2 position, Texture2D texture, float velocity, int size, int damage){
            this.position = position;
            this.texture = texture;
            this.velocity = velocity;
            this.size = size;
            this.damage = damage;
            color = Color.Black;
        }

        public void Update(){
            
        }

    }
}