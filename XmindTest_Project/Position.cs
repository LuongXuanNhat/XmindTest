namespace XmindTest_Project
{
    public class Position
    {
        private double _x;
        private double _y;

        public Position()
        {
        }
        public Position(double x, double y)
        {
            _x = x;
            _y = y; 
        }

        internal double GetX()
        {
            return _x;
        }

        internal double GetY()
        {
            return _y;
        }
    }
}