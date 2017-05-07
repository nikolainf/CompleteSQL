using CompleteSQL;
using NUnit.Framework;

namespace UnitTestProject1.MergeQueryBuildingTests
{
    [TestFixture]
    class WhenNotMatchedBySourceThenUpdate
    {
        [Test]
        public void WhenNotMathcedThenUpdateTest()
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
                .WhenNotMatchedBySource()
                .ThenUpdate(p => new
                {
                    p.DocumentNumber,
                    Name = p.Name + "_NewValue",
                    SomeData = 123443,
                    SomeData2 = p.SomeData2 * 10,
                    SubtractData = p.SubtractData - 10,
                    DivideData = p.DivideData / 10
                });

            string expectedQuery =
@"Merge Into TestTable as tgt
Using #TestTable as src
	On tgt.Number = src.Number
When Not Matched By Source
	Then Update Set
		tgt.DocumentNumber = tgt.DocumentNumber,
		tgt.Name = tgt.Name + '_NewValue',
		tgt.SomeData = 123443,
		tgt.SomeData2 = tgt.SomeData2 * 10,
		tgt.SubtractData = tgt.SubtractData - 10,
		tgt.DivideData = tgt.DivideData / 10;";


            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }
    }
}
