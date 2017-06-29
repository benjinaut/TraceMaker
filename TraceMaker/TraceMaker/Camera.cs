﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TraceMaker
{
    class Camera
    {
        private Vector2 _position,_origin;

        public Camera(Viewport vPort)
        {
            _origin = new Vector2(vPort.Width / 2, vPort.Height / 2);
        }
        public Matrix GetViewMatrix()
        {
            // _position = GS.I._player.GetPosition();
            _position = GS.I._player._position;
            return Matrix.CreateTranslation(new Vector3(-_position + _origin, 1));

        }
    }
}
