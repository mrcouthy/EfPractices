using Microsoft.VisualStudio.TestTools.UnitTesting;
using EfPractices.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfPractices;

namespace SurveyRepositoryTest
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class Synchronize
    {


        [TestMethod]
        public void TestSyncInserts()
        {

            using (var dbOffLinecontext = new AdbContext(DatabaseType.Sqlite))
            {
                var maxcreatedon = dbOffLinecontext.Surveys.Max(s => s.CreatedOn);
                maxcreatedon = maxcreatedon ?? DateTime.Now.AddYears(-20);
                List<Surveys> newSurveys;
                using (var dbOnLinecontext = new AdbContext())
                {
                    var surveys = from s in dbOnLinecontext.Surveys
                                  where s.CreatedOn != null && s.CreatedOn > maxcreatedon
                                  select s;
                    var a = surveys.ToList();
                    newSurveys = a;
                }
                if (newSurveys.Count > 0)
                {
                    dbOffLinecontext.Surveys.AddRange(newSurveys);
                    dbOffLinecontext.SaveChanges();
                }
            }
        }

        [TestMethod]
        public void TestSyncUpdates()
        {

            using (var dbOffLinecontext = new AdbContext(DatabaseType.Sqlite))
            {
                var maxModifiedDate = dbOffLinecontext.Surveys.Max(s => s.ModifiedOn);

                List<Surveys> updatedData;
                using (var dbOnLinecontext = new AdbContext())
                {
                    var surveys = from s in dbOnLinecontext.Surveys
                                  where s.ModifiedOn != null && s.ModifiedOn > maxModifiedDate
                                  select s;
                    updatedData = surveys.ToList();
                }
                foreach (var item in updatedData)
                {
                    dbOffLinecontext.Surveys.Attach(item);
                    dbOffLinecontext.Entry(item).State = EntityState.Modified;
                }

                var i = dbOffLinecontext.SaveChanges();

            }
        }



    }
}
