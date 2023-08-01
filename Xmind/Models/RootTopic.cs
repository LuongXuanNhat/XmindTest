namespace Xmind.Models
{
    public class RootTopic
    {
        public string id { get; set; }
        public string @class { get; set; }
        public string title { get; set; }
        public Notes notes { get; set; }
        public string href { get; set; }
        public string structureClass { get; set; }
        public List<string> labels { get; set; }
        public Image image { get; set; } 
        public List<Extension> extensions { get; set; }
        public Children children { get; set; }
        public List<Boundary> boundaries { get; set; }
        public List<Summary> summaries { get; set; }

        public void AddNote(RootTopic rootTopic, string content)
        {
            this.notes.AddNote(notes, content);
        }
    }
}