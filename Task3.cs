using NUnit.Framework;
using System.Collections.Generic;

namespace Task3_DT
{
    public class Task3_DT
    {
        public static int digital_root(int current)
        {
            int temp = 0;
            while (current > 0)
            {
                temp += current % 10;
                current /= 10;
            }
            if (temp > 9)
            {
                temp = digital_root(temp);
            }
            return temp;
        }

        [Test]
        public void Testing1()
        {
            int input = 16;
            int expected = 7;

            input = digital_root(input);

            Assert.AreEqual(expected, input);
        }
        [Test]
        public void Testing2()
        {
            int input = 4954;
            int expected = 4;

            input = digital_root(input);

            Assert.AreEqual(expected, input);
        }
        [Test]
        public void Testing3()
        {
            int input = 22022003;
            int expected = 2;

            input = digital_root(input);

            Assert.AreEqual(expected, input);
        }
    }
}