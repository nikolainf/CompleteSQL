using CompleteSQL;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.MergeQueryBuildingTests.WhenNotMatched
{
    [TestFixture]
    public class WhenNotMatchedTwoStep
    {
        [Test]
        public void WhenNotMatchedThenInsertWhenMatchedThenDelete()
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
               .WhenNotMatched()
               .ThenInsert(p => new { p.Number, p.Name, p.Age })
               .WhenMatched()
               .ThenDelete();

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Not Matched
	Then Insert(Number, Name, Age)
		Values(src.Number, src.Name, src.Age)
When Matched
	Then Delete;";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void WhenNotMatchedThenInsertWhenMatchedThenUpdate()
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
               .WhenNotMatched()
               .ThenInsert(p => new { p.Number, p.Name, p.Age })
               .WhenMatched()
               .ThenUpdate((tgt, src)=> new { Salary = src.Salary + tgt.Salary});

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Not Matched
	Then Insert(Number, Name, Age)
		Values(src.Number, src.Name, src.Age)
When Matched
	Then Update Set
		tgt.Salary = src.Salary + tgt.Salary;";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void WhenNotMatchedAndThenInsertWhenMatchedThenDelete()
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
               .WhenNotMatchedAnd(tgt => tgt.Age > 100)
               .ThenInsert(p => new { p.Number, p.Name, p.Age })
               .WhenMatched()
               .ThenDelete();

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Not Matched And src.Age > 100
	Then Insert(Number, Name, Age)
		Values(src.Number, src.Name, src.Age)
When Matched
	Then Delete;";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void WhenNotMatchedAndThenInsertWhenMatchedThenUpdate()
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
               .WhenNotMatchedAnd(src => src.Name == "Alex")
               .ThenInsert(p => new { p.Number, p.Name, p.Age })
               .WhenMatched()
               .ThenUpdate((tgt, src) => new { Salary = src.Salary + tgt.Salary });

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Not Matched And src.Name = 'Alex'
	Then Insert(Number, Name, Age)
		Values(src.Number, src.Name, src.Age)
When Matched
	Then Update Set
		tgt.Salary = src.Salary + tgt.Salary;";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }


    }
}
