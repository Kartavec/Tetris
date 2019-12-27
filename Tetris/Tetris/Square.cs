namespace Tetris
{
    class Square : Figure
    {
        public Square(int x, int y, char sym)
        {
            Points[0] = new Point(x, y, sym);
            Points[1] = new Point(x + 1, y, sym);
            Points[2] = new Point(x, y + 1, sym);
            Points[3] = new Point(x + 1, y + 1, sym);
            Draw();
        }

        public override void Rotate(Point[] pList)
        {
            
        }
    }
}
