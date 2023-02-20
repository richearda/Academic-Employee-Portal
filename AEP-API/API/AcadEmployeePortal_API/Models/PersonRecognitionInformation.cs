using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class PersonRecognitionInformation
    {
        public int PersonRecognitionInformationId { get; set; }
        public int? PersonId { get; set; }
        public string NonAcademicDistinction { get; set; }
        public bool? IsActive { get; set; }

        public virtual Person Person { get; set; }
    }
}
