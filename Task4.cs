using NUnit.Framework;
using System.Collections.Generic;

namespace Task4_DT
{
    public class Task4_DT
    {
        public static int counter(int[] arr, int target)
        {
            int temp = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] + arr[j] == target)
                    {
                        temp++;
                    }
                }
            }
            return temp;
        }
        [Test]
        public void Testing1()
        {
            int[] inputList = { 1, 3, 6, 2, 2, 4, 5 };
            int target = 5;
            int expected = 3;

            int pairs = counter(inputList, target);

            Assert.AreEqual(expected, pairs);
        }
        [Test]
        public void Testing2()
        {
            int[] inputList = { 1, 3, 6, 2, 2, 0, 4, 5 };
            int target = 5;
            int expected = 4;

            int pairs = counter(inputList, target);

            Assert.AreEqual(expected, pairs);
        }
        [Test]
        public void Testing3()
        {
            int[] inputList = { 7, 3, 6, 2, 2, 1, 4, 3 };
            int target = 5;
            int expected = 5;

            int pairs = counter(inputList, target);

            Assert.AreEqual(expected, pairs);
        }
    }
}