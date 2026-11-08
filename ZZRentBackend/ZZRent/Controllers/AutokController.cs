using Microsoft.AspNetCore.Mvc;

namespace ZZRent.Controllers
{
    [Route("autok")]
    [ApiController]
    public class AutokController : ControllerBase
    {
        [HttpGet]
        public object GetAutok()
        {
            var autok = context.autok.ToList();
        }
    }
}
