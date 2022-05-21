using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace ClickPick.Controllers
{
    public class LanguageController : Controller
    {
       
        [Route("api/[Controller]")]
        [ApiController]
        public class languageController : ControllerBase
        {
            private readonly IStringLocalizer<languageController> _localizer;
            public languageController(IStringLocalizer<languageController> localizer)
            {
                _localizer = localizer;
            }
            [HttpGet]
            public IActionResult Get()
            {


                return Ok(_localizer["welcome"].Value);
            }

        }
    }
}
