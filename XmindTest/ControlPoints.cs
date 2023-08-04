using System.Drawing;
namespace XmindTest
{
    public class ControlPoints
    {
        
        private Position position1;

        public Position GetPosition1()
        {
            return position1;
        }

        private void SetPosition1(Position value)
        {
            position1 = value;
        }

        private Position position2;

        public ControlPoints()
        {
            position1 = new Position();
            position2 = new Position();
        }

        public Position GetPosition2()
        {
            return position2;
        }

        private void SetPosition2(Position value)
        {
            position2 = value;
        }

        internal ControlPoints Save_Location()
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