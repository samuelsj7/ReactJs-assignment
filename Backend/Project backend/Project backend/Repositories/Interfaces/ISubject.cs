using Project_backend.Models;
using System.Collections.Generic;

namespace Project_backend.Repositories.Interfaces
{
    public interface ISubject
    {
        public List<Subject> getAllSubject();
        public Subject getSubjectById(int id);
        public void addSubject(Subject subject);
        public void updateSubject(Subject subject);
        public bool deleteSubject(int id);
    }
}
