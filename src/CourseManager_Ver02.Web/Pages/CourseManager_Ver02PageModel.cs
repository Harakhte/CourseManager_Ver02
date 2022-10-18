using CourseManager_Ver02.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace CourseManager_Ver02.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class CourseManager_Ver02PageModel : AbpPageModel
    {
        protected CourseManager_Ver02PageModel()
        {
            LocalizationResourceType = typeof(CourseManager_Ver02Resource);
        }
    }
}