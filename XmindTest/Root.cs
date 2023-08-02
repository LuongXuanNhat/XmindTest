namespace XmindTest
{
    public class Root 
    {

        public int id { get; set; }
        public string title { get; set; }
        public string href { get; set; }
        public Notes notes { get; set; }
        public List<RootTopic> rootTopic { get; set; }
        public List<RelationShip> relationShip { get; set; }

        public void CreateNewMap(int id, string title)
        {
            this.id = id;
            title = title;
            href = "";
            rootTopic = new List<RootTopic>();
            relationShip = new List<RelationShip>();

            rootTopic.Add(this.CreateAttachedRootTopic(1, "Main Topic 1"));
            rootTopic.Add(this.CreateAttachedRootTopic(2, "Main Topic 2"));
            rootTopic.Add(this.CreateAttachedRootTopic(3, "Main Topic 3"));
            rootTopic.Add(this.CreateAttachedRootTopic(4, "Main Topic 4"));

         }

        public RootTopic CreateAttachedRootTopic(int idRoot, string title)
        {
            return new RootTopic()
            {
                title = title,
                id = idRoot,
                href = "",
                notes = new Notes(),
                relationShip = new List<RelationShip>()
            };  
        }

        public RelationShip CreateRelationShip(int idEnd1, int idEnd2)
        {
            var relationship = new RelationShip()
            {
                id = 1, // id tự tăng
                end1Id = idEnd1,
                end2Id = idEnd2,
                controlPoints = new ControlPoints(),
                lineEndPoints = new LineEndPoints()
            };

            AddPoint(relationship.controlPoints, 2, 3);
            AddPoint(relationship.lineEndPoints, 2, 3);

            return relationship;
        }

        public void AddPoint(ControlPoints controlPoints,int v1, int v2)
        {
            var position = new Position();
            controlPoints.position = new Position();
            controlPoints.position.AddPoint(v1, v2);
        }
         public void AddPoint(LineEndPoints lineEndPoints,int v1, int v2)
        {
            var position = new Position();
            lineEndPoints.position = new Position();
            lineEndPoints.position.AddPoint(v1, v2);
        }

        public void DeleteRootTopic(int v)
        {
            var rootTopic = this.rootTopic.Where(x => x.id == v).First();
            this.rootTopic.Remove(rootTopic);
        }

        public bool FindRootTopic(int idExpected)
        {
            return this.rootTopic.Where(x => x.id == idExpected).FirstOrDefault() == null ? false : true;
        }

        
    }
}