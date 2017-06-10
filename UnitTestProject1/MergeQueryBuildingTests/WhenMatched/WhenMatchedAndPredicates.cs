using CompleteSQL;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.MergeQueryBuildingTests.WhenMatched
{
    [TestFixture]
    public class WhenMatchedAndPredicates
    {

        DataContext context;

        [SetUp]
        public void Init()
        {
            context = new DataContext("CompleteSQL");
        }

        [Test]
        public void WhenMatchedAndTargetPredicateTest()
        {
            var people = new[]
            {
                new
                {
                    Id = 1,
                    Name = "John"
                }
            };

            

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("TestTable")
               .On(p => p.Id)
               .WhenMatchedAndTarget(tgt => tgt.Name.EndsWith("ay"))
               .ThenDelete();


            string query = mergeExpression.GetMergeQuery();

            string expectedQuery =
@"Merge Into TestTable as tgt
Using #TestTable as src
	On tgt.Id = src.Id
When Matched And tgt.Name Like '%ay'
	Then Delete;";

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void WhenMatchedAndSourcePredicateTest()
        {
            var people = new[]
            {
                new
                {
                    Id = 1,
                    Name = "John"
                }
            };

            

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("TestTable")
               .On(p => p.Id)
               .WhenMatchedAndSource(src => src.Name.StartsWith("N"))
               .ThenDelete();


            string query = mergeExpression.GetMergeQuery();

            string expectedQuery =
@"Merge Into TestTable as tgt
Using #TestTable as src
	On tgt.Id = src.Id
When Matched And src.Name Like 'N%'
	Then Delete;";

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void WhenMatchedAndTargetSourcePredicateTest()
        {
            var people = new[]
            {
                new
                {
                    Id = 1,
                    Name = "John"
                }
            };

            

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("TestTable")
               .On(p => p.Id)
               .WhenMatchedAnd(tgt => tgt.Name.StartsWith("N"), src => src.Id < 10005)
               .ThenDelete();


            string query = mergeExpression.GetMergeQuery();

            string expectedQuery =
@"Merge Into TestTable as tgt
Using #TestTable as src
	On tgt.Id = src.Id
When Matched And tgt.Name Like 'N%' And src.Id < 10005
	Then Delete;";

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void WhenMatchedAndTargetSourcePredicates2()
        {
            var people = new[]
            {
                new
                {
                    Id = 1,
                    Name = "John"
                }
            };

            

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("TestTable")
               .On(p => p.Id)
               .WhenMatchedAnd(tgt => tgt.Name.StartsWith("N"), src => src.Id < 10005)
               .ThenDelete()
               .WhenMatchedAnd(tgt => tgt.Name.StartsWith("T"), src => src.Id == 12)
               .ThenUpdate((tgt, src) => new { Name = "UpdateName" });


            string query = mergeExpression.GetMergeQuery();

            string expectedQuery =
@"Merge Into TestTable as tgt
Using #TestTable as src
	On tgt.Id = src.Id
When Matched And tgt.Name Like 'N%' And src.Id < 10005
	Then Delete
When Matched And tgt.Name Like 'T%' And src.Id = 12
	Then Update Set
		tgt.Name = 'UpdateName';";

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void WhenMatchedAndTargetSourcePredicate3()
        {
            var people = new[]
            {
                new
                {
                    Id = 1,
                    Name = "John"
                }
            };

            

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("TestTable")
               .On(p => p.Id)
               .WhenMatchedAnd(tgt => tgt.Name.StartsWith("T"), src => src.Id == 12)
               .ThenUpdate((tgt, src) => new { Name = "UpdateName" })
               .WhenMatchedAnd(tgt => tgt.Name.StartsWith("N"), src => src.Id < 10005)
               .ThenDelete();


            string query = mergeExpression.GetMergeQuery();

            string expectedQuery =
@"Merge Into TestTable as tgt
Using #TestTable as src
	On tgt.Id = src.Id
When Matched And tgt.Name Like 'T%' And src.Id = 12
	Then Update Set
		tgt.Name = 'UpdateName'
When Matched And tgt.Name Like 'N%' And src.Id < 10005
	Then Delete;";

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void WhenMatchedMultipleAndTargetPredicateTest()
        {
            var people = new[]
            {
                new
                {
                    Id = 1,
                    Name = "John"
                }
            };

            

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("TestTable")
               .On(p => p.Id)
               .WhenMatchedAndTarget(tgt => tgt.Name.EndsWith("ay") && tgt.Id < 100)
               .ThenDelete();


            string query = mergeExpression.GetMergeQuery();

            string expectedQuery =
@"Merge Into TestTable as tgt
Using #TestTable as src
	On tgt.Id = src.Id
When Matched And tgt.Name Like '%ay' And tgt.Id < 100
	Then Delete;";

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void WhenMatchedMultipleAndSourcePredicateTest()
        {
            var people = new[]
            {
                new
                {
                    Id = 1,
                    Name = "John"
                }
            };

            

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("TestTable")
               .On(p => p.Id)
               .WhenMatchedAndSource(src => src.Name.StartsWith("N") && src.Id > 1000)
               .ThenDelete();


            string query = mergeExpression.GetMergeQuery();

            string expectedQuery =
@"Merge Into TestTable as tgt
Using #TestTable as src
	On tgt.Id = src.Id
When Matched And src.Name Like 'N%' And src.Id > 1000
	Then Delete;";

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void WhenMatchedMultipleAndTargetSourcePredicateTest()
        {
            var people = new[]
            {
                new
                {
                    Id = 1,
                    Name = "John"
                }
            };

            

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("TestTable")
               .On(p => p.Id)
               .WhenMatchedAnd(tgt => tgt.Name.StartsWith("N") && tgt.Id > 1000, src => src.Id < 10005 && src.Name.StartsWith("N"))
               .ThenDelete();


            string query = mergeExpression.GetMergeQuery();

            string expectedQuery =
@"Merge Into TestTable as tgt
Using #TestTable as src
	On tgt.Id = src.Id
When Matched And tgt.Name Like 'N%' And tgt.Id > 1000 And src.Id < 10005 And src.Name Like 'N%'
	Then Delete;";

            Assert.AreEqual(expectedQuery, query);
        }

       
    }
}
