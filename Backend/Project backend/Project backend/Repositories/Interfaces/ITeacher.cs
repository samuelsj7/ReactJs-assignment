using Project_backend.Models;
using System.Collections.Generic;

namespace Project_backend.Repositories.Interfaces
{
    public interface ITeacher
    {
        public List<Teacher> getAllTeachers();
        public Teacher getTeacherById(int id);
        public void addTeacher(Teacher teacher);
        public void updaTeacher(Teacher teacher);
        public bool deleteTeacher(int id);
    }
}
