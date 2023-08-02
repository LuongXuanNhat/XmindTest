namespace XmindTest
{
    public class Position
    {
        public int x { get; internal set; }
        public int y { get; internal set; }

        public void AddPoint(int v1, int v2)
        {
            x = v1;
            y = v2;
        }
    }
}