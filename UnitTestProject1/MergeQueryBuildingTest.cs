using CompleteSQL;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestFixture]
    public class MergeQueryBuildingTest
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

        [Test]
        public void WhenMathcedThenUpdateDeterminateColumnsTest()
        {
            var people = new[]
            {
                new
                {
                    Number = 1,
                    DocumentNumber = 2,
                    Name = "John",
                    SomeData = 123,
                    SomeData2 = 11,
                    SubtractData = 1,
                    DivideData = 0
                }
            };

            DataContext context = new DataContext("CompleteSQL");

            var mergeExpression = context.CreateMergeUsing(people)
                .Target("TestTable")
                .On(p => p.Number)
                .WhenMatched()
                .ThenUpdate((t,s) => new { s.DocumentNumber, Name = s.Name + "_NewValue", SomeData = 123443, SomeData2 = s.SomeData2 * 10, SubtractData = s.SubtractData - 10, DivideData = s.DivideData / 10 });

            string expectedQuery =
@"Merge Into TestTable as tgt
Using #TestTable as src
	On tgt.Number = src.Number
When Matched
	Then Update Set 
		tgt.DocumentNumber = src.DocumentNumber,
		tgt.Name = src.Name + '_NewValue',
		tgt.SomeData = 123443,
		tgt.SomeData2 = src.SomeData2 * 10,
		tgt.SubtractData = src.SubtractData - 10,
		tgt.DivideData = src.DivideData / 10;";


            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void WhenMathcedThenUpdateWithTgtAndSrcColumnsTest()
        {
            var people = new[]
            {
                new
                {
                    Number = 1,
                    DocumentNumber = 2,
                    Name = "John",
                    SomeData = 123,
                    SomeData2 = 11,
                    SubtractData = 1,
                    DivideData = 0
                }
            };

            DataContext context = new DataContext("CompleteSQL");

            var mergeExpression = context.CreateMergeUsing(people)
                .Target("TestTable")
                .On(p => p.Number)
                .WhenMatched()
                .ThenUpdate((t, s) => new { SomeData = t.SomeData + s.SomeData, s.SomeData2 });

            string expectedQuery =
@"Merge Into TestTable as tgt
Using #TestTable as src
	On tgt.Number = src.Number
When Matched
	Then Update Set 
		tgt.SomeData = tgt.SomeData + src.SomeData,
		tgt.SomeData2 = src.SomeData2;";


            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

      


    }
}
