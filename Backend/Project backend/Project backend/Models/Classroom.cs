using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_backend.Models
{
    public class Classroom
    {
        [Key]
        public int Id { get; set; }
        public string className { get; set; }
       
    }
}
