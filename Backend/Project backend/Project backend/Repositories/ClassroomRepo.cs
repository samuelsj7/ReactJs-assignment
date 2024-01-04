using Project_backend.Data;
using Project_backend.Models;
using Project_backend.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_backend.Repositories
{
    public class ClassroomRepo : IClassroom
    {
        private readonly DBService _context;


        public ClassroomRepo(DBService context)
        {
            _context = context;
        }
        public void addClassroom(Classroom classroom)
        {

            if (classroom == null)
            {
                throw new ArgumentException("No Classroom Data Found");
            }
            else
            {
                _context.Classrooms.Add(classroom);
                _context.SaveChanges();
            }
        }

        public bool deleteClassroom(int id)
        {
            Classroom classroom = _context.Classrooms.Find(id);
            if (classroom == null)
            {

                return false;
            }
            else
            {
                _context.Classrooms.Remove(classroom);
                _context.SaveChanges();
                return true;
            }
        }

        public List<Classroom> getAllClassrooms()
        {
            return _context.Classrooms.ToList();
        }

        public Classroom getClassroomById(int id)
        {
            Classroom classroom = _context.Classrooms.Find(id);
            return classroom;
        }

        public void updateClassroom(Classroom classroom)
        {
            _context.Classrooms.Update(classroom);
            _context.SaveChanges();
        }
    }
}
