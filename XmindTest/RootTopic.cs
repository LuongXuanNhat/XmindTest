namespace XmindTest
{
    public class RootTopic : RootBase
    {
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
            return this;
        }

        internal void Create_SubTopic()
        {
            this.subTopic.Add(new Children().Create_SubTopic(subTopic.Count + 1));
        }
    }
}