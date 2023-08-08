using AutoMapper;
using BE.ViewModels;
using XmindTest_Project;

namespace BE.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BaseTopic, BaseTopicVm>();
            CreateMap<Relationship, RelationshipVm>();
            CreateMap<Notes, NotesVm>();
            CreateMap<ControlPoint, ControlPointVm>();
            CreateMap<LineEndPoint, LineEndPointVm>();
            CreateMap<RootNode, RootNodeVm>();

        }
    }
}
