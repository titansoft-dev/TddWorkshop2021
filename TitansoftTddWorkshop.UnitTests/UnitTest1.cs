using NUnit.Framework;

//An Environment Test
namespace TitansoftTddWorkshop.UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass("Your environment is ready");
        }
       
        
    }
}