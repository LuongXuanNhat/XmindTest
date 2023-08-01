namespace Xmind.Models
{
    public class Attached
    {
        public string id { get; set; }
        public string title { get; set; }
        public bool titleUnedited { get; set; }
        public Notes notes { get; set; }
        public string href { get; set; }
        public List<Marker> markers { get; set; }
        public Children children { get; set; }
        public List<Boundary> boundaries { get; set; }
        public Image image { get; set; }
        public List<string> labels { get; set; }
        public Style style { get; set; }
    }
}
