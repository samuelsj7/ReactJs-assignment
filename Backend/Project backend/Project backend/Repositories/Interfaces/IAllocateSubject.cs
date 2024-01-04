using Project_backend.Data;
using Project_backend.Models;
using System.Collections.Generic;
using System.Data;

namespace Project_backend.Repositories.Interfaces
{
    public interface IAllocateSubject
    {

        public List<AllocateSubject> getAllAllocateSubjects();
        public IEnumerable<ResultModel> getAllSubjects(int id);
       // public AllocateSubject getClassroomById(int id);
        public void addAllocateSubject(SubjectPayload subjectPayload);
       // public void updateClassroom(AllocateSubject allocateSubject);
        public bool deleteAllocateSubject(int id);
    }
}
