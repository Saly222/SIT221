using System;
using System.Collections.Generic;
using Vector;

namespace Vector
{
    public class InsertionSort : ISorter
    {
        // The Sort method sorts an array using the insertion sort algorithm.
        public void Sort<T>(T[] data, int start, int count, IComparer<T> comparer) where T : IComparable<T>
        {
            //Iterate through the array from the 'start' index to 'start + count'
            for (int i = start + 1; i < start + count; i++)
            {
                // Store the current element
                T currentElement = data[i];
                int j = i - 1;

                // Shift elements of the sorted part to the right, if they are greater than currentElement
                while (j >= start && comparer.Compare(data[j], currentElement) > 0)
                {
                    data[j + 1] = data[j];  
                    j--;
                }

                // Place the currentElement at its correct position
                data[j + 1] = currentElement;
            }
        }
    }
}
