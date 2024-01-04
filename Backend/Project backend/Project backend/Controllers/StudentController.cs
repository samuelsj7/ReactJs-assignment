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
    public class StudentController : ControllerBase
    {
        private readonly IStudent _student;

        public StudentController(IStudent student)
        {
            _student = student;
        }



        // GET: api/<StudentController>
        [HttpGet]
        public JsonResult GetAllStudents()
        {
            try
            {
                List<Student> students = _student.getAllStudent();
                return new JsonResult(students);
            }
            catch (Exception ex)
            {

                return new JsonResult($"Unhandle exception: {ex.Message}");
            }
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                Student student = _student.getStudentById(id);
                return new JsonResult(student);
            }
            catch (Exception ex)
            {
                return new JsonResult($"Unhandle exception: {ex.Message}");

            }
        }

        // POST api/<StudentController>
        [HttpPost]
        public JsonResult Post(Student student)
        {
            try
            {
                _student.addStudent(student);
                return new JsonResult("Student added successfully");
            }
            catch (Exception ex)
            {
               return new JsonResult($"Unhandle exception: {ex.Message}");
            }
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, Student student)
        {
            try
            {
                student.Id = id;
                _student.updateStudent(student);
                return new JsonResult("Student updated successfully");
            }
            catch (Exception ex)
            {
                return new JsonResult($"Unhandle exception: {ex.Message}");

            }
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {

                Student student = _student.getStudentById(id);
                _student.deleteStudent(id);
                return new JsonResult("Student deleted successfully");
            }
            catch (Exception ex)
            {

                return new JsonResult($"Unhandle exception: {ex.Message}");
            }
            

        }
    }
}
