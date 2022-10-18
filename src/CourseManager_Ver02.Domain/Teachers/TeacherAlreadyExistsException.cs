using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;


namespace CourseManager_Ver02.Teachers
{
    public class TeacherAlreadyExistsException : BusinessException
    {
        public TeacherAlreadyExistsException(string name)
            : base(CourseManager_Ver02DomainErrorCodes.TeacherAlreadyExists)
        {
            WithData("name", name);
        }
    }
}