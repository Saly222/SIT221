using System;
using System.Collections.Generic;

namespace Vector
{

    public class AscendingIntComparer : IComparer<int>
    {
        public int Compare(int A, int B)
        {
            return A - B;
        }
    }

    public class DescendingIntComparer : IComparer<int>
    {
        public int Compare(int A, int B)
        {
            return B - A;
        }
    }

    class Tester
    {
        static void Main(string[] args)
        {
            string result = "";
            int problem_size = 20;
            int[] data = new int[problem_size]; data[0] = 333;
            Random k = new Random(1000);
            for (int i = 1; i < problem_size; i++) data[i] = 100 + k.Next(900);
            Vector<int> vector = null;

            // ------------------ BinarySearch ----------------------------------
            int[] temp = null; int check;

            try
            {
                temp = new int[problem_size];
                data.CopyTo(temp, 0);
                Array.Sort(temp, new AscendingIntComparer());
                Console.WriteLine("\nTest A: Search for key 333 in the array of integer numbers sorted via the AscendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(temp[i]);
                Console.WriteLine("Elements in the Vector: " + vector.ToString());
                check = Array.BinarySearch(temp, 333, new AscendingIntComparer());
                check = check < 0 ? -1 : check;
                if (vector.BinarySearch(333, new AscendingIntComparer()) != check)
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                   Console.WriteLine(" :: SUCCESS");
                   result = result + "A";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                temp = new int[problem_size];
                data.CopyTo(temp, 0);
                Array.Sort(temp, new AscendingIntComparer());
                Console.WriteLine("\nTest B: Search for key " + (temp[0] - 1) + " in the array of integer numbers sorted via the AscendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(temp[i]);
                Console.WriteLine("Elements in the Vector: " + vector.ToString());
                check = Array.BinarySearch(temp, temp[0] - 1, new AscendingIntComparer());
                check = check < 0 ? -1 : check;
                if (vector.BinarySearch(temp[0] - 1, new AscendingIntComparer()) != check)
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                   Console.WriteLine(" :: SUCCESS");
                   result = result + "B";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                temp = new int[problem_size];
                data.CopyTo(temp, 0);
                Array.Sort(temp, new AscendingIntComparer());
                Console.WriteLine("\nTest C: Search for key " + (temp[problem_size - 1] + 1) + " in the array of integer numbers sorted via the AscendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(temp[i]);
                Console.WriteLine("Elements in the Vector: " + vector.ToString());
                check = Array.BinarySearch(temp, temp[problem_size - 1] + 1, new AscendingIntComparer());
                check = check < 0 ? -1 : check;
                if (vector.BinarySearch(temp[problem_size - 1] + 1, new AscendingIntComparer()) != check)
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                   Console.WriteLine(" :: SUCCESS");
                   result = result + "C";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                temp = new int[problem_size];
                data.CopyTo(temp, 0);
                Array.Sort(temp, new DescendingIntComparer());
                Console.WriteLine("\nTest D: Search for key 333 in the array of integer numbers sorted via the DescendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(temp[i]);
                Console.WriteLine("Elements in the Vector: " + vector.ToString());
                check = Array.BinarySearch(temp, 333, new DescendingIntComparer());
                check = check < 0 ? -1 : check;
                if (vector.BinarySearch(333, new DescendingIntComparer()) != check)
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                   Console.WriteLine(" :: SUCCESS");
                   result = result + "D";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                temp = new int[problem_size];
                data.CopyTo(temp, 0);
                Array.Sort(temp, new DescendingIntComparer());
                Console.WriteLine("\nTest E: Search for key " + (temp[0] - 1) + " in the array of integer numbers sorted via the DescendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(temp[i]);
                Console.WriteLine("Elements in the Vector: " + vector.ToString());
                check = Array.BinarySearch(temp, temp[0] - 1, new DescendingIntComparer());
                check = check < 0 ? -1 : check;
                if (vector.BinarySearch(temp[0] - 1, new DescendingIntComparer()) != check)
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                   Console.WriteLine(" :: SUCCESS");
                   result = result + "E";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                temp = new int[problem_size];
                data.CopyTo(temp, 0);
                Array.Sort(temp, new DescendingIntComparer());
                Console.WriteLine("\nTest F: Search for key " + (temp[problem_size - 1] + 1) + " in the array of integer numbers sorted via the DescendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(temp[i]);
                Console.WriteLine("Elements in the Vector: " + vector.ToString());
                check = Array.BinarySearch(temp, temp[problem_size - 1] + 1, new DescendingIntComparer());
                check = check < 0 ? -1 : check;
                if (vector.BinarySearch(temp[problem_size - 1] + 1, new DescendingIntComparer()) != check)
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                   Console.WriteLine(" :: SUCCESS");
                   result = result + "F";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            Console.WriteLine("\n\n ------------------- SUMMARY ------------------- ");
            Console.WriteLine("Tests passed: " + result);
            Console.ReadKey();
        }
    }
}
