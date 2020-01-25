using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SmallBasic.Library;

namespace TetrisGui
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphicsWindow.Width = 100;
            GraphicsWindow.Height = 100;

            GraphicsWindow.BackgroundColor = "LightBlue";

            GraphicsWindow.PenColor = "Red";
            GraphicsWindow.DrawRectangle(20, 20, 10, 10);
        }
    }
}
