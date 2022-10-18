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

namespace CourseManager_Ver02.Teachers
{
    public class MongoDbTeacherRepository
        : MongoDbRepository<CourseManager_Ver02MongoDbContext, Teacher, Guid>,
        ITeacherRepository
    {
        public MongoDbTeacherRepository(
            IMongoDbContextProvider<CourseManager_Ver02MongoDbContext> dbContextProvider
            ) : base(dbContextProvider)
        {
        }

        public async Task<Teacher> FindByNameAsync(string name)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable.FirstOrDefaultAsync(teacher => teacher.Name == name);
        }

        public async Task<List<Teacher>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable
                .WhereIf<Teacher, IMongoQueryable<Teacher>>(
                    !filter.IsNullOrWhiteSpace(),
                    teacher => teacher.Name.Contains(filter)
                )
                .OrderBy(sorting)
                .As<IMongoQueryable<Teacher>>()
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
