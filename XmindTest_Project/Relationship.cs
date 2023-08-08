namespace XmindTest_Project
{
    public class Relationship
    {
        private Guid _id;
        private Guid _idEnd1;
        private Guid _idEnd2;
        private ControlPoint _controlPoint;
        private LineEndPoint _lineEndPoint;

        public Relationship()
        {

        }
        public Relationship(Guid id, Guid id2)
        {
            _id = Guid.NewGuid();
            _idEnd1 = id;
            _idEnd2 = id2;
            _controlPoint = new ControlPoint();
            _lineEndPoint = new LineEndPoint();
        }
    }
}