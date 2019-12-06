using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    class Figure
    {
        protected Point[] points = new Point[4];

        public void Draw()
        {
            foreach (Point p in points)
            {
                p.Draw();
            }
        }
    }
}
