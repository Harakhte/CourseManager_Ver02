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

namespace CourseManager_Ver02.Students
{
    public class MongoDbStudentRepository
        : MongoDbRepository<CourseManager_Ver02MongoDbContext, Student, Guid>,
        IStudentRepository
    {
        public MongoDbStudentRepository(
            IMongoDbContextProvider<CourseManager_Ver02MongoDbContext> dbContextProvider
            ) : base(dbContextProvider)
        {
        }

        public async Task<Student> FindByNameAsync(string name)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable.FirstOrDefaultAsync(student => student.Name == name);
        }

        public async Task<List<Student>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable
                .WhereIf<Student, IMongoQueryable<Student>>(
                    !filter.IsNullOrWhiteSpace(),
                    student => student.Name.Contains(filter)
                )
                .OrderBy(sorting)
                .As<IMongoQueryable<Student>>()
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
