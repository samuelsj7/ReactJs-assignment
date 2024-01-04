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
    public class SubjectController : ControllerBase
    {

        private readonly ISubject _subject;

        public SubjectController(ISubject subject)
        {
            _subject = subject;
        }

        // GET: api/<SubjectController>
        [HttpGet]
        public JsonResult GetAll()
        {
            try
            {
                List<Subject> subjects = _subject.getAllSubject();
                return new JsonResult(subjects);
            }
            catch (Exception ex)
            {

                return new JsonResult($"Unhandle exception: {ex.Message}");
            }
        }

        // GET api/<SubjectController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                Subject subject = _subject.getSubjectById(id);
                return new JsonResult(subject);
            }
            catch (Exception ex)
            {
                return new JsonResult($"Unhandle exception: {ex.Message}");

            }
        }

        // POST api/<SubjectController>
        [HttpPost]
        public JsonResult Post(Subject subject)
        {
            try
            {
                _subject.addSubject(subject);
                return new JsonResult("Subject added successfully");
            }
            catch (Exception ex)
            {
                return new JsonResult($"Unhandle exception: {ex.Message}");
            }
        }

        // PUT api/<SubjectController>/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, Subject subject)
        {
            try
            {
                subject.Id = id;
                _subject.updateSubject(subject);
                return new JsonResult("Subject updated successfully");
            }
            catch (Exception ex)
            {
                return new JsonResult($"Unhandle exception: {ex.Message}");

            }
        }

        // DELETE api/<SubjectController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {

                Subject subject = _subject.getSubjectById(id);
                _subject.deleteSubject(id);
                return new JsonResult("Subject deleted successfully");
            }
            catch (Exception ex)
            {

                return new JsonResult($"Unhandle exception: {ex.Message}");
            }


        }
    }
}
