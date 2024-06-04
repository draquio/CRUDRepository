using CRUPersonRepository.Models;
using CRUPersonRepository.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRUPersonRepository.Utility;
namespace CRUPersonRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IGenericRepository<Person> _personRepository;
        public PersonController(IGenericRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Person>> GetPersons(){
            var rsp = new Response<IEnumerable<Person>>();
            try
            {
                rsp.status = true;
                rsp.value = await _personRepository.GetAll();
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = $"An error occurred: {ex.Message}";
                return StatusCode(500, rsp);
            }
            return Ok(rsp);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var rsp = new Response<Person>();   
            try
            {
                rsp.status = true;
                rsp.value = await _personRepository.GetById(id);
                if (rsp.value == null)
                {
                    rsp.status = false;
                    rsp.msg = "Person not found";
                    return NotFound(rsp);
                }
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = $"An error occurred: {ex.Message}";
                return StatusCode(500, rsp);
            }
            return Ok(rsp);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> Create([FromBody] Person person)
        {
            var rsp = new Response<Person>();
            try
            {
                if (person == null)
                {
                    rsp.status = false;
                    rsp.msg = "Person can't be null";
                    return BadRequest(rsp);
                }
                if (!ModelState.IsValid)
                {
                    rsp.status = false;
                    rsp.msg = "Invalid data.";
                    return BadRequest(rsp);
                }
                rsp.status = true;
                rsp.value = await _personRepository.Create(person);
                rsp.msg = "Person created successfully";
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = $"An error occurred: {ex.Message}";
                return StatusCode(500, rsp);
            }
            return CreatedAtAction(nameof(GetPerson), new { id = person.Id }, rsp);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Person>> Update([FromBody] Person person, int id)
        {
            var rsp = new Response<Person>();
            try
            {
                if (!ModelState.IsValid)
                {
                    rsp.status = false;
                    rsp.msg = "Invalid data.";
                    return BadRequest(rsp);
                }
                if (person == null || person.Id != id)
                {
                    rsp.status = false;
                    rsp.msg = "Person can't be null or ID mismatch.";
                    return BadRequest(rsp);
                }
                bool respons = await _personRepository.Update(person);
                if (!respons)
                {
                    rsp.status = false;
                    rsp.msg = "Person couldn't be edited";
                    return NotFound(rsp);
                }
                rsp.status = true;
                rsp.msg = "Person updated successfully";
                rsp.value = person;
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = $"An error occurred: {ex.Message}";
                return StatusCode(500, rsp);
            }
            return Ok(rsp);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> Delete(int id)
        {
            var rsp = new Response<bool>();
            try
            {
                Person person = await _personRepository.GetById(id);
                if (person == null)
                {
                    rsp.status = false;
                    rsp.msg = "Person not found";
                    return NotFound(rsp);
                }
                rsp.status = true;
                rsp.msg = "Person deleted successfully";
                rsp.value = await _personRepository.Delete(person);
            }
            catch (Exception ex)
            {
                rsp.status= false;
                rsp.msg = $"An error occurred: {ex.Message}";
                return StatusCode(500, rsp);
            }
            return NoContent();
        } 
    }
}
