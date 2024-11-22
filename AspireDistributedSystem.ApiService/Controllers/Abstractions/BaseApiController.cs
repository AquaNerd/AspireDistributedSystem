using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspireDistributedSystem.ApiService.Controllers.Abstractions;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public abstract class BaseApiController : ControllerBase
{

}
