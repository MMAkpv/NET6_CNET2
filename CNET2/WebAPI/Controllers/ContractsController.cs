using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        [HttpGet("GetAll")]

        public IEnumerable<Contract> GetContrats()
        {
            var dataset = Data.Serialization.LoadFromXML();
            return dataset.SelectMany(x => x.Contracts);
        }

    }
}
