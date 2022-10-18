using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace CourseManager_Ver02.Courses
{
    public class CourseAlreadyExistsException : BusinessException
    {
        public CourseAlreadyExistsException(string name)
          : base(CourseManager_Ver02DomainErrorCodes.CourseAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
