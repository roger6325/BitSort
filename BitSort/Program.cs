using System.IO;
using System;
namespace com.futurecrew.sorting
{
    class BitSort
    {
        const int BitShift = 3;
        const int BitsPerByte = 8;
        const int BitMask = 0x07;
        const int MaxNumber = 30;
        const int Numbers = 10;

        static void Debug(int number)
        {
            int Address = (number & (int)BitMask);
            int Offset = number >> BitShift;
            int Value = 1 << Address;
            string text = string.Format("Offset:{0}, Address:{1}, Value:{2}", Offset, Address, Value);
            System.Diagnostics.Debug.WriteLine(text);
        }
        static void Set(byte[] output, int number)
        {
            Debug(number);
            output[number >> BitShift] |= (byte)(1 << (number & (int)BitMask));
        }

        static bool Test(byte[] output, int number)
        {
            Debug(number);
            int result = (int)output[number >> BitShift] & (int)(1 << (number & (int)BitMask));
            if (result == 0)
                return false;
            else
                return true;
        }

        static void Main()
        {
            string text = "";
            int[] input = new int[Numbers] { 11, 15, 19, 21, 25, 1, 3, 5, 7, 9 };
            int size = (MaxNumber / BitsPerByte) + 1;
            byte[] output = new byte[size];
            for (int i = 0; i < Numbers; i++)
            {
                Set(output, input[i]);
            }

            for (int i = 0; i < MaxNumber; i++)
            {
                if (Test(output, i) == true)
                {
                    text = string.Format("{0}: is found", i);
                    System.Diagnostics.Debug.WriteLine(text);
                    Console.WriteLine(text);
                }
                else
                {
                    text = string.Format("{0}: is empty", i);
                }
                //Console.WriteLine(text);
            }
        }
    }
    class QuickSort
    {
        static void Sort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int i = left - 1;   //left margin
                int j = right + 1;  //right margin
                int axle = array[(left + right) / 2];  //axle

                while (true)
                {
                    while (array[++i] < axle) ;
                    while (array[--j] > axle) ;
                    if (i >= j)
                        break;

                    //swap
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }

                Sort(array, left, i - 1);
                Sort(array, j + 1, right);
            }
        }
    }
}
