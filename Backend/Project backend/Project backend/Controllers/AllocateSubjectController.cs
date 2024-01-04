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
    public class AllocateSubjectController : ControllerBase
    {
        private readonly IAllocateSubject _allocateSubject;

        public AllocateSubjectController(IAllocateSubject allocateSubject)
        {
            _allocateSubject = allocateSubject;
        }

        // GET: api/<AllocateSubjectController>
        [HttpGet]
        public JsonResult GetAll()
        {
            try
            {
                List<AllocateSubject> allocateSubjects = _allocateSubject.getAllAllocateSubjects();
                return new JsonResult(allocateSubjects);
            }
            catch (Exception ex)
            {

                return new JsonResult($"Unhandle exception: {ex.Message}");
            }
        }
        // GET api/<AllocateSubjectController>/5
        [HttpGet("{id}")]
        public JsonResult GetSubjects(int id)
        {
            try
            {
                IEnumerable<ResultModel> resultModels = _allocateSubject.getAllSubjects(id);
                return new JsonResult(resultModels);
            }
            catch (Exception ex)
            {

                return new JsonResult($"Unhandle exception: {ex.Message}");
            }
        }

        // POST api/<AllocateSubjectController>
        [HttpPost]
        public JsonResult Post([FromBody] SubjectPayload payload)
        {
            try
            {
                _allocateSubject.addAllocateSubject(payload);
                return new JsonResult("Allocate Subject added successfully");
            }
            catch (Exception ex)
            {
                return new JsonResult($"Unhandled exception: {ex.Message}");
            }
        }


        // PUT api/<AllocateSubjectController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AllocateSubjectController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                _allocateSubject.deleteAllocateSubject(id);
                return new JsonResult("Allocate Subject deleted successfully");
            }
            catch (Exception ex)
            {

                return new JsonResult($"Unhandle exception: {ex.Message}");
            }


        }
    }
}
