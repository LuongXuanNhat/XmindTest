using System.ComponentModel.DataAnnotations;

namespace XmindTest
{
    public class Root : RootBase
    {
        private List<RootTopic> rootTopic;

        public Root()
        {
            this.SetId(Guid.NewGuid().ToString());
            this.SetTitle("Central Topic");
            this.SetHref("");
            this.SetNotes(new Notes());
            this.SetRelationShip(new List<RelationShip>());
            this.rootTopic = new List<RootTopic>();
            this.SetWidth(40);
        }

        public List<RootTopic> GetRootTopic()
        {
            return rootTopic;
        }

        private void SetRootTopic(List<RootTopic> value)
        {
            rootTopic = value;
        }

        internal void Create_Map()
        {
            this.rootTopic.Add(new RootTopic().Create_RootTopic_Attached(rootTopic.Count + 1));
            this.rootTopic.Add(new RootTopic().Create_RootTopic_Attached(rootTopic.Count + 1));
            this.rootTopic.Add(new RootTopic().Create_RootTopic_Attached(rootTopic.Count + 1));
            this.rootTopic.Add(new RootTopic().Create_RootTopic_Attached(rootTopic.Count + 1));
        }

        internal void Create_RootTopic_Attached()
        {
            this.rootTopic.Add(new RootTopic().Create_RootTopic_Attached(rootTopic.Count + 1));
        }

        internal void SetWidth(float width)
        {
            if (width < 10) width = 10;
            base.SetWidth(width);
        }

        internal void Remove_RelationShip(RelationShip relationShip)
        {
            this.GetRelationShip().Remove(relationShip);
        }

        internal void Convert_To_RootTopic_Attached(Children children)
        {
            children.SetWidth(25);
            rootTopic.Add(children as RootTopic);
        }

        internal void Delete_RootTopic(RootTopic rootTopic)
        {
            this.GetRootTopic().Remove(rootTopic);
        }

    }
}
