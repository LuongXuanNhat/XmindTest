namespace XmindTest
{
    public class Position
    {
        private int x;

        public int Getx()
        {
            return x;
        }

        private void Setx(int value)
        {
            x = value;
        }

        private int y;

        public int GetY()
        {
            return y;
        }

        private void SetY(int value)
        {
            y = value;
        }

        public void AddPoint(int v1, int v2)
        {
            x = v1;
            y = v2;
        }
    }
}