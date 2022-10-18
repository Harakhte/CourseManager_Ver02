using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using CourseManager_Ver02.Data;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MongoDB;

namespace CourseManager_Ver02.MongoDB
{
    public class MongoDbCourseManager_Ver02DbSchemaMigrator : ICourseManager_Ver02DbSchemaMigrator , ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public MongoDbCourseManager_Ver02DbSchemaMigrator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            var dbContexts = _serviceProvider.GetServices<IAbpMongoDbContext>();
            var connectionStringResolver = _serviceProvider.GetRequiredService<IConnectionStringResolver>();

            foreach (var dbContext in dbContexts)
            {
                var connectionString =
                    await connectionStringResolver.ResolveAsync(
                        ConnectionStringNameAttribute.GetConnStringName(dbContext.GetType()));
                var mongoUrl = new MongoUrl(connectionString);
                var databaseName = mongoUrl.DatabaseName;
                var client = new MongoClient(mongoUrl);

                if (databaseName.IsNullOrWhiteSpace())
                {
                    databaseName = ConnectionStringNameAttribute.GetConnStringName(dbContext.GetType());
                }

                (dbContext as AbpMongoDbContext)?.InitializeCollections(client.GetDatabase(databaseName));
            }
        }
    }
}
