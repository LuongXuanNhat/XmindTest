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
            href = "";
            notes = new Notes();
            relationShip = new List<RelationShip>();
            rootChild = new List<ChildrenTopic>();
        }

        public void CreateChildTopic(int id, string title)
        {
            if(this.rootChild == null)
                this.rootChild = new List<ChildrenTopic>();

            var rootChild = new ChildrenTopic();
            rootChild.CreateChild(id, title);

            this.rootChild.Add(rootChild); 
        }

        public bool FindRootChild(int idExpected)
        {
            return this.rootChild.Where(x => x.id == idExpected).FirstOrDefault() == null ? false : true;
        }
    }
}