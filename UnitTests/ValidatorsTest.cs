using System;
using System.IO;
using Dal.Model;
using Dal.Repository;
using GuessNumber;
using GuessNumber.GameTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests
{
    [TestClass]
    public class ValidatorsTest
    {
        private MinMaxValidator validator;

        public void Setup(int _min, int _max)
        {
            validator = new MinMaxValidator(_min, _max);
        }

        [TestMethod]
        public void IsValidMinMaxValidator()
        {
            validator = new MinMaxValidator(5, 7);
            Assert.IsTrue(validator.IsValid(6));
            Assert.IsFalse(validator.IsValid(4));
            Assert.IsFalse(validator.IsValid(8));
        }

        [TestMethod]
        public void MinValueLessMaxValueOfValidator()
        {
            Setup(2,7);
            Assert.IsTrue(validator.minValue < validator.maxValue);
        }

        [TestMethod]
        public void GetRandomNumberIsValid()
        {
            Setup(3, 8);
            var game = new EasyLevelGame();
            var num = game.GetRandomNumber(3,5);
            Assert.IsNotNull(num);
        }

        
    }
}
