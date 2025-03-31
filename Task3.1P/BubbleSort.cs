using System;
using System.Collections.Generic;
using Vector;

namespace SortingAlgorithms
{
    // BubbleSort class implements the ISorter interface
    public class BubbleSort : ISorter
    {
        // The Sort method takes an array, start index, count of elements to sort, and a comparer.
        public void Sort<T>(T[] data, int start, int count, IComparer<T> comparer) where T : IComparable<T>
        {
            bool swapped;
            // repeatedly swap adjacent elements if they are in the wrong order
            for (int i = start; i < start + count - 1; i++)
            {
                swapped = false;
                for (int j = start; j < start + count - i - 1; j++)
                {   
                    if (comparer.Compare(data[j], data[j + 1]) > 0)
                    {    
                        T temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;
                        swapped = true;
                    }
                }
                if (swapped == false) break;
            }
        }
    }
}
