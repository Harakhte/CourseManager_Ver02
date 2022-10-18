using CourseManager_Ver02.Localization;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace CourseManager_Ver02
{
    [DependsOn(
        typeof(AbpAuditLoggingDomainSharedModule),
        typeof(AbpBackgroundJobsDomainSharedModule),
        typeof(AbpFeatureManagementDomainSharedModule),
        typeof(AbpIdentityDomainSharedModule),
        typeof(AbpIdentityServerDomainSharedModule),
        typeof(AbpPermissionManagementDomainSharedModule),
        typeof(AbpSettingManagementDomainSharedModule),
        typeof(AbpTenantManagementDomainSharedModule)
        )]
    public class CourseManager_Ver02DomainSharedModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            CourseManager_Ver02GlobalFeatureConfigurator.Configure();
            CourseManager_Ver02ModuleExtensionConfigurator.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<CourseManager_Ver02DomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<CourseManager_Ver02Resource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/CourseManager_Ver02");

                options.DefaultResourceType = typeof(CourseManager_Ver02Resource);
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("CourseManager_Ver02", typeof(CourseManager_Ver02Resource));
            });
        }
    }
}
