using ISMS_API.Models;
using ISMS_API.Services;
using ISMS_API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Handlers
{
    public class ProgramHandler
    {
        private IProgramService _programService;

        public ProgramHandler(IProgramService programService)
        {
            _programService = programService;
        }

        public ValidationResult CanAddProgram(Programs program)
        {
            ValidationResult result = null;

            if (program.ProgramName != null && program.ProgramName != "")
            {
                if (program.ProgramCode != null && program.ProgramCode != "")
                {
                    if (_programService.IsProgramExist(program))
                        result = new ValidationResult("Program", "Already existing", 400);
                }
                else
                    result = new ValidationResult("Program Code", "Required", 400);
            }
            else
                result = new ValidationResult("Program Name", "Required", 400);
            return result;
        }

        public ValidationResult CanUpdateProgram(Programs program)
        {
            ValidationResult result = null;
            Programs origProgram = _programService.GetProgram(program.ProgramID);

            if (origProgram != null)
            {
                if (program.ProgramName == null || program.ProgramName == "")
                    result = new ValidationResult("Program Name", "Required", 400);
                else if (program.ProgramCode == null || program.ProgramCode == "")
                    result = new ValidationResult("Program Code", "Required", 400);
                else
                {
                    if (_programService.IsProgramExist(program))
                        result = new ValidationResult("Grade Remarks", "Already existing", 400);
                }
            }
            else
                result = new ValidationResult("Error", "Does not exist", 404);
            return result;
        }

        public ValidationResult CanCheckProgram(int programId)
        {
            ValidationResult result = null;
            Programs program = _programService.GetProgram(programId);

            if (program == null)
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }
    }
}
