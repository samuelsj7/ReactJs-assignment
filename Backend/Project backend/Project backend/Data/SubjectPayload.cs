using System.Collections.Generic;

namespace Project_backend.Data
{
    public class SubjectPayload
    {
        public int TeacherId { get; set; }
        public List<int> SubjectIds { get; set; }

    }
}
