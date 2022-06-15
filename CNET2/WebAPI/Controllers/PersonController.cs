using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet("GetAll")]
        
        public List<Person> GetPeople()
        {
            var dataset = Data.Serialization.LoadFromXML();
            return dataset;
        }

        //hledani osoby podle e-mailu
        [HttpGet("ByEmail/{email}")]

        public Person GetPersonByEmail(string email)
        {
            var dataset = Data.Serialization.LoadFromXML();
            return (dataset.Where(p => p.Email.ToLower() == email.ToLower()).FirstOrDefault());
        }
    }
}
