namespace XmindTest
{
    public class RootTopic : Root
    {
        public RootTopic() { }
        public List<ChildrenTopic> rootChild { get; set; }

        public void CreateDetachedRootTopic(int id, string title)
        {
            this.title = title;
            this.id = id;
            this.href = "";
            this.notes = new Notes();
            this.relationShip = new List<RelationShip>();
            this.rootChild = new List<ChildrenTopic>();
        }

        public void CreateChildTopic(int id, string title)
        {
            if(this.rootChild == null)
                this.rootChild = new List<ChildrenTopic>();

            var Child = new ChildrenTopic();
            Child.CreateChild(id, title);

            this.rootChild.Add(Child); 
        }

        public bool FindRootChild(int idExpected)
        {
            return this.rootChild.Where(x => x.id == idExpected).FirstOrDefault() == null ? false : true;
        }
    }
}