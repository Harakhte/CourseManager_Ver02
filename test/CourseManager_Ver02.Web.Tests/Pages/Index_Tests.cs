using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace CourseManager_Ver02.Pages
{
    [Collection(CourseManager_Ver02TestConsts.CollectionDefinitionName)]
    public class Index_Tests : CourseManager_Ver02WebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
