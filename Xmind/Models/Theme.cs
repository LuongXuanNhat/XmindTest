namespace Xmind.Models
{
    public class Theme
    {
        public CentralTopic centralTopic { get; set; }
        public MainTopic mainTopic { get; set; }
        public SubTopic subTopic { get; set; }
        public CalloutTopic calloutTopic { get; set; }
        public SummaryTopic summaryTopic { get; set; }
        public FloatingTopic floatingTopic { get; set; }
        public ImportantTopic importantTopic { get; set; }
        public MinorTopic minorTopic { get; set; }
        public ExpiredTopic expiredTopic { get; set; }
        public Boundary boundary { get; set; }
        public Summary summary { get; set; }
        public Relationship relationship { get; set; }
        public Map map { get; set; }
        public string skeletonThemeId { get; set; }
        public string colorThemeId { get; set; }
    }
}