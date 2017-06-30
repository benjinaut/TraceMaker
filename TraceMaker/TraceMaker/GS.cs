using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraceMaker
{
    class GS
    {
        public static GS i;
        public Player player;
        public TileMap tileMap;
        public Camera camera;


        public static GS I
        {
            get
            {
                if (i==null)
                    i = new GS();
                return i;
            }
        }

    }
}
