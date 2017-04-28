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
    public class WhenNotMatchedBySourceThenDeleteTests
    {
        [Test]
        public void SingleMergePredicateTest()
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

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("TestTable")
               .On(p => p.Id)
               .WhenNotMatchedBySource()
               .ThenDelete();

            string query = mergeExpression.GetMergeQuery();

            string expectedQuery =
@"Merge Into TestTable as tgt
Using #TestTable as src
	On tgt.Id = src.Id
When Not Matched By Source
	Then Delete;";

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void SingleMergePredicateSingleAndPredicateTest()
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

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("TestTable")
               .On(p => p.Id)
               .WhenNotMatcheBySourceAnd(p => p.Name.StartsWith("Jo"))
               .ThenDelete();




            string query = mergeExpression.GetMergeQuery();

            string expectedQuery =
@"Merge Into TestTable as tgt
Using #TestTable as src
	On tgt.Id = src.Id
When Not Matched By Source And tgt.Name Like 'Jo%'
	Then Delete;";

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void SingleMergePredicateMultipeAndPredicate()
        {
            var people = new[]
            {
                new
                {
                    Id = 1,
                    Name = "John",
                    Number = 100
                }
            };

            DataContext context = new DataContext("CompleteSQL");

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("TestTable")
               .On(p => p.Id)
               .WhenNotMatcheBySourceAnd(p => p.Name.StartsWith("Jo") && p.Number < 200)
               .ThenDelete();




            string query = mergeExpression.GetMergeQuery();

            string expectedQuery =
@"Merge Into TestTable as tgt
Using #TestTable as src
	On tgt.Id = src.Id
When Not Matched By Source And tgt.Name Like 'Jo%' And tgt.Number < 200
	Then Delete;";

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void MultipleMergePredicateTest()
        {
            var people = new[]
            {
                new
                {
                    Id = 1,
                    Number = 100,
                    Name = "John"
                }
            };

            DataContext context = new DataContext("CompleteSQL");

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("TestTable")
               .On(p => new { p.Id, p.Number })
               .WhenNotMatchedBySource()
               .ThenDelete();

            string query = mergeExpression.GetMergeQuery();

            string expectedQuery =
@"Merge Into TestTable as tgt
Using #TestTable as src
	On tgt.Id = src.Id
	And tgt.Number = src.Number
When Not Matched By Source
	Then Delete;";

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void MultipleMergePredicateSingleAndPredicate()
        {
            var people = new[]
            {
                new
                {
                    Id = 1,
                    Name = "John",
                    Number = 100
                }
            };

            DataContext context = new DataContext("CompleteSQL");

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("TestTable")
               .On(p => new { p.Id, p.Number })
               .WhenNotMatcheBySourceAnd(p => p.Name.StartsWith("Jo"))
               .ThenDelete();




            string query = mergeExpression.GetMergeQuery();

            string expectedQuery =
@"Merge Into TestTable as tgt
Using #TestTable as src
	On tgt.Id = src.Id
	And tgt.Number = src.Number
When Not Matched By Source And tgt.Name Like 'Jo%'
	Then Delete;";

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void MultipleMergePredicateMultipeAndPredicate()
        {
            var people = new[]
            {
                new
                {
                    Id = 1,
                    Name = "John",
                    Number = 100
                }
            };

            DataContext context = new DataContext("CompleteSQL");

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("TestTable")
               .On(p => new { p.Id, p.Number })
               .WhenNotMatcheBySourceAnd(p => p.Name.StartsWith("Jo") && p.Number < 200)
               .ThenDelete();




            string query = mergeExpression.GetMergeQuery();

            string expectedQuery =
@"Merge Into TestTable as tgt
Using #TestTable as src
	On tgt.Id = src.Id
	And tgt.Number = src.Number
When Not Matched By Source And tgt.Name Like 'Jo%' And tgt.Number < 200
	Then Delete;";

            Assert.AreEqual(expectedQuery, query);
        }
    }
}
