using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace ExtraTask1_DT
{
    public class ExtraTask1_DT
    {
        public static int rearrange_number(int current)
        {
            int[] arr = new int[current.ToString().Length];
            int pointer = 0;
            while (current > 0)
            {
                arr[pointer] = current % 10;
                current /= 10;
                pointer++;
            }
            pointer = 0;
            bool checker = true;
            while (pointer < arr.Length - 1)
            {
                if (arr[pointer] > arr[pointer + 1])
                {
                    checker = false;
                    int temp = arr[pointer];
                    arr[pointer] = arr[pointer + 1];
                    arr[pointer + 1] = temp;
                    while (pointer > 0)
                    {
                        if (arr[pointer] > arr[pointer - 1])
                        {
                            temp = arr[pointer];
                            arr[pointer] = arr[pointer - 1];
                            arr[pointer - 1] = temp;
                        }
                        pointer--;
                    }
                    break;
                }
                else pointer++;
            }
            if (checker)
            {
                return -1;
            }
            current = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                current = current + arr[i] * (int)(Math.Pow(10, i));
            }
            return current;
        }


        [Test]
        public void Testing1()
        {
            int input = 9;
            int expected = -1;

            input = rearrange_number(input);

            Assert.AreEqual(expected, input);
        }
        [Test]
        public void Testing2()
        {
            int input = 1231;
            int expected = 1312;

            input = rearrange_number(input);

            Assert.AreEqual(expected, input);
        }
        [Test]
        public void testing3()
        {
            int input = 15;
            int expected = 51;

            input = rearrange_number(input);

            Assert.AreEqual(expected, input);
        }
    }
}