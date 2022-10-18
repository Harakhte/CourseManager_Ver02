using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;
using CourseManager_Ver02.MongoDB;

namespace CourseManager_Ver02.Courses
{
    public class MongoDbCourseRepository
        : MongoDbRepository<CourseManager_Ver02MongoDbContext, Course, Guid>,
        ICourseRepository
    {
        public MongoDbCourseRepository(
            IMongoDbContextProvider<CourseManager_Ver02MongoDbContext> dbContextProvider
            ) : base(dbContextProvider)
        {
        }

        public async Task<Course> FindByNameAsync(string name)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable.FirstOrDefaultAsync(course => course.Name == name);
        }

        public async Task<List<Course>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable
                .WhereIf<Course, IMongoQueryable<Course>>(
                    !filter.IsNullOrWhiteSpace(),
                    course => course.Name.Contains(filter)
                )
                .OrderBy(sorting)
                .As<IMongoQueryable<Course>>()
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
