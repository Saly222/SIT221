using System;
using System.Collections.Generic;
using Vector;

namespace Vector
{
    // SelectionSort class implements the ISorter interface
    public class SelectionSort : ISorter
    {
        // The Sort method takes an array, start index, count of elements to sort, and a comparer.
        public void Sort<T>(T[] data, int start, int count, IComparer<T> comparer) where T : IComparable<T>
        {
            //repeatedly find the minimum element and swap it with the first unsorted element
            for (int i = start; i < start + count - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < start + count; j++)
                {
                    if (comparer.Compare(data[j], data[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }
                // Swap the minimum element found with the element at index i
                if (minIndex != i)
                {
                    T temp = data[i];
                    data[i] = data[minIndex];
                    data[minIndex] = temp;
                }
            }
        }
    }
}
