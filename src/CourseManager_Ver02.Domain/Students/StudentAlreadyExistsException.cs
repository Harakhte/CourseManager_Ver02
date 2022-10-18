using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;


namespace CourseManager_Ver02.Students
{
    public class StudentAlreadyExistsException : BusinessException
    {
        public StudentAlreadyExistsException(string name)
            : base(CourseManager_Ver02DomainErrorCodes.StudentAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
