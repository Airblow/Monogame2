using System.Drawing.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame2
{
    public abstract class BaseClass
    {
        protected Vector2 position;
        protected Texture2D texture;
        protected Color color;
        protected int damage;
        protected int health;

        public BaseClass(Vector2 position, Texture2D texture, int damage, int health){
            this.position = position;
            this.texture = texture;
            color = Color.White;
            this.damage = damage;
            this.health = health;
        }

        public abstract int TakeDmg();
        public abstract int DealDmg();

        public abstract void Update();
        public void Draw(SpriteBatch spriteBatch){
            Rectangle rectangle = new Rectangle((int)position.X,(int)position.Y,35,35);
            spriteBatch.Draw(texture, rectangle, color);
        }
    }
}