using System.Threading.Tasks;
using CourseManager_Ver02.Localization;
using CourseManager_Ver02.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace CourseManager_Ver02.Web.Menus
{
    public class CourseManager_Ver02MenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var administration = context.Menu.GetAdministration();
            var l = context.GetLocalizer<CourseManager_Ver02Resource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    CourseManager_Ver02Menus.Home,
                    l["Menu:Home"],
                    "~/",
                    icon: "fas fa-home",
                    order: 0
                )
            );
            
            if (MultiTenancyConsts.IsEnabled)
            {
                administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
            }
            else
            {
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }

            administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
            administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

            var StudentMenu = new ApplicationMenuItem(
              "Student",
                  l["Students"],
                  url: "/Students"
          );
            var TeacherMenu = new ApplicationMenuItem(
               "Teacher",
                   l["Teachers"],
                   url: "/Teachers"
           );
            var CourseMenu = new ApplicationMenuItem(
              "Course",
                  l["Courses"],
                  url: "/Courses"
          );
            var ClassroomMenu =  new ApplicationMenuItem(
             "Classroom",
                 l["Classrooms"],
                 url: "/Classrooms"
         );
            context.Menu.AddItem(StudentMenu);
            context.Menu.AddItem(TeacherMenu);
            context.Menu.AddItem(CourseMenu);
            context.Menu.AddItem(ClassroomMenu);
        }
    }
}
