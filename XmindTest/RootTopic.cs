namespace XmindTest
{
    public class RootTopic : RootBase
    {
        public RootTopic() { 
            SetWidth(20);
          
        }
        private List<Children> subTopic;

        public List<Children> GetSubTopic()
        {
            return subTopic;
        }

        private void SetSubTopic(List<Children> value)
        {
            subTopic = value;
        }

        internal RootTopic Create_RootTopic_Attached(int numberName)
        {
            this.SetId(Guid.NewGuid().ToString());
            this.SetTitle("Main Topic " + numberName);
            this.SetHref("");
            this.SetNotes(new Notes());
            this.SetRelationShip(new List<RelationShip>());
            this.SetSubTopic(new List<Children>());
            this.SetWidth(25);
            return this;
        }

        internal RootTopic Create_RootTopic_Detached()
        {
            this.SetId(Guid.NewGuid().ToString());
            this.SetTitle("Floating Topic");
            this.SetHref("");
            this.SetNotes(new Notes());
            this.SetRelationShip(new List<RelationShip>());
            this.SetSubTopic(new List<Children>());
            this.SetWidth(20);
            return this;
        }

        internal void Create_SubTopic()
        {
            this.subTopic.Add(new Children().Create_SubTopic(subTopic.Count + 1));
        }

        internal void SetWidth(float width)
        {
            if (width < 10) width = 8;
            base.SetWidth(width);
        }

        internal void Delete_RootChild(Children rootChild)
        {
            this.GetSubTopic().Remove(rootChild);
        }

        internal void Convert_To_RootChild(Root root, RootTopic rootTopic_Detached)
        {
            this.SetWidth(15);
            root.GetRootTopic().Remove(this);
            Children children = new Children();
            children.SetId(this.GetId());
            children.SetTitle(this.GetTitle());
            children.SetHref(this.GetHref());
            children.SetNotes(this.GetNotes());
            children.SetRelationShip(this.GetRelationShip());
            children.SetSubTopic(this.GetSubTopic());

            rootTopic_Detached.GetSubTopic().Add(children);
        }

        internal void Convert_To_RootChild(RootTopic rootTopic_Detached)
        {
            this.SetWidth(15);
            Children children = new Children();
            children.SetId(this.GetId());
            children.SetTitle(this.GetTitle());
            children.SetHref(this.GetHref());
            children.SetNotes(this.GetNotes());
            children.SetRelationShip(this.GetRelationShip());
            children.SetSubTopic(this.GetSubTopic());

            rootTopic_Detached.GetSubTopic().Add(children);
        }

        internal void Convert_To_Detached(Root root)
        {
            this.SetWidth(20);
            root.GetRootTopic().Remove(this);
        }

        internal void Convert_To_Attached(Root root)
        {
            this.SetWidth(25);
            root.GetRootTopic().Add(this);
        }
    }
}