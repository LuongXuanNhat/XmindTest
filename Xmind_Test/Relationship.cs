namespace Xmind_Test
{
    internal class Relationship
    {
        private Guid _id;
        private Guid _idTargetTopic;
        private string _title;
        private ControlPoint _controlPoint;
        private LineEndPoint _lineEndPoint;

        public Relationship(Guid id, Guid idTargetTopic, string title)
        {
            this._id = id;
            this._idTargetTopic = idTargetTopic;
            this._title = title;
            this._controlPoint = new ControlPoint();
            this._lineEndPoint = new LineEndPoint();
        }
    }
}