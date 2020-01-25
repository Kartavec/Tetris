using Microsoft.SmallBasic.Library;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;

namespace Tetris
{
    class Program
    {
        static int TIMER_INTERVAL = 500;

        static Object lockObj = new Object();

        static System.Timers.Timer timer;
        static Figure currentFigure;
        static FigureGenerator factory = new FigureGenerator(Field.Width / 2, 0);
        static bool gameOver = false;

        static void Main(string[] args)
        {
            DrawerProvier.Drawer.InitField();

            SetTimer();

            currentFigure = factory.GetNewFigure();
            currentFigure.Draw();
            GraphicsWindow.KeyDown += GraphicsWindow_KeyDown;
        }

        private static void GraphicsWindow_KeyDown()
        {
            Monitor.Enter(lockObj);
            var result = HandleKey(currentFigure, GraphicsWindow.LastKey);

            if (GraphicsWindow.LastKey == "Down")
                gameOver = ProcessResult(result, ref currentFigure);

            Monitor.Exit(lockObj);
        }

        private static bool ProcessResult(Result result, ref Figure currentFigure)
        {
            if (result == Result.HEAP_STRIKE || result == Result.DOWN_BORDER_SRIKE)
            {
                Field.AddFigure(currentFigure);
                Field.TryDeleteLines();

                if (currentFigure.IsOnTop())
                {
                    DrawerProvier.Drawer.WriteGameOver();
                    return true;
                }
                else
                {
                    currentFigure = factory.GetNewFigure();
                    return false;
                }
            }
            else
                return false;
        }

        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            timer = new System.Timers.Timer(TIMER_INTERVAL);
            // Hook up the Elapsed event for the timer. 
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Monitor.Enter(lockObj);
            var result = currentFigure.TryMove(Direction.DOWN);
            gameOver = ProcessResult(result, ref currentFigure);
            if (gameOver)
                timer.Stop();
            Monitor.Exit(lockObj);
        }

        private static Result HandleKey(Figure f, String key)
        {
            switch (key)
            {
                case "Left":
                    return f.TryMove(Direction.LEFT);
                case "Right":
                    return f.TryMove(Direction.RIGHT);
                case "Down":
                    return f.TryMove(Direction.DOWN);
                case "Space":
                    return f.TryRotate();
            }
            return Result.SUCCESS;
        }
    }
}
