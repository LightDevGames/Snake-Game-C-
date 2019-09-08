namespace Snake
{
    public class Mouse
    {
        private readonly int x;
        private readonly int y;
        public int X
        {
            get { return x; }
        }
        public int Y
        {
            get { return y; }
        }

        public Mouse(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
