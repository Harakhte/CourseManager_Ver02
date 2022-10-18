using System;
using Mongo2Go;

namespace CourseManager_Ver02.MongoDB
{
    public class CourseManager_Ver02MongoDbFixture : IDisposable
    {
        private static readonly MongoDbRunner MongoDbRunner;
        public static readonly string ConnectionString;

        static CourseManager_Ver02MongoDbFixture()
        {
            MongoDbRunner = MongoDbRunner.Start(singleNodeReplSet: true, singleNodeReplSetWaitTimeout: 20);
            ConnectionString = MongoDbRunner.ConnectionString;
        }

        public void Dispose()
        {
            MongoDbRunner?.Dispose();
        }
    }
}
