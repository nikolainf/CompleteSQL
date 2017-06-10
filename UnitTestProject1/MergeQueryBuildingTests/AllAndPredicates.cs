using CompleteSQL;
using NUnit.Framework;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace UnitTestProject1.MergeQueryBuildingTests
{
    [TestFixture]
    public class AndPredicatesTests
    {

        DataContext context;

        [SetUp]
        public void Init()
        {
            context = new DataContext("CompleteSQL");
        }

        static object[] AndParams =
    {
            new Tuple<string, Expression<Func<Person,bool>>>(">=", p=>p.Age>=17) ,
            new Tuple<string, Expression<Func<Person,bool>>>("<=", p=>p.Age<=17),
            new Tuple<string, Expression<Func<Person,bool>>>("=", p=>p.Age==17),
            new Tuple<string, Expression<Func<Person,bool>>>(">", p=>p.Age>17),
            new Tuple<string, Expression<Func<Person,bool>>>("<", p=>p.Age<17),
            new Tuple<string, Expression<Func<Person,bool>>>("<>", p=>p.Age!=17)
    };

        [Test, TestCaseSource("AndParams")]
        public void ComparerPredicateTest(Tuple<string, Expression<Func<Person, bool>>> tuple)
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
        public void StartsWithPredicateTest()
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
        public void EndsWithPredicateTest()
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

            

            var mergeExpression = context.CreateMergeUsing(people)
                .Target("Person")
                .On(p => p.Number)
                .WhenNotMatchedAnd(p => p.Name.EndsWith("ing"))
                .ThenInsert();

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Not Matched And src.Name Like '%ing'
	Then Insert(Number, Name, Age)
		Values(src.Number, src.Name, src.Age);";


            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void ContainsPredicateTest()
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

            

            var mergeExpression = context.CreateMergeUsing(people)
                .Target("Person")
                .On(p => p.Number)
                .WhenNotMatchedAnd(p => p.Name.Contains("abc"))
                .ThenInsert();

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Not Matched And src.Name Like '%abc%'
	Then Insert(Number, Name, Age)
		Values(src.Number, src.Name, src.Age);";


            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void StringEqualsPredicateTest()
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

            

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("Person")
               .On(p => p.Number)
               .WhenNotMatchedAnd(src => src.Name == "Alex")
               .ThenInsert(p => new { p.Number, p.Name, p.Age });

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Not Matched And src.Name = 'Alex'
	Then Insert(Number, Name, Age)
		Values(src.Number, src.Name, src.Age);";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }


        [Test]
        public void DoubleEqualsPredicateTest()
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

            

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("Person")
               .On(p => p.Number)
               .WhenNotMatchedAnd(src => src.Salary == 100d)
               .ThenInsert(p => new { p.Number, p.Name, p.Age });

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Not Matched And src.Salary = 100
	Then Insert(Number, Name, Age)
		Values(src.Number, src.Name, src.Age);";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void DecimalEqualsPredicateTest()
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
                    Salary = 13m
                }
            };

            

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("Person")
               .On(p => p.Number)
               .WhenNotMatchedAnd(src => src.Salary == 100m)
               .ThenInsert(p => new { p.Number, p.Name, p.Age });

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Not Matched And src.Salary = 100
	Then Insert(Number, Name, Age)
		Values(src.Number, src.Name, src.Age);";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }


        [Test]
        public void InPredicateStringArrayTest()
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

            

            string[] names = new[] { "John", "Peter", "Mike", "Nikolai" };

            var mergeExpression = context.CreateMergeUsing(people)
                .Target("Person")
                .On(p => p.Number)
                .WhenNotMatchedAnd(p => names.Contains(p.Name))
                .ThenInsert();

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Not Matched And src.Name In('John', 'Peter', 'Mike', 'Nikolai')
	Then Insert(Number, Name, Age)
		Values(src.Number, src.Name, src.Age);";


            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void InPredicateStringListTest()
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

            

            List<string> names = new List<string>{ "John", "Peter", "Mike", "Nikolai" };

            var mergeExpression = context.CreateMergeUsing(people)
                .Target("Person")
                .On(p => p.Number)
                .WhenNotMatchedAnd(p => names.Contains(p.Name))
                .ThenInsert();

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Not Matched And src.Name In('John', 'Peter', 'Mike', 'Nikolai')
	Then Insert(Number, Name, Age)
		Values(src.Number, src.Name, src.Age);";


            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void InPredicateIntArrayTest()
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

            

            int[] numbers = new[] { 132, 789, 9, 5 };

            var mergeExpression = context.CreateMergeUsing(people)
                .Target("Person")
                .On(p => p.Number)
                .WhenNotMatchedAnd(p => numbers.Contains(p.Number))
                .ThenInsert();

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Not Matched And src.Number In(132, 789, 9, 5)
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
