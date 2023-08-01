namespace Xmind.Models
{
    public class Root
    {
        public Root()
        {

        }

        public string id { get; set; }
        public string @class { get; set; }
        public string title { get; set; }
        public RootTopic rootTopic { get; set; }
        public List<Relationship> relationships { get; set; }
        public List<Extension> extensions { get; set; }
        public Style style { get; set; }
        public Theme theme { get; set; }

        public void AddNote(Root root, string content)
        {
            this.rootTopic.AddNote(rootTopic, content);
        }
    }
}
