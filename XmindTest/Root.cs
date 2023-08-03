using System.ComponentModel.DataAnnotations;

namespace XmindTest
{
    public class Root : RootBase
    {
        private List<RootTopic> rootTopic;

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
            this.SetId(Guid.NewGuid().ToString());
            this.SetTitle("Central Topic");
            this.SetHref("");
            this.SetNotes(new Notes());
            this.SetRelationShip(new List<RelationShip>());
            this.rootTopic = new List<RootTopic>();

            this.rootTopic.Add(new RootTopic().Create_RootTopic_Attached(rootTopic.Count + 1));
            this.rootTopic.Add(new RootTopic().Create_RootTopic_Attached(rootTopic.Count + 1));
            this.rootTopic.Add(new RootTopic().Create_RootTopic_Attached(rootTopic.Count + 1));
            this.rootTopic.Add(new RootTopic().Create_RootTopic_Attached(rootTopic.Count + 1));
            


        }

        internal void Create_RootTopic_Attached()
        {
            this.rootTopic.Add(new RootTopic().Create_RootTopic_Attached(rootTopic.Count + 1));
        }
    }
}
