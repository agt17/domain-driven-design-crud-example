using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingExam.Domain.BusinessEntities
{
    public class EnrollmentEntity
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }

        public virtual StudentEntity Student { get; set; }
        public virtual SubjectEntity Subject { get; set; }
    }
}
