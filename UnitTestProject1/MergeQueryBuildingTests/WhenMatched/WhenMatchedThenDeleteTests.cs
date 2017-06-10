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
    public class WhenMatchedThenDeleteTests
    {

        DataContext context;

        [SetUp]
        public void Init()
        {
            context = new DataContext("CompleteSQL");
        }

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

            

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("TestTable")
               .On(p => p.Id)
               .WhenMatched()
               .ThenDelete();



            string query = mergeExpression.GetMergeQuery();

            string expectedQuery =
@"Merge Into TestTable as tgt
Using #TestTable as src
	On tgt.Id = src.Id
When Matched
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
                    Number = 1,
                    DocumentNumber = 2,
                    Name = "John"
                }
            };

            

            var mergeExpression = context.CreateMergeUsing(people)
            .Target("TestTable")
            .On(p => new { p.Number, p.DocumentNumber })
            .WhenMatched()
            .ThenDelete();


            string query = mergeExpression.GetMergeQuery();


            string expectedQuery =
@"Merge Into TestTable as tgt
Using #TestTable as src
	On tgt.Number = src.Number
	And tgt.DocumentNumber = src.DocumentNumber
When Matched
	Then Delete;";

            Assert.AreEqual(expectedQuery, query);

        }

    }
}
