using CompleteSQL;
using NUnit.Framework;

namespace UnitTestProject1.MergeQueryBuildingTests.WhenNotMatchedBySource
{
    [TestFixture]
    class WhenNotMatchedBySourceTwoStep
    {
        private DataContext context;
        [SetUp]
        public void Init()
        {
            context = new DataContext("CompleteSQL");
        }

        [Test]
        public void WhenNotMatchedThenInsertWhenMatchedThenDelete()
        {
            var people = new[]
            {
                new
                {
                    Number = 50, 
                    Name = "Nikolai", 
                    Age = 32,
                    GroupNumber =111, 
                    GroupName = "One One One",
                    Salary = 13d
                }
            };



            var mergeExpression = context.CreateMergeUsing(people)
               .Target("Person")
               .On(p => p.Number)
               .WhenNotMatchedBySource()
               .ThenInsert(p => new { p.Number, p.Name, p.Age })
               .WhenMatched()
               .ThenDelete();

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Not Matched
	Then Insert(Number, Name, Age)
		Values(src.Number, src.Name, src.Age)
When Matched
	Then Delete;";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void WhenNotMatchedThenInsertWhenMatchedThenUpdate()
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
               .WhenNotMatchedBySource()
               .ThenInsert(p => new { p.Number, p.Name, p.Age })
               .WhenMatched()
               .ThenUpdate((tgt, src) => new { Salary = src.Salary + tgt.Salary });

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Not Matched
	Then Insert(Number, Name, Age)
		Values(src.Number, src.Name, src.Age)
When Matched
	Then Update Set
		tgt.Salary = src.Salary + tgt.Salary;";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void WhenNotMatchedAndThenInsertWhenMatchedThenDelete()
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
               .WhenNotMatchedBySourceAnd(tgt => tgt.Age > 100)
               .ThenInsert(p => new { p.Number, p.Name, p.Age })
               .WhenMatched()
               .ThenDelete();

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Not Matched And src.Age > 100
	Then Insert(Number, Name, Age)
		Values(src.Number, src.Name, src.Age)
When Matched
	Then Delete;";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void WhenNotMatchedAndThenInsertWhenMatchedThenUpdate()
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
               .WhenNotMatchedBySourceAnd(src => src.Name == "Alex")
               .ThenInsert(p => new { p.Number, p.Name, p.Age })
               .WhenMatched()
               .ThenUpdate((tgt, src) => new { Salary = src.Salary + tgt.Salary });

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Not Matched And src.Name = 'Alex'
	Then Insert(Number, Name, Age)
		Values(src.Number, src.Name, src.Age)
When Matched
	Then Update Set
		tgt.Salary = src.Salary + tgt.Salary;";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void WhenNotMathcedThenInsertWhenMatchedAndThenDelete()
        {
            var people = new[]
            {
                new
                {
                    Number = 50, 
                    Name = "Nikolai", 
                    Age = 32,
                    GroupNumber =111, 
                    GroupName = "One One One",
                    Salary = 13d
                }
            };



            var mergeExpression = context.CreateMergeUsing(people)
               .Target("Person")
               .On(p => p.Number)
               .WhenNotMatchedBySource()
               .ThenInsert(p => new { p.Number, p.Name, p.Age })
               .WhenMatchedAnd(tgt => tgt.Name.StartsWith("N"), src => src.Number < 10005)
               .ThenDelete();

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Not Matched
	Then Insert(Number, Name, Age)
		Values(src.Number, src.Name, src.Age)
When Matched And tgt.Name Like 'N%' And src.Number < 10005
	Then Delete;";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void WhenNotMathcedThenInsertWhenMatchedAndTargetThenDelete()
        {
            var people = new[]
            {
                new
                {
                    Number = 50, 
                    Name = "Nikolai", 
                    Age = 32,
                    GroupNumber =111, 
                    GroupName = "One One One",
                    Salary = 13d
                }
            };



            var mergeExpression = context.CreateMergeUsing(people)
               .Target("Person")
               .On(p => p.Number)
               .WhenNotMatchedBySource()
               .ThenInsert(p => new { p.Number, p.Name, p.Age })
               .WhenMatchedAndTarget(tgt => tgt.Name.StartsWith("N"))
               .ThenDelete();

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Not Matched
	Then Insert(Number, Name, Age)
		Values(src.Number, src.Name, src.Age)
When Matched And tgt.Name Like 'N%'
	Then Delete;";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void WhenNotMathcedThenInsertWhenMatchedAndSourceThenDelete()
        {
            var people = new[]
            {
                new
                {
                    Number = 50, 
                    Name = "Nikolai", 
                    Age = 32,
                    GroupNumber =111, 
                    GroupName = "One One One",
                    Salary = 13d
                }
            };



            var mergeExpression = context.CreateMergeUsing(people)
               .Target("Person")
               .On(p => p.Number)
               .WhenNotMatchedBySource()
               .ThenInsert(p => new { p.Number, p.Name, p.Age })
               .WhenMatchedAndSource(src => src.Name.StartsWith("N"))
               .ThenDelete();

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Not Matched
	Then Insert(Number, Name, Age)
		Values(src.Number, src.Name, src.Age)
When Matched And src.Name Like 'N%'
	Then Delete;";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void WhenNotMathcedThenInsertWhenMatchedAndThenUpdate()
        {
            var people = new[]
            {
                new
                {
                    Number = 50, 
                    Name = "Nikolai", 
                    Age = 32,
                    GroupNumber =111, 
                    GroupName = "One One One",
                    Salary = 13d
                }
            };



            var mergeExpression = context.CreateMergeUsing(people)
               .Target("Person")
               .On(p => p.Number)
               .WhenNotMatchedBySource()
               .ThenInsert(p => new { p.Number, p.Name, p.Age })
               .WhenMatchedAnd(tgt => tgt.Name.StartsWith("N"), src => src.Number < 10005)
               .ThenUpdate((tgt, src) => new { Salary = src.Salary + tgt.Salary });

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Not Matched
	Then Insert(Number, Name, Age)
		Values(src.Number, src.Name, src.Age)
When Matched And tgt.Name Like 'N%' And src.Number < 10005
	Then Update Set
		tgt.Salary = src.Salary + tgt.Salary;";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void WhenNotMathcedThenInsertWhenMatchedAndTargetThenUpdate()
        {
            var people = new[]
            {
                new
                {
                    Number = 50, 
                    Name = "Nikolai", 
                    Age = 32,
                    GroupNumber =111, 
                    GroupName = "One One One",
                    Salary = 13d
                }
            };



            var mergeExpression = context.CreateMergeUsing(people)
               .Target("Person")
               .On(p => p.Number)
               .WhenNotMatchedBySource()
               .ThenInsert(p => new { p.Number, p.Name, p.Age })
               .WhenMatchedAndTarget(tgt => tgt.Name.StartsWith("N"))
               .ThenUpdate((tgt, src) => new { Salary = src.Salary + tgt.Salary });

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Not Matched
	Then Insert(Number, Name, Age)
		Values(src.Number, src.Name, src.Age)
When Matched And tgt.Name Like 'N%'
	Then Update Set
		tgt.Salary = src.Salary + tgt.Salary;";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        [Test]
        public void WhenNotMathcedThenInsertWhenMatchedAndSourceThenUpdate()
        {
            var people = new[]
            {
                new
                {
                    Number = 50, 
                    Name = "Nikolai", 
                    Age = 32,
                    GroupNumber =111, 
                    GroupName = "One One One",
                    Salary = 13d
                }
            };



            var mergeExpression = context.CreateMergeUsing(people)
               .Target("Person")
               .On(p => p.Number)
               .WhenNotMatchedBySource()
               .ThenInsert(p => new { p.Number, p.Name, p.Age })
               .WhenMatchedAndSource(src => src.Name.StartsWith("N"))
               .ThenUpdate((tgt, src) => new { Salary = src.Salary + tgt.Salary });

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Not Matched
	Then Insert(Number, Name, Age)
		Values(src.Number, src.Name, src.Age)
When Matched And src.Name Like 'N%'
	Then Update Set
		tgt.Salary = src.Salary + tgt.Salary;";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

    }
}
