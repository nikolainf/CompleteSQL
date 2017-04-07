using CompleteSQL;
using NUnit.Framework;
using System;
using System.Linq.Expressions;

namespace UnitTestProject1.MergeQueryBuildingTests
{
    [TestFixture]
    public class AndConditionsTests
    {
        static object[] AndParams =
    {
            new Tuple<string, Expression<Func<Person,bool>>>(">=", p=>p.Age>=17) ,
            new Tuple<string, Expression<Func<Person,bool>>>("<=", p=>p.Age<=17),
            new Tuple<string, Expression<Func<Person,bool>>>("=", p=>p.Age==17),
            new Tuple<string, Expression<Func<Person,bool>>>(">", p=>p.Age>17),
            new Tuple<string, Expression<Func<Person,bool>>>("<", p=>p.Age<17)
    };

        [Test, TestCaseSource("AndParams")]
        public void WhenNotMathcedAndThenInsertTest(Tuple<string, Expression<Func<Person, bool>>> tuple)
        {
            var people = new Person[]
            {
                new Person
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
                .WhenNotMatchedAnd(tuple.Item2)
                .ThenInsert();

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Not Matched And src.Age " + tuple.Item1 + " 17" + Environment.NewLine + "\t" +
@"Then Insert(Number, Name, Age)
		Values(src.Number, src.Name, src.Age);";


            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void AndSingleStartWithPredicateThenInsertTest()
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
                .WhenNotMatchedAnd(p => p.Name.StartsWith("J"))
                .ThenInsert();

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Not Matched And src.Name Like 'J%'
	Then Insert(Number, Name, Age)
		Values(src.Number, src.Name, src.Age);";


            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void AndMirrorCondition()
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
                .WhenNotMatchedAnd(p => 100 < p.Number && p.Name.Contains("ABc"))
                .ThenInsert();

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Not Matched And 100 < src.Number And src.Name Like '%ABc%'
	Then Insert(Number, Name, Age)
		Values(src.Number, src.Name, src.Age);";


            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }
    }
}
