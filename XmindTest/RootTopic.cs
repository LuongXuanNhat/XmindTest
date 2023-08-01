namespace XmindTest
{
    internal class RootTopic
    {
        public int id { get; internal set; }
        public string title { get; internal set; }
        public string href { get; internal set; }
        public Notes Notes { get; internal set; }
        public List<ChildrenTopic> children { get; internal set; }
        public List<RelationShip> relationShip { get; internal set; }
    }
}