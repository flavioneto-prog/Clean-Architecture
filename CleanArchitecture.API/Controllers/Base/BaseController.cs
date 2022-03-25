using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers.Base
{
    [ApiController]
    [Route("v{version:apiVersion}")]
    public class BaseController : ControllerBase
    {
    }
}
