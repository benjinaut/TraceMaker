using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TraceMaker
{
    abstract class GameObject
    {
        protected Texture2D _texture;
        protected Vector2 _position;

        protected GameObject(Texture2D texture, Vector2 position)
        {
            _position = position;
            _texture = texture;
        }

        public Vector2 GetPosition()
        {
            return _position;
        }

        public Texture2D GetTexture()
        {
            return _texture;
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
