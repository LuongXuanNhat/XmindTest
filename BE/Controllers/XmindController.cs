using AutoMapper;
using BE.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using XmindTest_Project;
using static XmindTest_Project.XmindTest;

namespace BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XmindController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly XmindService _xmindService;

        public XmindController(XmindService xmindService, IMapper? mapper)
        {
            _xmindService = xmindService;
            _mapper = mapper;
        }

        [HttpGet("SpaceWork")]
        public ContentResult CreateFile()
        {
            var result = _xmindService.CreateDefault();
            var root = _mapper.Map<RootNodeVm>(result);
            var jsonResult = JsonConvert.SerializeObject(root);
            return Content(jsonResult, "application/json");
        }
    }
}
