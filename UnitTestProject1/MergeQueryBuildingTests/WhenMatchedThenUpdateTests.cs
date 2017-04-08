using CompleteSQL;
using NUnit.Framework;

namespace UnitTestProject1.MergeQueryBuildingTests
{
    public class WhenMatchedThenUpdateTests
    {
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
                .ThenUpdate((t, s) => new { s.DocumentNumber, Name = s.Name + "_NewValue", SomeData = 123443, SomeData2 = s.SomeData2 * 10, SubtractData = s.SubtractData - 10, DivideData = s.DivideData / 10 });

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
        public void ThenUpdateWithTgtAndSrcColumnsTest()
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


        [Test]
        public void SingleColumnMergePredicateAllColumnsTest()
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
                .ThenUpdate();

            string expectedQuery =
@"Merge Into TestTable as tgt
Using #TestTable as src
	On tgt.Number = src.Number
When Matched
	Then Update Set 
		tgt.DocumentNumber = src.DocumentNumber,
		tgt.Name = src.Name,
		tgt.SomeData = src.SomeData,
		tgt.SomeData2 = src.SomeData2,
		tgt.SubtractData = src.SubtractData,
		tgt.DivideData = src.DivideData;";


            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void MultiColumnsMergePredicateAllColumnsTest()
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
                .On(p => new { p.Number, p.DocumentNumber })
                .WhenMatched()
                .ThenUpdate();

            string expectedQuery =
@"Merge Into TestTable as tgt
Using #TestTable as src
	On tgt.Number = src.Number
	And tgt.DocumentNumber = src.DocumentNumber
When Matched
	Then Update Set 
		tgt.Name = src.Name,
		tgt.SomeData = src.SomeData,
		tgt.SomeData2 = src.SomeData2,
		tgt.SubtractData = src.SubtractData,
		tgt.DivideData = src.DivideData;";


            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }
    }
}
