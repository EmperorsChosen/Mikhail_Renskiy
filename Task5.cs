using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Task5_DT
{
    public class Task5Tests
    {
        public static string invitations(string scroll)
        {
            string[] temp = scroll.Split(new char[] { ';', ':' });
            string[] list = new string[temp.Length / 2];
            for (int i = 0; i < temp.Length / 2; i++)
            {
                list[i] = "(" + temp[i * 2 + 1].ToUpper() + ", " + temp[i * 2].ToUpper() + ")";
            }
            Array.Sort(list);
            string result = "";
            for (int i = 0; i < list.Length; i++)
            {
                result += list[i];
            }
            return result;
        }

        [Test]
        public void Testing1()
        {
            string input = "Fred:Corwill;Wilfred:Corwill;Barney:TornBull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill";
            string expected = "(CORWILL, ALFRED)(CORWILL, FRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)";

            input = invitations(input);

            Assert.AreEqual(expected, input);
        }
        [Test]
        public void Testing2()
        {
            string input = "Fred:Corwill;Wilfred:Corwill;Bart:Topaz;Anna:Topaz;Volodymyr:Zelenskiy;Viktor:Shevchenko;Alfred:Corwill";
            string expected = "(CORWILL, ALFRED)(CORWILL, FRED)(CORWILL, WILFRED)(SHEVCHENKO, VIKTOR)(TOPAZ, ANNA)(TOPAZ, BART)(ZELENSKIY, VOLODYMYR)";

            input = invitations(input);

            Assert.AreEqual(expected, input);
        }
    }
}