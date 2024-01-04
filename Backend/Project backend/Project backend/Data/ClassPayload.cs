using System.Collections.Generic;

namespace Project_backend.Data
{
    public class ClassPayload
    {
        public int TeacherId { get; set; }
        public List<int> ClassroomIds { get; set; }
    }
}
