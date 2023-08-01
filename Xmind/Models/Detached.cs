namespace Xmind.Models
{
    public class Detached
    {
        public string id { get; set; }
        public string title { get; set; }
        public bool titleUnedited { get; set; }
        public List<string> labels { get; set; }
        public Position position { get; set; }
        public Children children { get; set; }
        public Style style { get; set; }
    }
}