using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly PeopleContext _db;
        public PersonController(PeopleContext db)
        {
            _db = db;
        }


        [HttpGet("GetAll")]
        
        public IEnumerable<Person> GetPeople()
        {
            //var db = new PeopleContext();
            return _db.Persons.Include(x => x.Contracts).Include(x => x.HomeAddress);
        }

        //hledani osoby podle e-mailu
        [HttpGet("ByEmail/{email}")]

        public Person GetPersonByEmail(string email)
        {
            //var db = new PeopleContext();
            return _db.Persons.Include(x => x.Contracts).Include(x => x.HomeAddress).Where(p => p.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }

        //osoba podle ID
        [HttpGet("ByID/{id}")]

        public Person GetPersonById(int id)
        {
            return _db.Persons.Include(x => x.Contracts).Include(x => x.Contracts).Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
