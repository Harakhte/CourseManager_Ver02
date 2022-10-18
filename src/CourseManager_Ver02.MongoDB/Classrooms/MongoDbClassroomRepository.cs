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
using ClassroomManager_Ver02.Classrooms;

namespace CourseManager_Ver02.Classrooms
{
    public class MongoDbClassroomRepository
        : MongoDbRepository<CourseManager_Ver02MongoDbContext, Classroom, Guid>,
        IClassroomRepository
    {
        public MongoDbClassroomRepository(
            IMongoDbContextProvider<CourseManager_Ver02MongoDbContext> dbContextProvider
            ) : base(dbContextProvider)
        {
        }

        public async Task<Classroom> FindByNameAsync(string name)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable.FirstOrDefaultAsync(classroom => classroom.Name == name);
        }

        public async Task<List<Classroom>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable
                .WhereIf<Classroom, IMongoQueryable<Classroom>>(
                    !filter.IsNullOrWhiteSpace(),
                    classroom => classroom.Name.Contains(filter)
                )
                .OrderBy(sorting)
                .As<IMongoQueryable<Classroom>>()
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
