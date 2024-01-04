using Microsoft.EntityFrameworkCore;
using Project_backend.Data;
using Project_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_backend.Repositories.Interfaces
{
    public class StudentRepo : IStudent
    {
        private readonly DBService _context;


        public StudentRepo(DBService context)
        {
            _context = context;
        }



        public void addStudent(Student student)
        {
            if(student == null)
            {
                throw new ArgumentException("No Student Data Found");
            }
            else
            {
                _context.Students.Add(student); 
                _context.SaveChanges();
            }
        }

        public bool deleteStudent(int id)
        {
           Student student = _context.Students.Find(id);
            if(student == null)
            {
              
                return false;   
            }
            else
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
                return true;
            }
        }

        public List<Student> getAllStudent()
        {
            return _context.Students.ToList();
        }

        public Student getStudentById(int id)
        {
           Student student= _context.Students.Find(id);
           return student;
        }

        public void updateStudent(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }
    }
}
