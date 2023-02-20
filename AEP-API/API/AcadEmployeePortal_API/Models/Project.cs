using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class Project
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string FullProjectName { get; set; }
        public string ProjectCodeName { get; set; }
        public bool IsActive { get; set; }

    }
}
