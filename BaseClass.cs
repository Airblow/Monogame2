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
        protected int size;
        protected Color color;

        public BaseClass(Vector2 position, Texture2D texture, int size){
            this.position = position;
            this.texture = texture;
            this.size = size;
            color = Color.White;
        }

        public abstract void Update();
        public void Draw(SpriteBatch spriteBatch){
            Rectangle rectangle = new Rectangle((int)position.X,(int)position.Y,35,35);
            spriteBatch.Draw(texture, rectangle, color);
        }
    }
}