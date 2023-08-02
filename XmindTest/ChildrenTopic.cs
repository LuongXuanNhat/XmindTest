namespace XmindTest
{
    public class ChildrenTopic : RootTopic
    {
        public void CreateChild(int id, string title)
        {
            this.id = id;
            this.title = title;
            this.href = "";
            this.notes = new Notes();
            this.relationShip = new List<RelationShip>();
            this.rootChild = new List<ChildrenTopic>();
        }
    }
}