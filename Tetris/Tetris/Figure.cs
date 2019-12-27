using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    abstract class Figure
    {
        const int LENGHT = 4;
        public Point[] Points = new Point[LENGHT];

        public void Draw()
        {
            foreach (Point p in Points)
            {
                p.Draw();
            }
        }

        internal Result TryMove(Direction dir)
        {
            Hide();

            Move(dir);

            var result = VerityPosition();
            if (result != Result.SUCCESS)
                Move(Reverse(dir));

            Draw();
            return result;
        }

        internal Result TryRotate()
        {
            Hide();
            Rotate();

            var result = VerityPosition();
            if (result != Result.SUCCESS)
                Rotate();

            Draw();
            return result;
        }

        private Result VerityPosition()
        {
            foreach (var p in Points)
            {
                if (p.Y >= Field.Height)
                    return Result.DOWN_BORDER_SRIKE;

                if (p.X >= Field.Width || p.X < 0 || p.Y < 0)
                    return Result.BORDER_STRIKE;

                if (Field.CheckStrike(p))
                    return Result.HEAP_STRIKE;
            }
            return Result.SUCCESS;
        }

        internal bool IsOnTop()
        {
            return Points[0].Y == 0;
        }

        public void Move(Direction dir)
        {
            foreach(var p in Points)
            {
                p.Move(dir);
            }
        }

        private Direction Reverse(Direction dir)
        {
            switch (dir)
            {
                case Direction.LEFT:
                    return Direction.RIGHT;
                case Direction.RIGHT:
                    return Direction.LEFT;
                case Direction.DOWN:
                    return Direction.UP;
                case Direction.UP:
                    return Direction.DOWN;
            }
            return dir;
        }

        public abstract void Rotate();

        public void Hide()
        {
            foreach(Point p in Points)
            {
                p.Hide();
            }
        }

    }
}
