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
        private int id;

        public Tile(Texture2D texture, Vector2 position, int _id) : base(texture, position)
        {
            this.id = _id;
        }

        public bool Walkable()
        {
            return (id == 0);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position);
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
