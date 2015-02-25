using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomLinkedList;

namespace TestCustomLinkedList
{
    [TestClass]
    public class CustomLinkedListTests
    {
        private DynamicList<int> dynamicList;

        [TestInitialize]
        public void TestInitialize()
        {
             dynamicList = new DynamicList<int>();
        }

        [TestMethod]
        public void TestDynamicListCountAfterInitialize()
        {
            Assert.AreEqual(0,dynamicList.Count);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void TestTakingElementFromEmptyList()
        {
            int number = dynamicList[0];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestTakingElementFromEmptyListOnNegativeIndex()
        {
            int number = dynamicList[-2];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSettingElementInEmptyList()
        {
            dynamicList[0] = 3;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSettingElementInEmptyListOnNegativeIndex()
        {
            dynamicList[-5] = 3;
        }

        [TestMethod]
        public void TestTakingElementFromList()
        {
            dynamicList.Add(3);
            dynamicList.Add(5);
            dynamicList.Add(8);
            int number = dynamicList[1];
            Assert.AreEqual(5, number);
        }

        [TestMethod]
        public void TestSettingElementInListAtGivenIndex()
        {
            dynamicList.Add(3);
            dynamicList.Add(5);
            dynamicList.Add(8);
            dynamicList[1] = 10;
            Assert.AreEqual(10, dynamicList[1]);
        }

        [TestMethod]
        public void TestRemovingElementInListAtGivenIndex()
        {
            dynamicList.Add(3);
            dynamicList.Add(5);
            dynamicList.Add(8);
            dynamicList.RemoveAt(1);
            Assert.AreEqual(2, dynamicList.Count);
        }

        [TestMethod]
        public void TestRemovingElementAndCheckList()
        {
            dynamicList.Add(3);
            dynamicList.Add(5);
            dynamicList.Add(8);
            dynamicList.RemoveAt(1);

            string expectedNumbers = "38";
            string numbers = "";
            for (int i = 0; i < dynamicList.Count; i++)
            {
                numbers += dynamicList[i];
            }

            Assert.AreEqual(expectedNumbers, numbers);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRemovingElementAtInvalidIndex()
        {
            dynamicList.Add(3);
            dynamicList.Add(5);
            dynamicList.RemoveAt(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRemovingElementAtNegativeIndex()
        {
            dynamicList.RemoveAt(-2);
        }

        [TestMethod]
        public void TestRemovingElementByValueAndCheckList()
        {
            dynamicList.Add(3);
            dynamicList.Add(5);
            dynamicList.Add(8);
            dynamicList.Remove(5);

            string expectedNumbers = "38";
            string numbers = "";
            for (int i = 0; i < dynamicList.Count; i++)
            {
                numbers += dynamicList[i];
            }

            Assert.AreEqual(expectedNumbers, numbers);
        }

        [TestMethod]
        public void TestRemovingNonExistingElementByValue()
        {
            dynamicList.Add(3);
            dynamicList.Add(5);
            dynamicList.Add(8);
            int result = dynamicList.Remove(10);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestIndexOfExistingElement()
        {
            dynamicList.Add(3);
            dynamicList.Add(5);
            dynamicList.Add(8);
            int result = dynamicList.IndexOf(5);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestIndexOfNonExistingElement()
        {
            dynamicList.Add(3);
            dynamicList.Add(5);
            dynamicList.Add(8);
            int result = dynamicList.IndexOf(10);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestContainsExistingElement()
        {
            dynamicList.Add(3);
            dynamicList.Add(5);
            dynamicList.Add(8);
            bool contains = dynamicList.Contains(5);

            Assert.IsTrue(contains);
        }

        [TestMethod]
        public void TestContainsNonExistingElement()
        {
            dynamicList.Add(3);
            dynamicList.Add(5);
            dynamicList.Add(8);
            bool contains = dynamicList.Contains(10);

            Assert.IsFalse(contains);
        }
    }
}
