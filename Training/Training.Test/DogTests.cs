using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Training.Test
{
    [TestFixture]
    public class DogTests
    {
        public DogTests()
        {

        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DogCanMoveReturnsIRun_Test()
        {
            Dog dog = new Dog("Tom", "White", false);

            Assert.That(dog.Move(), Is.EqualTo("I run."));
        }

        [Test]
        public void DogCanSpeakReturnsBarkWoof_Test()
        {
            Dog dog = new Dog("Bill", "Red", true);

            Assert.That(dog.Speak(), Is.EqualTo("BARK WOOF!"));
        }

        [Test]
        public void DifferentDogsComparedProduceFalse_Test()
        {
            Dog dog1 = new Dog("Tom", "White", false);
            Dog dog2 = new Dog("Blue", "Grey", true);

            Assert.That(dog1.CompareTo(dog2), Is.EqualTo(1));
        }

        [Test]
        public void DogHasASize()
        {
            Dog dog = new Dog("Bilbo", "Red", true);
            var dogProps = dog.GetType().GetProperties();
            bool hasSize = false;
            foreach(var prop in dogProps)
            {
                if (prop.Name.ToString().Equals("Size"))
                {
                    hasSize = true;
                }
            }
            Assert.That(hasSize.Equals(true));
        }

        [TestCase(DogSize.Large)]
        [TestCase(DogSize.Medium)]
        [TestCase(DogSize.Small)]
        public void DogSizeIsAsExpected_Test(DogSize size)
        {
            Dog dog = new Dog("Bilbo", "Red", true, size);

            Assert.That(size, Is.EqualTo(dog.Size));
        }


        // NO LONGER EXISTS IN NUNIT 3.0
        //[Test]
        //[ExpectedException(typeof(DidNotComputeException))]
        //public void HandlesDidNotComputeException_Test()
        //{
        //    throw new DidNotComputeException("Did not compute");
        //} 



        [TearDown]
        public void TearDown()
        {

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

        }
    }
}