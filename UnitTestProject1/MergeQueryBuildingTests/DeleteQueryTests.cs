using CompleteSQL;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class DeleteQueryTests
    {
    
        [Test]
        public void OnWhenMathcedThenDeleteTest()
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
        public void OnWhenMathcedThenDeleteWithTwoPredicatesTest()
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

            DataContext context = new DataContext("CompleteSQL");

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

        [Test]
        public void WhenNotMatchedBySourceThenDeleteTest()
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
        public void WhenNotMatchedBySourceAndThenDeleteTest()
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


    }
}
