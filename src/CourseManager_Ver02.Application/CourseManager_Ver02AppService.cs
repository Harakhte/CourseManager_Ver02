using System;
using System.Collections.Generic;
using System.Text;
using CourseManager_Ver02.Localization;
using Volo.Abp.Application.Services;

namespace CourseManager_Ver02
{
    /* Inherit your application services from this class.
     */
    public abstract class CourseManager_Ver02AppService : ApplicationService
    {
        protected CourseManager_Ver02AppService()
        {
            LocalizationResource = typeof(CourseManager_Ver02Resource);
        }
    }
}
