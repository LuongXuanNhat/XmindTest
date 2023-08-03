namespace XmindTest
{
    public class RelationShip
    {
        public RelationShip()
        {
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

        private int id;

        public int GetId()
        {
            return id;
        }

        private void SetId(int value)
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

        private int end1Id;

        public int GetEnd1Id()
        {
            return end1Id;
        }

        private void SetEnd1Id(int value)
        {
            end1Id = value;
        }

        private int end2Id;

        public int GetEnd2Id()
        {
            return end2Id;
        }

        private void SetEnd2Id(int value)
        {
            end2Id = value;
        }




    }
}