using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_backend.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string contactPerson { get; set; }
        public int contactNo { get; set; }

        public string emailAddress { get; set; }
        public DateTime DOB { get; set; }
        public int Age { get; set; }
        [ForeignKey("ClassroomId")]
        public int classRoomId { get; set; }

        public Classroom classRoom  { get; set; }

    }
}
