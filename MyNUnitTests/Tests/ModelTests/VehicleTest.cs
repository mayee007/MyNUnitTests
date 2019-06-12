using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MyNUnitTests.model; 

namespace MyNUnitTests.Tests.ModelTests
{
    [Category("modelTests")]
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    [Author("M M", "a@a.com")]
    class VehicleTest
    {
        Vehicle vehicle; 

        [OneTimeSetUp]
        public void setup()
        {
            vehicle = new Vehicle("black", 4); 
        }

        [TearDown]
        public void destroy()
        {}

        [TestCase]
        public void testAllWheels()
        {            
            Assert.AreEqual(4, vehicle.wheels);
        }

        [TestCase(5)]
        [TestCase(6)]
        [TestCase(2)]
        [TestCase(18)]
        [TestCase(8)]
        public void testAllValidWheels(int totalWheels)
        {
            Assert.IsTrue(vehicle.isValidNumberOfWheels(totalWheels)); 
        }

        [TestCase(1)]
        [TestCase(19)]
        [TestCase(-1)]
        [TestCase(0)]
        public void testAllInValidWheels(int totalWheels)
        {
            Assert.IsFalse(vehicle.isValidNumberOfWheels(totalWheels));
        }
    }
}
