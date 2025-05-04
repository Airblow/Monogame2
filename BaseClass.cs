using System.Drawing.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.DirectWrite;

namespace Monogame2
{
    public abstract class BaseClass
    {
        protected Vector2 position;
        protected Texture2D texture;
        protected int size;
        protected Color color;
        protected int health;
        protected int damage;
        public bool isActiveEntity = true;

        public Vector2 Position => position;
        
        public int Health{
            get => health;
            set => health = value;
        }

        public int Damage{
            get => damage;
        }

        public BaseClass(Vector2 position, Texture2D texture, int size, int health, int damage)
        {
            this.position = position;
            this.texture = texture;
            this.size = size;
            this.health = health;
            this.damage = damage;
            color = Color.White;
        }

        public Rectangle GetBounds(){
            return new Rectangle((int)position.X, (int)position.Y, size, size);
        }

        public abstract void Update();
        
        public void Draw(SpriteBatch spriteBatch){
            Rectangle rectangle = new Rectangle((int)position.X,(int)position.Y,size,size);
            spriteBatch.Draw(texture, rectangle, color);
        }
    }
}