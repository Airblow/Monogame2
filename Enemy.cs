using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame2
{
    public class Enemy : BaseClass
    {
        public Enemy(Vector2 position, Texture2D texture):base(position, texture){
        }

        public override void Update(){
            position.X -= 1;
        }

    }
}