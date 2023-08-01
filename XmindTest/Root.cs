namespace XmindTest
{
    internal class Root
    {
        public Root()
        {
        }

        public int id { get; internal set; }
        public string title { get; internal set; }
        public List<RootTopic> rootTopic { get; internal set; }
        public List<RelationShip> relationShip { get; internal set; }
    }
}