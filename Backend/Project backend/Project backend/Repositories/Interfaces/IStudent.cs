using Project_backend.Models;
using System.Collections.Generic;

namespace Project_backend.Repositories.Interfaces
{
    public interface IStudent
    {
        public List<Student> getAllStudent();
        public Student getStudentById(int id);
        public void addStudent(Student student);
        public void updateStudent(Student student);
        public bool deleteStudent(int id);

    }
}
