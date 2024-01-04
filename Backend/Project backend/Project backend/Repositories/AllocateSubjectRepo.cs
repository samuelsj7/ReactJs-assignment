using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Project_backend.Data;
using Project_backend.Models;
using Project_backend.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Project_backend.Repositories
{
    public class AllocateSubjectRepo : IAllocateSubject
    {
        private readonly DBService _context;


        public AllocateSubjectRepo(DBService context)
        {
            _context = context;
        }
        public void addAllocateSubject(SubjectPayload subjectPayload)
        {
            if (subjectPayload.SubjectIds == null || !subjectPayload.SubjectIds.Any())
            {
                throw new ArgumentException("No subject IDs provided");
            }

            var allocateSubjects = subjectPayload.SubjectIds.Select(subjectId => new AllocateSubject
            {
                teacherId = subjectPayload.TeacherId,
                subjectId = subjectId
            }).ToList();

            _context.AllocateSubjects.AddRange(allocateSubjects);
            _context.SaveChanges();
        }


        public bool deleteAllocateSubject(int id)
        {
            AllocateSubject allocateSubject = _context.AllocateSubjects.Find(id);
            if (allocateSubject == null)
            {

                return false;
            }
            else
            {
                _context.AllocateSubjects.Remove(allocateSubject);
                _context.SaveChanges();
                return true;
            }
        }

        public List<AllocateSubject> getAllAllocateSubjects()
        {
            return _context.AllocateSubjects.ToList();
        }

        public IEnumerable<ResultModel> getAllSubjects(int id)
        {
            string query = @"select Classrooms.className as ClassName,
                    Teachers.firstName as TeacherFirstName, 
                    Subjects.subjectName as SubjectName 
                    from  Classrooms inner join AllocateClassrooms 
                    on Classrooms.Id=AllocateClassrooms.classRoomId 
                    inner join Teachers on Teachers.Id=AllocateClassrooms.teacherId 
                    inner join AllocateSubjects on AllocateSubjects.teacherId= Teachers.Id 
                    inner join Subjects on Subjects.Id=AllocateSubjects.subjectId 
                    where Classrooms.Id= {0}";

            try
            {
                var result = _context.ResultModels.FromSqlRaw(query, id);

                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
