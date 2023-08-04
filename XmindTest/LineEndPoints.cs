namespace XmindTest
{
    public class LineEndPoints
    {
        public LineEndPoints()
        {
            position1 = new Position();
            position2 = new Position();
        }

        private Position position1;

        public Position GetPosition1()
        {
            return position1;
        }

        internal void SetPosition1(Position value)
        {
            position1 = value;
        }

        private Position position2;

        public Position GetPosition2()
        {
            return position2;
        }

        internal void SetPosition2(Position value)
        {
            position2 = value;
        }

        internal LineEndPoints Save_Location()
        {
            // Point mousePosition = Control.MousePosition;
            int x = new Random().Next(10);
            int y = new Random().Next(10);
            position1.AddPoint(x, y);
            position2.AddPoint(x, y);
            return this;
        }
    }
}