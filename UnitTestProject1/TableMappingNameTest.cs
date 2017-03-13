using NUnit.Framework;
using CompleteSQL.Mapping;
using UnitTestProject1.SqlTableEntity;

namespace UnitTestProject1
{
   
   [TestFixture]
    public class MappingTableNameTest
    {

       private SqlTableNameMapper mapper;
       [OneTimeSetUp]
       public void Init()
       {
            mapper = new SqlTableNameMapper();
       }

       [Test]
       public void WithoutSqlTableAttributeTest()
       {
           Assert.That(() =>
           {
               var mapInfo = mapper.GetFullTableName(typeof(WithoutSqlTableAttributeEntity));
           }, Throws.ArgumentException);
       }


       [Test]
       public void WithoutTableNameTest()
       {
           var tableName = mapper.GetFullTableName(typeof(TestEntity)).ToString();

           Assert.AreEqual("TestEntity", tableName);
       }

       [Test]
       public void WithTableNameTest()
       {
           var tableName = mapper.GetFullTableName(typeof(TestEntityWithName)).ToString();

           Assert.AreEqual("Test", tableName);
       }
    }
}
