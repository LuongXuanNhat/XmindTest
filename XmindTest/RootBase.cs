

namespace XmindTest
{
    public class RootBase
    {
        public RootBase() { }

        private string id;
        public string GetId() { return id; }
        protected void SetId(string id) { this.id = id; }
        private string title;
        public string GetTitle()
        {
            return title;
        }

        protected void SetTitle(string value)
        {
            title = value;
        }

        private string href;
        private Notes notes;
        private List<RelationShip> relationShip;

        public List<RelationShip> GetRelationShip()
        {
            return relationShip;
        }

        protected void SetRelationShip(List<RelationShip> value)
        {
            relationShip = value;
        }

        public Notes GetNotes()
        {
            return notes;
        }

        protected void SetNotes(Notes value)
        {
            notes = value;
        }

        public string GetHref()
        {
            return href;
        }

        protected void SetHref(string value)
        {
            href = value;
        }
        
        internal void Create_Map()
        {
            this.SetId(Guid.NewGuid().ToString());
            this.SetTitle("Central Topic");
            this.SetHref("example.com");
            this.SetNotes(new Notes());
            this.SetRelationShip(new List<RelationShip>());
        }

        internal void Add_Notes(string content)
        {
            if (notes == null) notes = new Notes();
            notes.Add_Notes(content);
        }

        internal void Add_RelationShip(RootBase root)
        {
            if (!relationShip.Any()) relationShip = new List<RelationShip>();
            relationShip.Add(new RelationShip().Add_RelationShip(this.id, root.id));
        }
    }
}