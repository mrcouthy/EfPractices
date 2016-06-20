using EfPractices.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EfPractices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyRepositoryTest
{
    [TestClass]
    public class CrudeTest
    {
        [TestMethod]
        public void Genericcrudetest()
        {
            using (var dbcontext = new AdbContext())
            {
                var gr = new GenericRepository<Rule>(dbcontext);

                var m = new Rule();
                m.RuleId = 10;
                m.Description = "test";
                m.Name = "what";
                gr.Insert(m);

                gr.Save();

                var d = gr.Get(s => s.Name == "what");
                foreach (var item in d)
                {
                    gr.Delete(item);
                }

                gr.Save();
                Assert.AreEqual(1, 1);
            }
        }

        [TestMethod]
        public void GenericSelectTest()
        {
            using (var dbcontext = new AdbContext())
            {
                var gr = new GenericRepository<Rule>(dbcontext);
                Rule r = new Rule { RuleId = 1, Name = "New", Description = "inserted" };

                gr.Insert(r);
                gr.Save();
                var updater = new Rule { RuleId = 9, Name = "updated", Description = "Updated" };
                gr.Update(updater);
                gr.Save();

                var f = gr.Get(a => a.Name == "New", d => d.OrderBy(s => s.Name), "");
                Assert.AreEqual(1, 1);
            }
        }


        [TestMethod]
        public void GenericMaxTest()
        {
            using (var dbOffcontext = new AdbContext(DatabaseType.Sqlite))
            using (var dbcontext = new AdbContext())
            {
                var gr = new GenericUpdater<Surveys, DateTime?>(dbcontext, dbOffcontext);
                var b = gr.GetMax(a => a.ModifiedOn);
                Assert.AreEqual(1, 1);
            }
        }

        [TestMethod]
        public void InsertTest()
        {
            using (var dbOffcontext = new AdbContext(DatabaseType.Sqlite))
            using (var dbcontext = new AdbContext())
            {
                var gr = new GenericUpdater<Surveys, DateTime?>(sourceContext: dbcontext, destinationContext: dbOffcontext);
                var max = gr.GetMax(a => a.CreatedOn);
                var c = gr.GetToUpdateData(a => a.CreatedOn, b => b.CreatedOn != null && b.CreatedOn > max, true);
                Assert.AreEqual(c, 1);
            }
        }

        [TestMethod]
        public void UpdateTest()
        {
            using (var dbOffcontext = new AdbContext(DatabaseType.Sqlite))
            using (var dbcontext = new AdbContext())
            {
                var gr = new GenericUpdater<Surveys, DateTime?>(sourceContext: dbcontext, destinationContext: dbOffcontext);
                var max = gr.GetMax(a => a.ModifiedOn);
                var c = gr.GetToUpdateData(a => a.ModifiedOn, b => b.ModifiedOn != null && b.ModifiedOn > max, false);
            }
        }

        [TestMethod]
        public void GenerateS()
        {
            var gr = new OfflineUpdater<Surveys>();
            gr.UpdateToOffline();
        }
    }
}
