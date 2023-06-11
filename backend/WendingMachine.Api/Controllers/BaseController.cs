using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WendingMachine.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        internal readonly IMapper mapper;
        public BaseController(IMapper mapper)
        {
            this.mapper = mapper;
        }
    }
}
