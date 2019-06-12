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
    class VehicleModelTest
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

        [Repeat(1000)]
        [TestCase(4, ExpectedResult = true)]
        [TestCase(1, ExpectedResult = false)]
        [TestCase(0, ExpectedResult = false)]
        [TestCase(5, ExpectedResult = false)]
        [TestCase(100, ExpectedResult = false)]
        [TestCase(-4, ExpectedResult = false)]
        public Boolean testAllWheels(int wheels)
        {            
            return wheels == vehicle.wheels;
        }

        [TestCase("pink", ExpectedResult = false)]
        [TestCase("black", ExpectedResult = true)]
        [TestCase("brown", ExpectedResult = false)]
        [TestCase("silver", ExpectedResult = false)]
        [TestCase("", ExpectedResult = false)]
        [TestCase("blue", ExpectedResult = false)]
        [Repeat(20)]
        public Boolean testColor(String color)
        {
            return vehicle.color.Equals(color);
        }

        [TestCase(Ignore = "test case not ready yet")]
        public void halfComplete()
        {

        }

    }
}
