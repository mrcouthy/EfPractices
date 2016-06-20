using System.Data.Entity;

using EfPractices.Model;

namespace EfPractices
{
    public enum DatabaseType
    {
        Sqlsever,
        Sqlite
    }
    public partial class AdbContext : DbContext
    {

        static AdbContext()
        {
            Database.SetInitializer<AdbContext>(null);
        }

        public AdbContext()
            : base("Name=SurveydbContext")
        {
        }

        public AdbContext(DatabaseType dbType)
            : base(dbType == DatabaseType.Sqlsever ? "Name=SurveydbContext" : "Name=SurveyOfflinedbContext")
        {

        }

       
        public DbSet<Rule> Rules { get; set; }
        public DbSet<Surveys> Surveys { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            modelBuilder.Configurations.Add(new RuleMap());
            modelBuilder.Configurations.Add(new AModelMap());
           
        }
    }
}
