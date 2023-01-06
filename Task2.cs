using NUnit.Framework;
using System.Collections.Generic;

namespace Task2_DT
{
    public class Task2_DT
    {
        public static string first_non_repeating_letter(string enter)
        {
            char[] string_char = enter.ToCharArray();
            for (int current = 0; current < string_char.Length; current++)
            {
                if (!string_char[current].Equals(' ') &&
                       enter.IndexOf(string_char[current]) == enter.LastIndexOf(enter[current]) &&
                     (enter.LastIndexOf(enter[current].ToString().ToUpper()) == -1 || enter.LastIndexOf(enter[current].ToString().ToLower()) == -1)
                     )
                {
                    return enter[current].ToString();
                }
            }
            return "No letters";
        }

        [Test]
        public void Testing1()
        {
            string input = "reconnaissance";
            string expected = "r";

            input = first_non_repeating_letter((input));

            Assert.AreEqual(expected, input);
        }
        [Test]
        public void Testing2()
        {
            string input = "I am ukrainian";
            string expected = "m";

            input = first_non_repeating_letter((input));

            Assert.AreEqual(expected, input);
        }
        [Test]
        public void Testing3()
        {
            string input = "MoM wAsHeD tHe WiNdOw FrAmE";
            string expected = "s";

            input = first_non_repeating_letter((input));

            Assert.AreEqual(expected, input);
        }
    }
}