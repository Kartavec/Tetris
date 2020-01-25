using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    interface IDrawer
    {
        void DrawPoint(int x, int y);

        void HidePoint(int x, int y);

        void WriteGameOver();

        void InitField();
    }
}
