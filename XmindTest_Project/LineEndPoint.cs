namespace XmindTest_Project
{
    public class LineEndPoint
    {
        private Position _position;

        public LineEndPoint()
        {
            _position = new Position();
        }

        internal void AddPoint(int x, int y)
        {
            _position.AddPoint(x, y);
        }
    }
}