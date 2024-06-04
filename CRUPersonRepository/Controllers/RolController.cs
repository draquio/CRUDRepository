using CRUPersonRepository.Models;
using CRUPersonRepository.Repository.Interface;
using CRUPersonRepository.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CRUPersonRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IGenericRepository<Rol> _rolRepository;

        public RolController(IGenericRepository<Rol> rolRepository)
        {
            _rolRepository = rolRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetRols()
        {
            var rsp = new Response<IEnumerable<Rol>>();
            try
            {
                rsp.status = true;
                rsp.value = await _rolRepository.GetAll();
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
        public async Task<ActionResult<Rol>> GetRol(int id) { 
            var rsp = new Response<Rol>();
            try
            {
                rsp.value = await _rolRepository.GetById(id);
                if (rsp.value == null)
                {
                    rsp.status = false;
                    rsp.msg = "Rol not found";
                    return NotFound(rsp);
                }
                rsp.status = true;
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
        public async Task<ActionResult<Rol>> Create(Rol rol)
        {
            var rsp = new Response<Rol>();
            try
            {
                if (rol == null)
                {
                    rsp.status = false;
                    rsp.msg = "Rol cant be null";
                    return BadRequest(rsp);
                }
                rsp.status = true;
                rsp.value = await _rolRepository.Create(rol);
                rsp.msg = "Rol created successfully.";
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = $"An error occurred: {ex.Message}";
                return StatusCode(500, rsp);
            }
            return CreatedAtAction(nameof(GetRol), new { id = rol.Id }, rsp);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Rol>> Update(Rol rol, int id)
        {
            var rsp = new Response<Rol>();
            try
            {
                if (rol == null || rol.Id != id)
                {
                    rsp.msg = "Rol couldn't be found or ID mismatch.";
                    rsp.status = false;
                    return NotFound(rsp);
                }
                bool respons = await _rolRepository.Update(rol);
                if (!respons)
                {
                    rsp.status = false;
                    rsp.msg = "Rol couldnt be edited";
                    return BadRequest(rsp);
                }

                rsp.status = true;
                rsp.msg = "Rol updated successfully.";
                rsp.value = rol;
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = $"An error occurred: {ex.Message}";
                return StatusCode(500, rsp);
            }
            return Ok(rsp);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Rol>> Delete(int id)
        {
            var rsp = new Response<Rol>();
            try
            {
                Rol rol = await _rolRepository.GetById(id);
                if (rol == null)
                {
                    rsp.status = false;
                    rsp.msg = "Rol not found";
                    return NotFound(rsp);
                }
                bool respons = await _rolRepository.Delete(rol);
                if (!respons)
                {
                    rsp.status = false;
                    rsp.msg = "Rol couldn't be deleted";
                    return BadRequest(rsp);
                }
                rsp.status = true;
                rsp.value = rol;
                rsp.msg = "Rol deleted successfully";
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = $"An error occurred: {ex.Message}";
                return StatusCode(500, rsp);
            }
            return NoContent();
        }
    }
}
