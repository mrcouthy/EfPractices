using EfPractices;
using EfPractices.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class MulitpleUpdates
    {
        [TestMethod]
        public void Test()
        {
            using (var dbcontext = new AdbContext())
            {
                var gr = new GenericRepository<Rule>(dbcontext);
                var m = new Rule();
                m.RuleId = 1;
                m.Description = "a";
                m.Name = "a";

                var n = new Rule();
                n.RuleId = 1;
                n.Description = "b";
                n.Name = "b";

                gr.InsertOrUpdate(n, a => a.RuleId == n.RuleId);
                gr.InsertOrUpdate(m, a => a.RuleId == m.RuleId);

                gr.Save();
            }
        }
    }
}
