namespace XmindTest
{
    public class LineEndPoints
    {
        public LineEndPoints()
        {
        }

        public Position position { get; internal set; }

        public LineEndPoints AddPoint(int v1, int v2)
        {
            if (this.position == null)
                this.position = new Position();

            this.position.AddPoint(v1, v2);
            return this;
        }
    }
}