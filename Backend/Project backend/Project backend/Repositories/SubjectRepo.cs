using Project_backend.Data;
using Project_backend.Models;
using Project_backend.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_backend.Repositories
{
    public class SubjectRepo : ISubject
    {
        private readonly DBService _context;

        public SubjectRepo(DBService context)
        {
            _context = context;
        }
        public void addSubject(Subject subject)
        {

            if (subject == null)
            {
                throw new ArgumentException("No Subject Data Found");
            }
            else
            {
                _context.Subjects.Add(subject);
                _context.SaveChanges();
            }
        }

        public bool deleteSubject(int id)
        {
            Subject subject = _context.Subjects.Find(id);
            if (subject == null)
            {

                return false;
            }
            else
            {
                _context.Subjects.Remove(subject);
                _context.SaveChanges();
                return true;
            }
        }

        public List<Subject> getAllSubject()
        {
            return _context.Subjects.ToList();
        }

        public Subject getSubjectById(int id)
        {
            Subject subject = _context.Subjects.Find(id);
            return subject;
        }

        public void updateSubject(Subject subject)
        {
            _context.Subjects.Update(subject);
            _context.SaveChanges();
        }
    }
}
