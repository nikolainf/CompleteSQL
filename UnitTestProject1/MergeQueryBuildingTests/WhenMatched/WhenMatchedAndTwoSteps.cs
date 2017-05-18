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
    public class WhenMatchedAndTwoSteps
    {
        /// <summary>
        /// WhenMatchedAnd
        /// ThenUpdate
        /// WhenMatched
        /// ThenDelete
        /// </summary>
        [Test]
        public void WhenMatchedAndThenUdpateWhenMatchedThenDeleteTest()
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

            DataContext context = new DataContext("CompleteSQL");

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("Person")
               .On(p => p.Number)
               .WhenMatchedAndTarget(p => p.Age > 18)
               .ThenUpdate((tgt, src) => new { Age = src.Age })
               .WhenMatched()
               .ThenDelete();

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Matched And tgt.Age > 18
	Then Update Set
		tgt.Age = src.Age
When Matched
	Then Delete;";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        /// <summary>
        /// WhenMatchedAnd
        /// ThenUpdate
        /// WhenMatchedAnd
        /// ThenDelete
        /// </summary>
        [Test]
        public void WhenMatchedAndTargetThenUdpateWhenMatchedAndThenDeleteTest()
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

            DataContext context = new DataContext("CompleteSQL");

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("Person")
               .On(p => p.Number)
               .WhenMatchedAndTarget(p => p.Age > 18)
               .ThenUpdate((tgt, src) => new { Age = src.Age })
               .WhenMatchedAndTarget(p => p.Age > 100)
               .ThenDelete();

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Matched And tgt.Age > 18
	Then Update Set
		tgt.Age = src.Age
When Matched And tgt.Age > 100
	Then Delete;";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        /// <summary>
        /// WhenMatchedAnd
        /// ThenUpdate
        /// WhenMatchedAndSource
        /// ThenDelete
        /// </summary>
        [Test]
        public void WhenMatchedAndThenUdpateWhenMatchedAndSourceThenDeleteTest()
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

            DataContext context = new DataContext("CompleteSQL");

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("Person")
               .On(p => p.Number)
               .WhenMatchedAndTarget(p => p.Age > 18)
               .ThenUpdate()
               .WhenMatchedAndSource(p => p.Age > 100)
               .ThenDelete();

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Matched And tgt.Age > 18
	Then Update Set
		tgt.Name = src.Name,
		tgt.Age = src.Age,
		tgt.GroupNumber = src.GroupNumber,
		tgt.GroupName = src.GroupName,
		tgt.Salary = src.Salary
When Matched And src.Age > 100
	Then Delete;";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        /// <summary>
        /// WhenMatchedAnd
        /// ThenDelete
        /// WhenMatched
        /// ThenUpdate
        /// </summary>
        [Test]
        public void WhenMatchedAndThenDeleteWhenMatchedThenUpdateTest()
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
                    Salary = 13m
                }
            };

            DataContext context = new DataContext("CompleteSQL");

            var mergeExpression = context.CreateMergeUsing(people)
                .Target("Person")
                .On(p => p.Number)
                .WhenMatchedAndTarget(p => p.Age > 100)
                .ThenDelete()
                .WhenMatched()
                .ThenUpdate((tgt, src) => new { Age = src.Age });

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Matched And tgt.Age > 100
	Then Delete
When Matched
	Then Update Set
		tgt.Age = src.Age;";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);




        }

        /// <summary>
        /// WhenMatchedAnd
        /// ThenDelete
        /// WhenMatchedAnd
        /// ThenUpdate
        /// </summary>
        [Test]
        public void WhenMatchedAndThenDeleteWhenMatchedAndThenUdapteTest()
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

            DataContext context = new DataContext("CompleteSQL");

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("Person")
               .On(p => p.Number)
               .WhenMatchedAndTarget(p => p.Age > 100)
               .ThenDelete()
               .WhenMatchedAndTarget(p => p.Age > 18)
               .ThenUpdate((tgt, src) => new { Age = src.Age });

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Matched And tgt.Age > 100
	Then Delete
When Matched And tgt.Age > 18
	Then Update Set
		tgt.Age = src.Age;";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        /// <summary>
        /// WhenMatchedAnd
        /// ThenUpdate
        /// WhenNotMatched
        /// ThenInsert
        /// </summary>
        [Test]
        public void WhenMatchedAndThenUdpateWhenNotMatchedThenInsertTest()
        {
            var people = new[]
            {
                new
                {
                    Number = 50, 
                    Name = "Nikolai", 
                    Age = 32,
                    GroupNumber = 111, 
                    GroupName = "One One One",
                    Salary = 13m
                }
            };

            DataContext context = new DataContext("CompleteSQL");

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("Person")
               .On(p => p.Number)
               .WhenMatchedAndTarget(p => p.Age > 18)
               .ThenUpdate((tgt, src) => new { Age = src.Age })
               .WhenNotMatched()
               .ThenInsert();

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Matched And tgt.Age > 18
	Then Update Set
		tgt.Age = src.Age
When Not Matched
	Then Insert(Number, Name, Age, GroupNumber, GroupName, Salary)
		Values(src.Number, src.Name, src.Age, src.GroupNumber, src.GroupName, src.Salary);";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        /// <summary>
        /// WhenMatchedAnd
        /// ThenUpdate
        /// WhenNotMatched
        /// ThenInsert
        /// </summary>
        [Test]
        public void WhenMatchedAndThenUdpateWhenNotMatchedThenInsertDefinedColumnsTest()
        {
            var people = new[]
            {
                new
                {
                    Number = 50, 
                    Name = "Nikolai", 
                    Age = 32,
                    GroupNumber = 111, 
                    GroupName = "One One One",
                    Salary = 13m
                }
            };

            DataContext context = new DataContext("CompleteSQL");

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("Person")
               .On(p => p.Number)
               .WhenMatchedAndTarget(p => p.Age > 18)
               .ThenUpdate((tgt, src) => new { Age = src.Age })
               .WhenNotMatched()
               .ThenInsert(p=>new {p.Name, p.Age, GroupNumber = 112});

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Matched And tgt.Age > 18
	Then Update Set
		tgt.Age = src.Age
When Not Matched
	Then Insert(Name, Age, GroupNumber)
		Values(src.Name, src.Age, 112);";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }


        /// <summary>
        /// WhenMatchedAnd
        /// ThenUpdate
        /// WhenNotMatchedAnd
        /// ThenInsert
        /// </summary>
        [Test]
        public void WhenMatchedAndThenUdpateWhenNotMatchedAndThenInsertTest()
        {
            var people = new[]
            {
                new
                {
                    Number = 50, 
                    Name = "Nikolai", 
                    Age = 32,
                    GroupNumber = 111, 
                    GroupName = "One One One",
                    Salary = 13m
                }
            };

            DataContext context = new DataContext("CompleteSQL");

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("Person")
               .On(p => p.Number)
               .WhenMatchedAndTarget(p => p.Age > 18)
               .ThenUpdate((tgt, src) => new { Age = src.Age })
               .WhenNotMatchedAnd(p => p.GroupNumber == 10)
               .ThenInsert();

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Matched And tgt.Age > 18
	Then Update Set
		tgt.Age = src.Age
When Not Matched And src.GroupNumber = 10
	Then Insert(Number, Name, Age, GroupNumber, GroupName, Salary)
		Values(src.Number, src.Name, src.Age, src.GroupNumber, src.GroupName, src.Salary);";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        /// <summary>
        /// WhenMatchedAnd
        /// ThenUpdate
        /// WhenNotMatchedAnd
        /// ThenInsert
        /// </summary>
        [Test]
        public void WhenMatchedAndThenUdpateWhenNotMatchedAndThenInsertDefinedColumnsTest()
        {
            var people = new[]
            {
                new
                {
                    Number = 50, 
                    Name = "Nikolai", 
                    Age = 32,
                    GroupNumber = 111, 
                    GroupName = "One One One",
                    Salary = 13m
                }
            };

            DataContext context = new DataContext("CompleteSQL");

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("Person")
               .On(p => p.Number)
               .WhenMatchedAndTarget(p => p.Age > 18)
               .ThenUpdate((tgt, src) => new { Age = src.Age })
               .WhenNotMatchedAnd(p => p.GroupNumber == 10)
               .ThenInsert(p => new { p.Name, p.Age, GroupNumber = 112 });

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Matched And tgt.Age > 18
	Then Update Set
		tgt.Age = src.Age
When Not Matched And src.GroupNumber = 10
	Then Insert(Name, Age, GroupNumber)
		Values(src.Name, src.Age, 112);";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        /// <summary>
        /// WhenMatchedAnd
        /// ThenDelete
        /// WhenNotMatched
        /// ThenInsert
        /// </summary>
        [Test]
        public void WhenMatchedAndThenDeleteWhenNotMatchedThenInsertTest()
        {
            var people = new[]
            {
                new
                {
                    Number = 50, 
                    Name = "Nikolai", 
                    Age = 32,
                    GroupNumber = 111, 
                    GroupName = "One One One",
                    Salary = 13m
                }
            };

            DataContext context = new DataContext("CompleteSQL");

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("Person")
               .On(p => p.Number)
               .WhenMatchedAndTarget(p => p.Age > 18)
               .ThenDelete()
               .WhenNotMatched()
               .ThenInsert(p => new { p.Name, p.Age, GroupNumber = 112 });

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Matched And tgt.Age > 18
	Then Delete
When Not Matched
	Then Insert(Name, Age, GroupNumber)
		Values(src.Name, src.Age, 112);";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        /// <summary>
        /// WhenMatchedAnd
        /// ThenDelete
        /// WhenNotMatchedAnd
        /// ThenInsert
        [Test]
        public void WhenMatchedAndThenDeleteWhenNotMatchedAndThenInsertTest()
        {
            var people = new[]
            {
                new
                {
                    Number = 50, 
                    Name = "Nikolai", 
                    Age = 32,
                    GroupNumber = 111, 
                    GroupName = "One One One",
                    Salary = 13m
                }
            };

            DataContext context = new DataContext("CompleteSQL");

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("Person")
               .On(p => p.Number)
               .WhenMatchedAndTarget(p => p.Age > 18)
               .ThenDelete()
               .WhenNotMatchedAnd(p => p.GroupNumber == 10)
               .ThenInsert();

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Matched And tgt.Age > 18
	Then Delete
When Not Matched And src.GroupNumber = 10
	Then Insert(Number, Name, Age, GroupNumber, GroupName, Salary)
		Values(src.Number, src.Name, src.Age, src.GroupNumber, src.GroupName, src.Salary);";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        /// <summary>
        /// WhenMatchedAnd
        /// ThenUpdate
        /// WhenNotMatchedBySource
        /// ThenUpdate
        /// </summary>
        [Test]
        public void WhenMatchedAndThenUdpateWhenNotMatchedBySourceThenUpdate()
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

            DataContext context = new DataContext("CompleteSQL");

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("Person")
               .On(p => p.Number)
               .WhenMatchedAndTarget(p => p.Age > 18)
               .ThenUpdate((tgt, src) => new { Age = src.Age })
               .WhenNotMatchedBySource()
               .ThenUpdate(p => new
               {
                   Name = p.Name + "_NewValue",
                   Age = p.Age + 1,
                   Salary = p.Salary + 1000m
               });

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Matched And tgt.Age > 18
	Then Update Set
		tgt.Age = src.Age
When Not Matched By Source
	Then Update Set
		tgt.Name = tgt.Name + '_NewValue',
		tgt.Age = tgt.Age + 1,
		tgt.Salary = tgt.Salary + 1000;";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        /// <summary>
        /// WhenMatchedAnd
        /// ThenUpdate
        /// WhenNotMathcedBySourceAnd
        /// ThenUpdate
        /// </summary>
        [Test]
        public void WhenMatchedAndThenUdpateWhenNotMatchedBySourceAndThenUpdate()
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

            DataContext context = new DataContext("CompleteSQL");

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("Person")
               .On(p => p.Number)
               .WhenMatchedAndTarget(p => p.Age > 18)
               .ThenUpdate((tgt, src) => new { Age = src.Age })
               .WhenNotMatchedBySourceAnd(p => p.Age < 100)
               .ThenUpdate(p => new
               {
                   Name = p.Name + "_NewValue",
                   Age = p.Age + 1,
                   Salary = p.Salary + 1000m
               });

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Matched And tgt.Age > 18
	Then Update Set
		tgt.Age = src.Age
When Not Matched By Source And tgt.Age < 100
	Then Update Set
		tgt.Name = tgt.Name + '_NewValue',
		tgt.Age = tgt.Age + 1,
		tgt.Salary = tgt.Salary + 1000;";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }


        /// <summary>
        /// WhenMatchedAnd
        /// ThenUpdate
        /// WhenNotMatchedBySource
        /// ThenDelete
        /// </summary>
        [Test]
        public void WhenMatchedAndThenUdpateWhenNotMatchedBySourceThenDelete()
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

            DataContext context = new DataContext("CompleteSQL");

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("Person")
               .On(p => p.Number)
               .WhenMatchedAndTarget(p => p.Age > 18)
               .ThenUpdate((tgt, src) => new { Age = src.Age })
               .WhenNotMatchedBySource()
               .ThenDelete();

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Matched And tgt.Age > 18
	Then Update Set
		tgt.Age = src.Age
When Not Matched By Source
	Then Delete;";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }

        /// <summary>
        /// WhenMatchedAnd
        /// ThenUpdate
        /// WhenNotMatchedBySourceAnd
        /// ThenDelete
        /// </summary>
        [Test]
        public void WhenMatchedAndThenUdpateWhenNotMatchedBySourceAndThenDelete()
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

            DataContext context = new DataContext("CompleteSQL");

            var mergeExpression = context.CreateMergeUsing(people)
               .Target("Person")
               .On(p => p.Number)
               .WhenMatchedAndTarget(p => p.Age > 18)
               .ThenUpdate((tgt, src) => new { Age = src.Age })
               .WhenNotMatchedBySourceAnd(p=>p.Age == 100)
               .ThenDelete();

            string expectedQuery =
@"Merge Into Person as tgt
Using #Person as src
	On tgt.Number = src.Number
When Matched And tgt.Age > 18
	Then Update Set
		tgt.Age = src.Age
When Not Matched By Source And tgt.Age = 100
	Then Delete;";

            string query = mergeExpression.GetMergeQuery();

            Assert.AreEqual(expectedQuery, query);
        }


        
    }
}
