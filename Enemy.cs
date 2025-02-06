using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame2
{
    public class Enemy : BaseClass
    {
        public Enemy(Vector2 position, Texture2D texture):base(position,texture){
            color = Color.Red;
        }

        Random rand = new Random();

        public override void Update(){
            int r = rand.Next(1,75);
            if(r == 1){
                position.Y += 10;
            }
            if(r == 2){
                position.Y -= 10;
            }
            if(r == 3){
                position.X += 10;
            }
            if(r == 4){
                position.X -= 10;
            }
        }
    }
}