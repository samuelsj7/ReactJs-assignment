using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_backend.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        public string subjectName { get; set; }
        
    }
}
