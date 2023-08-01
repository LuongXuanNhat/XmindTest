namespace XmindTest
{
    public class ChildrenTopic
    {
        public int id { get; set; }
        public string title { get;  set; }
        public List<ChildrenTopic> childenTopic { get; set; } = null;
    }
}