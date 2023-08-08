using static BE.ViewModels.RootNodeVm;

namespace BE.ViewModels
{
    public class BaseTopicVm
    {
        public Guid _id { get; set; }
        public string? _title { get; set; }
        public int? _width { get; set; }
        public List<RelationshipVm> _relationship { get; set; }
        public NotesVm _notes { get; set; }
        public string _href { get; set; }

        public List<BaseTopicVm> _children { get; set; }
        public List<BaseTopicVm> _detachedChildren { get; set; }

    }
}