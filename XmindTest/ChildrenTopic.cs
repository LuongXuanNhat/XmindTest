namespace XmindTest
{
    public class ChildrenTopic : RootTopic
    {
        public ChildrenTopic CreateChild(int id, string title)
        {
            return new ChildrenTopic()
            {
                id = id,
                title = title,
                href = "",
                notes = new Notes(),
                relationShip = new List<RelationShip>()
            };
        }
    }
}