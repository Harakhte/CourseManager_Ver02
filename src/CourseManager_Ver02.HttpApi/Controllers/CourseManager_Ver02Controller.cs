using CourseManager_Ver02.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace CourseManager_Ver02.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class CourseManager_Ver02Controller : AbpController
    {
        protected CourseManager_Ver02Controller()
        {
            LocalizationResource = typeof(CourseManager_Ver02Resource);
        }
    }
}