using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_backend.Models
{
    public class AllocateSubject
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("TeacherId")]
        public int teacherId { get; set; }
      //  public Teacher Teacher { get; set; }
        [ForeignKey("SubjectId")]
        public int subjectId { get; set; }
       // public Subject Subject { get; set; }

    }
}
