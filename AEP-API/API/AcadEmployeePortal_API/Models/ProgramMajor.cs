using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class ProgramMajor
    {
        public int ProgramMajorId { get; set; }
        public int? ProgramId { get; set; }
        public int? MajorId { get; set; }

        public virtual Major Major { get; set; }
        public virtual Programs Program { get; set; }
    }
}
