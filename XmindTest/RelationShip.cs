namespace XmindTest
{
    public class RelationShip
    {
        public RelationShip()
        {
            lineEndPoints = new LineEndPoints();
            controlPoints = new ControlPoints();
        }

        private ControlPoints controlPoints;

        public ControlPoints GetControlPoints()
        {
            return controlPoints;
        }

        private void SetControlPoints(ControlPoints value)
        {
            controlPoints = value;
        }

        private string id;
        private string title;

        public string GetTitle()
        {
            return title;
        }

        private void SetTitle(string value)
        {
            title = value;
        }

        public string GetId()
        {
            return id;
        }

        private void SetId(string value)
        {
            id = value;
        }

        private LineEndPoints lineEndPoints;

        public LineEndPoints GetLineEndPoints()
        {
            return lineEndPoints;
        }

        private void SetLineEndPoints(LineEndPoints value)
        {
            lineEndPoints = value;
        }

        private string end1Id;

        public string GetEnd1Id()
        {
            return end1Id;
        }

        private void SetEnd1Id(string value)
        {
            end1Id = value;
        }

        private string end2Id;

        public string GetEnd2Id()
        {
            return end2Id;
        }

        private void SetEnd2Id(string value)
        {
            end2Id = value;
        }

        internal RelationShip Add_RelationShip(string idStart, string idEnd)
        {
            return new RelationShip()
            {
                id = Guid.NewGuid().ToString(),
                title = "Relationship",
                end1Id = idStart,
                end2Id = idEnd,
                controlPoints = new ControlPoints().Save_Location(),
                lineEndPoints = new LineEndPoints().Save_Location()
            };
        }
    }
}