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
        protected float clock = 1f/60f;

        public BaseClass(Vector2 position, Texture2D texture, int size, int health){
            this.position = position;
            this.texture = texture;
            this.size = size;
            this.health = health;
            color = Color.White;
        }

        public abstract void Update();
        public void Draw(SpriteBatch spriteBatch){
            Rectangle rectangle = new Rectangle((int)position.X,(int)position.Y,35,35);
            spriteBatch.Draw(texture, rectangle, color);
        }
    }
}