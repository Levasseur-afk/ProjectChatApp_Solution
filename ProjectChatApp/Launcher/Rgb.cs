using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectChatApp.Launcher
{
    class Rgb
    {
        private int _r;
        private int _g;
        private int _b;
        
        public Rgb(int r, int g, int b)
        {
            this._r = r;
            this._g = g;
            this._b = b;
        }
        public int R
        {
            get
            {
                return this._r;
            }
        }
        public int G
        {
            get
            {
                return this._g;
            }
        }
        public int B
        {
            get
            {
                return this._b;
            }
        }

    }
}
