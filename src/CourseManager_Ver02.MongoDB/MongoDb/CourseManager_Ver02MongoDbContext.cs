using ClassroomManager_Ver02.Classrooms;
using CourseManager_Ver02.Courses;
using CourseManager_Ver02.Students;
using CourseManager_Ver02.Teachers;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace CourseManager_Ver02.MongoDB
{
    [ConnectionStringName("Default")]
    public class CourseManager_Ver02MongoDbContext : AbpMongoDbContext
    {
        public IMongoCollection<Student> Students => Collection<Student>();
        public IMongoCollection<Teacher> Teachers => Collection<Teacher>();
        public IMongoCollection<Course> Courses => Collection<Course>();
        public IMongoCollection<Classroom> Classrooms => Collection<Classroom>();

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            //builder.Entity<YourEntity>(b =>
            //{
            //    //...
            //});
        }
    }
}
