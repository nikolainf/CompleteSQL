using CompleteSQL;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.MergeQueryBuildingTests
{
    [TestFixture]
    public class TwoStepsTests
    {
        [Test]
        public void WhenNotMatchedThenDelete_WhenMatchedThenUpdate()
        {
            var people = new[]
            {
                new
                {
                    Id = 1,
                    Name = "John"
                }
            };

            DataContext context = new DataContext("CompleteSQL");

            //var mergeExpression = context.CreateMergeUsing(people)
            //   .Target("TestTable")
            //   .On(p => p.Id)
            //   .WhenNotMatchedBySource()
            //   .ThenDelete()
            //   .WhenMatched()
            //   .ThenUpdate(p => p.Name);
        }
    }
}
