using Project_backend.Data;
using Project_backend.Models;
using Project_backend.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_backend.Repositories
{
    public class TeacherRepo : ITeacher
    {
        private readonly DBService _context;

        public TeacherRepo(DBService context)
        {
            _context = context;
        }
        public void addTeacher(Teacher teacher)
        {

            if (teacher == null)
            {
                throw new ArgumentException("No Teacher Data Found");
            }
            else
            {
                _context.Teachers.Add(teacher);
                _context.SaveChanges();
            }
        }

        public bool deleteTeacher(int id)
        {
            Teacher teacher = _context.Teachers.Find(id);
            if (teacher == null)
            {

                return false;
            }
            else
            {
                _context.Teachers.Remove(teacher);
                _context.SaveChanges();
                return true;
            }
        }

        public List<Teacher> getAllTeachers()
        {
            return _context.Teachers.ToList();
        }

        public Teacher getTeacherById(int id)
        {
            Teacher teacher = _context.Teachers.Find(id);
            return teacher;
        }

        public void updaTeacher(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            _context.SaveChanges();
        }
    }
}
