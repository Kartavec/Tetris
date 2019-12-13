using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    static class Field
    {
        public static int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                Console.SetWindowSize(_width, Field.HEIGHT);
                Console.SetBufferSize(_width, Field.HEIGHT);
            }
        }


        private static int _width = 40;
        public const int HEIGHT = 30;

    }
}
