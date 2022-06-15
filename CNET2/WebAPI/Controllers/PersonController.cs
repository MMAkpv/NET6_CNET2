using Data;
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
        
        public IEnumerable<Person> GetPeople()
        {
            var db = new PeopleContext();
            return db.Persons;
        }

        //hledani osoby podle e-mailu
        [HttpGet("ByEmail/{email}")]

        public Person GetPersonByEmail(string email)
        {
            var db = new PeopleContext();
            return db.Persons.Where(p => p.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }
    }
}
