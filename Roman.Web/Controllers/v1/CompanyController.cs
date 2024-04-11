using System.Net;
using Microsoft.AspNetCore.Mvc;
using Roman.Web.Services;

namespace Roman.Web.Controllers.v1;

[ApiController]
[Route("api/v1/company")]
public class CompanyController(ISettings settings) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    public IActionResult GetName()
    {
        return Ok(settings.CompanyName);
    }
}
