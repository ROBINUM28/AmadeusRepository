using NUnit.Framework;
using System.Threading.Tasks;
using Amadeus.Entities;

namespace Amadeus.TestNUnit
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

       

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task CreateTravel(int value)
        {
            ModelTravel temp = await Amadeus.DAL.FunctionsDAL.CreateTravel(System.DateTime.Now,"Obs","Email","Name",true,1);
            Assert.Pass();
        }


       
    }
}