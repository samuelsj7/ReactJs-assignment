using Project_backend.Data;
using Project_backend.Models;
using System.Collections.Generic;

namespace Project_backend.Repositories.Interfaces
{
    public interface IAllocateClassroom
    {

        public List<AllocateClassroom> getAllAllocateRooms();
        // public AllocateSubject getClassroomById(int id);
        public void addAllocateRoom(ClassPayload classPayload);
        // public void updateClassroom(AllocateSubject allocateSubject);
        public bool deleteAllocateRoom(int id);
    }
}
