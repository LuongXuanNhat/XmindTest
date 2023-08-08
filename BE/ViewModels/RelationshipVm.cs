using BE.ViewModels;

namespace BE.ViewModels
{
    public class RelationshipVm
    {
        public Guid _id { get; set; }
        public Guid _idEnd1 { get; set; }
        public Guid _idEnd2 { get; set; }
        public ControlPointVm _controlPoint { get; set; }
        public LineEndPointVm _lineEndPoint { get; set; }

    }
}