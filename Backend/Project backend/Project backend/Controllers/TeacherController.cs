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
    public class TeacherController : ControllerBase
    {
        private readonly ITeacher _teacher;

        public TeacherController(ITeacher teacher)
        {
            _teacher = teacher;
        }

        // GET: api/<TeacherController>
        [HttpGet]
        public JsonResult GetAll()
        {
            try
            {
                List<Teacher> teachers = _teacher.getAllTeachers();
                return new JsonResult(teachers);
            }
            catch (Exception ex)
            {

                return new JsonResult($"Unhandle exception: {ex.Message}");
            }
        }

        // GET api/<TeacherController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                Teacher teacher = _teacher.getTeacherById(id);
                return new JsonResult(teacher);
            }
            catch (Exception ex)
            {
                return new JsonResult($"Unhandle exception: {ex.Message}");

            }
        }

        // POST api/<TeacherController>
        [HttpPost]
        public JsonResult Post(Teacher teacher)
        {
            try
            {
                _teacher.addTeacher(teacher);
                return new JsonResult("Teacher added successfully");
            }
            catch (Exception ex)
            {
                return new JsonResult($"Unhandle exception: {ex.Message}");
            }
        }

        // PUT api/<TeacherController>/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, Teacher teacher)
        {
            try
            {
                teacher.Id = id;
                _teacher.updaTeacher(teacher);
                return new JsonResult("Teacher updated successfully");
            }
            catch (Exception ex)
            {
                return new JsonResult($"Unhandle exception: {ex.Message}");

            }
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {

                Teacher teacher = _teacher.getTeacherById(id);
                _teacher.deleteTeacher(id);
                return new JsonResult("Teacher deleted successfully");
            }
            catch (Exception ex)
            {

                return new JsonResult($"Unhandle exception: {ex.Message}");
            }


        }
    }
}
