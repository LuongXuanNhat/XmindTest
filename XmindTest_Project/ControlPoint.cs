namespace XmindTest_Project
{
    public class ControlPoint
    {
        private Position _position;

        public ControlPoint()
        {
            _position = new Position();
        }

        internal void AddPoint(int x, int y)
        {
            _position.AddPoint(x, y);
        }
    }
}