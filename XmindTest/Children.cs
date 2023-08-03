namespace XmindTest
{
    public class Children : RootBase
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

        internal Children Create_SubTopic(int numberName)
        {
            this.SetId(Guid.NewGuid().ToString());
            this.SetTitle("Subtopic " + numberName);
            this.SetHref("");
            this.SetNotes(new Notes());
            this.SetRelationShip(new List<RelationShip>());
            this.SetSubTopic(new List<Children>());
            return this;
        }
    }
}