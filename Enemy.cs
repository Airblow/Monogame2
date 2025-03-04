using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame2
{
    public class Enemy : BaseClass
    {
        public Enemy(Vector2 position, Texture2D texture, int damage, int health):base(position, texture, damage, health){
            color = Color.Red;
        }

        Random rand = new Random();

        public override int TakeDmg(int dmg)
        {
            int health = this.health;
            int returnHP = health - dmg;
            return returnHP;
        }

        public override int DealDmg()
        {
            int damage = this.damage;
            return damage;
        }
        public override void Update(){
            position.X -=2;

            if(health >= 0){

            }
        }
    }
}