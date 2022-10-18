using CourseManager_Ver02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace CourseManager_Ver02.Classrooms
{
    public class ClassroomAlreadyExistsException : BusinessException
    {
        public ClassroomAlreadyExistsException(string name)
          : base(CourseManager_Ver02DomainErrorCodes.ClassroomAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
