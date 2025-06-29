using NUnit.Framework;
using CalcLibrary;
using System;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private SimpleCalculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new SimpleCalculator();
        }

        [TearDown]
        public void Cleanup()
        {
            calculator.AllClear();
        }

        [Test]
        [TestCase(5, 3, 8)]
        [TestCase(-2, 10, 8)]
        [TestCase(0, 0, 0)]
        public void TestAddition(double a, double b, double expected)
        {
            double result = calculator.Addition(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(10, 4, 6)]
        [TestCase(5, -3, 8)]
        public void TestSubtraction(double a, double b, double expected)
        {
            double result = calculator.Subtraction(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(3, 4, 12)]
        [TestCase(7, 0, 0)]
        public void TestMultiplication(double a, double b, double expected)
        {
            double result = calculator.Multiplication(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(20, 5, 4)]
        public void TestDivision(double a, double b, double expected)
        {
            double result = calculator.Division(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestDivisionByZero()
        {
            Assert.Throws<ArgumentException>(() => calculator.Division(10, 0));
        }
    }
}
