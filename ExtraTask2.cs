using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;

namespace ExtraTask2_DT
{
    public class ExtraTask2_DT
    {
        public static string uintToAdress(uint dig)
        {
            int temp = 0;
            uint[] tempArr = new uint[32];
            while (temp < 32)
            {
                tempArr[temp] = (dig % 2);
                dig /= 2;
                temp++;
            }
            temp = 0;
            string result = "";
            while (temp < 4)
            {
                uint dec = 0;
                int pow = 0;
                for (int j = temp * 8; j < temp * 8 + 8; j++)
                {
                    dec += tempArr[j] * (uint)Math.Pow(2, pow);
                    pow++;
                }
                result = result.Insert(0, dec.ToString());
                if (temp != 3)
                {
                    result = result.Insert(0, ".");
                }
                temp++;
            }
            return result;
        }
        [Test]
        public void ExtraTask2Test2()
        {
            uint input = 21;
            string expected = "0.0.0.21";

            string result = uintToAdress(input);

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void ExtraTask2Test1()
        {
            uint input = 2149583361;
            string expected = "128.32.10.1";

            string result = uintToAdress(input);

            Assert.AreEqual(expected, result);
        }

    }
}