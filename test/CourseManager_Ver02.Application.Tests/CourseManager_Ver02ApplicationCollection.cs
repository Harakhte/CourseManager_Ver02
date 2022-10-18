using CourseManager_Ver02.MongoDB;
using Xunit;

namespace CourseManager_Ver02
{
    [CollectionDefinition(CourseManager_Ver02TestConsts.CollectionDefinitionName)]
    public class CourseManager_Ver02ApplicationCollection : CourseManager_Ver02MongoDbCollectionFixtureBase
    {

    }
}
