using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TraceMaker
{
    class Player : GameObject
    {
        private Collider _collider;
        public Player(Texture2D texture, Vector2 position) : base(texture, position)
        {
            _collider = new Collider(texture.Bounds.Size);
        }




        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
