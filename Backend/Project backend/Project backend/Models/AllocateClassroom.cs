using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_backend.Models
{
    public class AllocateClassroom
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("TeacherId")]
        public int teacherId { get; set; }
       // public Teacher Teacher { get; set; }
        [ForeignKey("classroomId")]
        public int classRoomId { get; set; }
       // public Classroom Classroom { get; set; }
    }
}
