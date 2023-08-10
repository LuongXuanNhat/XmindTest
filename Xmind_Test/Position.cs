namespace Xmind_Test
{
    internal class Position
    {
        private int x;
        private int y;

        public Position()
        {
        }

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        internal int GetX()
        {
            return x;
        }

        internal int GetY()
        {
            return y;
        }
    }
}