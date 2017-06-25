using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TraceMaker
{
    class Tile : GameObject
    {
        private int _id;

        public Tile(Texture2D texture, Vector2 position, int id) : base(texture, position)
        {
            _id = id;
        }

        public bool Walkable()
        {
            return (_id == 0);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position);
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
