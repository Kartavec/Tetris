using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    class ConsoleDrawer2 : IDrawer
    {
        public void DrawPoint(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write('#');
            Console.SetCursorPosition(0, 0);
        }

        public void HidePoint(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            Console.SetCursorPosition(0, 0);
        }
    }
}
