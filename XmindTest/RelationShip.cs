namespace XmindTest
{
    public class RelationShip
    {
        public RelationShip()
        {
        }

        public ControlPoints controlPoints { get; internal set; }
        public int id { get; internal set; }
        public LineEndPoints lineEndPoints { get; internal set; }
        public int end1Id { get; internal set; }
        public int end2Id { get; internal set; }
    }
}