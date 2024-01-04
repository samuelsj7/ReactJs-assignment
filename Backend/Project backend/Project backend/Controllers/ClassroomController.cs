using Microsoft.AspNetCore.Mvc;
using Project_backend.Models;
using Project_backend.Repositories.Interfaces;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly IClassroom _classroom;

        public ClassroomController(IClassroom classroom)
        {
            _classroom = classroom;
        }

        // GET: api/<ClassroomController>
        [HttpGet]
        public JsonResult GetAll()
        {
            try
            {
                List<Classroom> students = _classroom.getAllClassrooms();
                return new JsonResult(students);
            }
            catch (Exception ex)
            {

                return new JsonResult($"Unhandle exception: {ex.Message}");
            }
        }

        // GET api/<ClassroomController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                Classroom classroom = _classroom.getClassroomById(id);
                return new JsonResult(classroom);
            }
            catch (Exception ex)
            {
                return new JsonResult($"Unhandle exception: {ex.Message}");

            }
        }

        // POST api/<ClassroomController>
        [HttpPost]
        public JsonResult Post(Classroom classroom)
        {
            try
            {
                _classroom.addClassroom(classroom);
                return new JsonResult("Classroom added successfully");
            }
            catch (Exception ex)
            {
                return new JsonResult($"Unhandle exception: {ex.Message}");
            }
        }

        // PUT api/<ClassroomController>/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, Classroom classroom)
        {
            try
            {
                classroom.Id = id;
                _classroom.updateClassroom(classroom);
                return new JsonResult("Classroom updated successfully");
            }
            catch (Exception ex)
            {
                return new JsonResult($"Unhandle exception: {ex.Message}");

            }
        }

        // DELETE api/<ClassroomController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {

                Classroom classroom = _classroom.getClassroomById(id);
                _classroom.deleteClassroom(id);
                return new JsonResult("Classroom deleted successfully");
            }
            catch (Exception ex)
            {

                return new JsonResult($"Unhandle exception: {ex.Message}");
            }


        }
    }
}
