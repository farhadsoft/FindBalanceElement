using System;
using NUnit.Framework;

namespace FindBalanceElementTask.Tests
{
    public class ArrayExtensionTests
    {
        [TestCase(new int[] { 50, int.MinValue, 25, 25 }, ExpectedResult = 1)]
        [TestCase(new int[] { 25, 25, 10, 25, 25 }, ExpectedResult = 2)]
        [TestCase(new int[] { 25, 25, int.MaxValue, 50 }, ExpectedResult = 2)]
        [TestCase(new int[] { -50, -25, -20, -5, 500, -100 }, ExpectedResult = 4)]
        [TestCase(new int[] { 1, 2, 1 }, ExpectedResult = 1)]
        [TestCase(new int[] { -1, 2, 3, 1 }, ExpectedResult = 2)]
        [TestCase(new int[] { 100, -1, 50, -1, 100 }, ExpectedResult = 2)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, ExpectedResult = 5)]
        [TestCase(new int[] { 0, 0, 0 }, ExpectedResult = 1)]
        [TestCase(new int[] { int.MinValue, int.MinValue, 50, int.MinValue, int.MinValue }, ExpectedResult = 2)]
        public int FindBalanceElement_Returns_Index_Of_Balance_Element(int[] array) => 
            ArrayExtension.FindBalanceElement(array).Value;

        [TestCase(new int[] { 0, 50 }, ExpectedResult = null)]
        [TestCase(new int[] { 100 }, ExpectedResult = null)]
        [TestCase(new int[] { int.MaxValue, int.MaxValue, int.MaxValue, 50 }, ExpectedResult = null)]
        [TestCase(new int[] { int.MaxValue, 10, int.MaxValue, int.MaxValue, 50 }, ExpectedResult = null)]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, ExpectedResult = null)]
        [TestCase(new int[] { 1, 2, 1, 50000 }, ExpectedResult = null)]
        public int? FindBalanceElement_Returns_Null(int[] array)
            => ArrayExtension.FindBalanceElement(array);

        [Test]
        public void FindBalanceElement_Throw_ArgumentNullException_If_Array_Is_Null() =>
            Assert.Throws<ArgumentNullException>(() => ArrayExtension.FindBalanceElement(null),
                message: "Array can not be null.");
        [Test]
        public void FindBalanceElement_Throw_ArgumentException_If_Array_Is_Empty() =>
            Assert.Throws<ArgumentException>(() => ArrayExtension.FindBalanceElement(new int[] { }),
                message: "Array can not be empty.");
    }
}