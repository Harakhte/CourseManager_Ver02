using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace CourseManager_Ver02.Web
{
    [Dependency(ReplaceServices = true)]
    public class CourseManager_Ver02BrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "CourseManager_Ver02";
    }
}