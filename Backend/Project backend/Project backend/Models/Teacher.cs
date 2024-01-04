using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project_backend.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int contactNo { get; set; }
        public string emailAddress { get; set; }
       

    }
}
