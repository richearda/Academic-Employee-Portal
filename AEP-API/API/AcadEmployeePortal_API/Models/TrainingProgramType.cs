using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class TrainingProgramType
    {
        public int TrainingProgramTypeId { get; set; }
        public string TrainingProgramTypeName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<PersonTrainingProgram> PersonTrainingPrograms { get; set; }
    }
}
