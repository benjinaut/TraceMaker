using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TraceMaker
{
    public delegate void function();

    class Button
    {
        Rectangle rect;
        function func;
        Texture2D texture;

        public Button(Rectangle _rect, function _func, Texture2D _texture)
        {
            rect = _rect;
            func = _func;
            texture = _texture;
        }

        public void Update(GameTime gameTime)
        {
            if(Mouse.GetState().LeftButton==ButtonState.Pressed &&rect.Intersects(new Rectangle(Mouse.GetState().Position, Point.Zero)))
            {
                func();
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rect, Color.White);
        }

    }
}
