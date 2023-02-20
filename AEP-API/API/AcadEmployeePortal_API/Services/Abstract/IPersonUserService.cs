using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface IPersonUserService
    {
        PersonUser GetPersonByUserId(int userId);
    }
}
