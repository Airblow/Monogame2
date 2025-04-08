using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame2
{
    public class Enemy : BaseClass
    {
        public Enemy(Vector2 position, Texture2D texture, int size):base(position, texture, size){
            color = Color.DarkRed;
        }

        public override void Update(){
            position.X += 1;
        }

    }
}