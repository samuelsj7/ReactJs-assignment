using Project_backend.Data;
using Project_backend.Models;
using Project_backend.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_backend.Repositories
{
    public class AllocateClassRoomRepo : IAllocateClassroom
    {
        private readonly DBService _context;

        public AllocateClassRoomRepo(DBService context)
        {
            _context = context;
        }
        public void addAllocateRoom(ClassPayload classPayload)
        {
            if (classPayload.ClassroomIds == null || !classPayload.ClassroomIds.Any())
            {
                throw new ArgumentException("No classroom IDs provided");
            }

            var allocateRooms = classPayload.ClassroomIds.Select(classroomId => new AllocateClassroom
            {
                teacherId = classPayload.TeacherId,
                classRoomId = classroomId
            }).ToList();

            _context.AllocateClassrooms.AddRange(allocateRooms);
            _context.SaveChanges();
        }


        public bool deleteAllocateRoom(int id)
        {
            AllocateClassroom allocateClassroom = _context.AllocateClassrooms.Find(id);
            if (allocateClassroom == null)
            {

                return false;
            }
            else
            {
                _context.AllocateClassrooms.Remove(allocateClassroom);
                _context.SaveChanges();
                return true;
            }
        }

        public List<AllocateClassroom> getAllAllocateRooms()
        {
            return _context.AllocateClassrooms.ToList();
        }
    }
}
