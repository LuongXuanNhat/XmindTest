namespace XmindTest
{
    public class Children : RootTopic
    {
        public Children() {
            SetWidth(15);
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

        internal Children Create_SubTopic(int numberName)
        {
            this.SetId(Guid.NewGuid().ToString());
            this.SetTitle("Subtopic " + numberName);
            this.SetHref("");
            this.SetNotes(new Notes());
            this.SetRelationShip(new List<RelationShip>());
            this.SetSubTopic(new List<Children>());
            this.SetWidth(15);
            return this;
        }

        internal void SetWidth(float width)
        {
            if (width < 10) width = 5;
            base.SetWidth(width);
        }

        internal RootTopic Convert_To_RootTopic_Detached(RootTopic rootTopic)
        {
            this.SetWidth(20);
            rootTopic.GetSubTopic().Remove(this);
            return this as RootTopic;
        }

        internal void Move_RootChile(RootTopic rootTopic_Detached_1, RootTopic rootTopic_Detached_2)
        {
            rootTopic_Detached_1.GetSubTopic().Remove(this);
            rootTopic_Detached_2.GetSubTopic().Add(this);
        }
    }
}