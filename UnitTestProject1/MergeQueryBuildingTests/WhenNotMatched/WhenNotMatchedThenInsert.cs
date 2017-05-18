using CompleteSQL;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.MergeQueryBuildingTests
{
    [TestFixture]
    public class WhenNotMatchedThenInsert
    {
        [Test]
        public void SingleMergePredicateInsertAllTest()
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
            .On(p => p.DocumentNumber)
            .WhenNotMatched()
            .ThenInsert();

            string expectedQuery =
@"Merge Into TestTable as tgt
Using #TestTable as src
	On tgt.DocumentNumber = src.DocumentNumber
When Not Matched
	Then Insert(Number, DocumentNumber, Name)
		Values(src.Number, src.DocumentNumber, src.Name);";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void MultipleMergePredicateInsertAllTest()
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
            .WhenNotMatched()
            .ThenInsert();

            string expectedQuery =
@"Merge Into TestTable as tgt
Using #TestTable as src
	On tgt.Number = src.Number
	And tgt.DocumentNumber = src.DocumentNumber
When Not Matched
	Then Insert(Number, DocumentNumber, Name)
		Values(src.Number, src.DocumentNumber, src.Name);";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void SingleMergePredicateInsertDefinedColumnsTest()
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
                .On(p => p.Number)
                .WhenNotMatched()
                .ThenInsert(p => new { p.Number, p.DocumentNumber });

            string expectedQuery =
@"Merge Into TestTable as tgt
Using #TestTable as src
	On tgt.Number = src.Number
When Not Matched
	Then Insert(Number, DocumentNumber)
		Values(src.Number, src.DocumentNumber);";


            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void SingleMergePredicateInsertDefinedColumnsAndConstantsTest()
        {
            var people = new[]
            {
                new
                {
                    Number = 1,
                    Name = "John",
                    Age = 33,
                }
            };

            DataContext context = new DataContext("CompleteSQL");

            var mergeExpression = context.CreateMergeUsing(people)
                .Target("Person")
                .On(p => p.Number)
                .WhenNotMatched()
                .ThenInsert(p => new { p.Number, p.Name, p.Age, GroupNumber = 77, GroupName = "SeventySeventGroup", Salary = 100.5123m });

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Not Matched
	Then Insert(Number, Name, Age, GroupNumber, GroupName, Salary)
		Values(src.Number, src.Name, src.Age, 77, 'SeventySeventGroup', 100.5123);";


            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void SingleMergePredicateInsertAllCombinationsTest()
        {
            var people = new[]
            {
                new
                {
                    Number = 1,
                    Name = "John",
                    Age = 33
                }
            };

            DataContext context = new DataContext("CompleteSQL");

            var mergeExpression = context.CreateMergeUsing(people)
                .Target("Person")
                .On(p => p.Number)
                .WhenNotMatchedAnd(p => p.Name.Contains("abc"))
                .ThenInsert(p => new { Name = p.Name + "_new", p.Number, Age = p.Age + 1, Actual = 1 });

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Not Matched And src.Name Like '%abc%'
	Then Insert(Name, Number, Age, Actual)
		Values(src.Name + '_new', src.Number, src.Age + 1, 1);";


            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }
      
    }
}
