using Project_backend.Models;
using System.Collections.Generic;

namespace Project_backend.Repositories.Interfaces
{
    public interface IClassroom
    {
        public List<Classroom> getAllClassrooms();
        public Classroom getClassroomById(int id);
        public void addClassroom(Classroom classroom);
        public void updateClassroom(Classroom classroom);
        public bool deleteClassroom(int id);
    }
}
