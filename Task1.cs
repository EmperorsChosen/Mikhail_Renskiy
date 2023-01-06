using NuGet.Frameworks;
using NUnit.Framework;
using System.Collections.Generic;

namespace Testing
{
    public class Testing
    {
        public static List<object> GetAllIntegers(List<object> list)
        {
            for (int current = 0; current < list.Count; current++)
            {

                if (int.TryParse(list[current].ToString(), out var temp))
                {
                    if (!list[current].Equals(temp))
                    {
                        list.RemoveAt(current);
                        current--;
                    }
                }
                else
                {
                    list.RemoveAt(current);
                    current--;
                }
            }
            return list;
        }

        [Test]
        public void Testing1()
        {
            List<object> listInput = new List<object> { 1, 2, "a", "b", "c" };
            List<object> listExpected = new List<object> { 1, 2 };

            listInput = GetAllIntegers(listInput);

            Assert.AreEqual(listExpected, listInput);
        }
        [Test]
        public void Testing2()
        {
            List<object> listInput = new List<object>() { 1, 2, "a", "b", 0, 15, "d", 35 };
            List<object> listExpected = new List<object>() { 1, 2, 0, 15, 35 };

            listInput = GetAllIntegers(listInput);

            Assert.AreEqual(listExpected, listInput);
        }
        [Test]
        public void Testing3()
        {
            List<object> listInput = new List<object>() { 1, 2, "a", "b", "absdasda", "1", "12342", 250, "dwqeeq", "fdsf", 12 };
            List<object> listExpected = new List<object>() { 1, 2, 250, 12 };

            listInput = GetAllIntegers(listInput);

            Assert.AreEqual(listExpected, listInput);
        }
    }
}