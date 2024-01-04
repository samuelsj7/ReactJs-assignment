using Microsoft.AspNetCore.Mvc;
using Project_backend.Data;
using Project_backend.Models;
using Project_backend.Repositories.Interfaces;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllocateClassroomController : ControllerBase
    {
        private readonly IAllocateClassroom _allocateClassroom;

        public AllocateClassroomController(IAllocateClassroom allocateClassroom)
        {
            _allocateClassroom = allocateClassroom;
        }


        // GET: api/<AllocateClassroomController>
        [HttpGet]
        public JsonResult GetAll()
        {
            try
            {
                List<AllocateClassroom> allocateClassrooms = _allocateClassroom.getAllAllocateRooms();
                return new JsonResult(allocateClassrooms);
            }
            catch (Exception ex)
            {

                return new JsonResult($"Unhandle exception: {ex.Message}");
            }
        }

        // GET api/<AllocateClassroomController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AllocateClassroomController>
        [HttpPost]
        public JsonResult Post([FromBody] ClassPayload classPayload)
        {
            try
            {
                _allocateClassroom.addAllocateRoom(classPayload);
                return new JsonResult("Allocate Room added successfully");
            }
            catch (Exception ex)
            {
                return new JsonResult($"Unhandle exception: {ex.Message}");
            }
        }

        // PUT api/<AllocateClassroomController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AllocateClassroomController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                _allocateClassroom.deleteAllocateRoom(id);
                return new JsonResult("Allocate Room deleted successfully");
            }
            catch (Exception ex)
            {

                return new JsonResult($"Unhandle exception: {ex.Message}");
            }


        }
    }
}
