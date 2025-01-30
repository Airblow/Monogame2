using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame2
{
    public class BaseClass
    {
        protected Vector2 position;
        protected Texture2D texture;

        public BaseClass(Vector2 position, Texture2D texture){
            this.position = position;
            this.texture = texture;
        }
    }
}