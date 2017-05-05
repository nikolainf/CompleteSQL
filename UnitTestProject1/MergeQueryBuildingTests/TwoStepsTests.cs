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
        public void WhenMatchedThenDeleteWhenNotMatchedThenInsertTest()
        {
            var people = new[]
            {
                new
                {
                    Number = 50, 
                    Name = "Nikolai", 
                    Age =32,
                    GroupNumber =111, 
                    GroupName = "One One One",
                    Salary = 13d
                }
            };

            DataContext context = new DataContext("CompleteSQL");

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("Person")
               .On(p => p.Number)
               .WhenMatched()
               .ThenDelete()
               .WhenNotMatched()
               .ThenInsert();

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Matched
	Then Delete
When Not Matched
	Then Insert(Number, Name, Age, GroupNumber, GroupName, Salary)
		Values(src.Number, src.Name, src.Age, src.GroupNumber, src.GroupName, src.Salary);";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);

        }

        [Test]
        public void WhenMatchedThenDeleteWhenNotMatchedBySourceThenDeleteTest()
        {
            var people = new[]
            {
                new
                {
                    Number = 50, 
                    Name = "Nikolai", 
                    Age =32,
                    GroupNumber =111, 
                    GroupName = "One One One",
                    Salary = 13m
                }
            };

            DataContext context = new DataContext("CompleteSQL");

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("Person")
               .On(p => p.Number)
               .WhenMatched()
               .ThenDelete()
               .WhenNotMatchedBySource()
               .ThenDelete();

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Matched
	Then Delete
When Not Matched By Source
	Then Delete;";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);

        }

        [Test]
        public void WhenMatchedThenDeleteWhenNotMatchedBySourceThenUpdateTest()
        {
            var people = new[]
            {
                new
                {
                    Number = 50, 
                    Name = "Nikolai", 
                    Age =32,
                    GroupNumber =111, 
                    GroupName = "One One One",
                    Salary = 13m
                }
            };

            DataContext context = new DataContext("CompleteSQL");

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("Person")
               .On(p => p.Number)
               .WhenMatched()
               .ThenDelete()
               .WhenNotMatchedBySource()
               .ThenUpdate(p => new
               {
                   Age = p.Age+1,
                   Salary = p.Salary + 25m
               });

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Matched
	Then Delete
When Not Matched By Source
	Then Update Set 
		tgt.Age = tgt.Age + 1,
		tgt.Salary = tgt.Salary + 25;";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);

        }

        [Test]
        public void WhenMatchedAndThenUdpateWhenMatchedThenDeleteTest()
        {
             var people = new[]
            {
                new
                {
                    Number = 50, 
                    Name = "Nikolai", 
                    Age =32,
                    GroupNumber =111, 
                    GroupName = "One One One",
                    Salary = 13m
                }
            };

            DataContext context = new DataContext("CompleteSQL");

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("Person")
               .On(p => p.Number)
               .WhenMatchedAndTarget(p => p.Age > 18)
               .ThenUpdate((tgt, src) => new { Age = src.Age })
               .WhenMatched()
               .ThenDelete();

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Matched
	Then Update Set
        tgt.Age = src.Age
When Matched
    Then Delete;";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }
    }
}