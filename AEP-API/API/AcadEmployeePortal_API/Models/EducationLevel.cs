using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class EducationLevel
    {
        public int EducationLevelId { get; set; }
        public string LevelName { get; set; }
        public bool? IsActive { get; set; }
        public virtual ICollection<PersonEducationalBackground> PersonEducationalBackgrounds { get; set; }
    }
}
