using Microsoft.AspNetCore.Mvc;

namespace DnDBeyondAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CombatController : ControllerBase
{
    public IActionResult Index()
    {
        return View();
    }
}
