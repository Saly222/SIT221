﻿﻿﻿﻿﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Vector
{
    public class Vector<T> where T : IComparable<T>
    {
        // This constant determines the default number of elements in a newly created vector.
        // It is also used to extended the capacity of the existing vector
        private const int DEFAULT_CAPACITY = 10;

        // This array represents the internal data structure wrapped by the vector class.
        // In fact, all the elements are to be stored in this private  array. 
        // You will just write extra functionality (methods) to make the work with the array more convenient for the user.
        private T[] data;

        // This property represents the number of elements in the vector
        public int Count { get; private set; } = 0;

        // This property represents the maximum number of elements (capacity) in the vector
        public int Capacity
        {
            get { return data.Length; }
        }

        // This is an overloaded constructor
        public Vector(int capacity)
        {
            data = new T[capacity];
        }

        // This is the implementation of the default constructor
        public Vector() : this(DEFAULT_CAPACITY) { }

        // An Indexer is a special type of property that allows a class or structure to be accessed the same way as array for its internal collection. 
        // For example, introducing the following indexer you may address an element of the vector as vector[i] or vector[0] or ...
        public T this[int index]
        {
            get
            {
                if (index >= Count || index < 0) throw new IndexOutOfRangeException();
                return data[index];
            }
            set
            {
                if (index >= Count || index < 0) throw new IndexOutOfRangeException();
                data[index] = value;
            }
        }

        // This private method allows extension of the existing capacity of the vector by another 'extraCapacity' elements.
        // The new capacity is equal to the existing one plus 'extraCapacity'.
        // It copies the elements of 'data' (the existing array) to 'newData' (the new array), and then makes data pointing to 'newData'.
        private void ExtendData(int extraCapacity)
        {
            T[] newData = new T[Capacity + extraCapacity];
            for (int i = 0; i < Count; i++) newData[i] = data[i];
            data = newData;
        }


        // Performs binary search on sorted vector using the given comparer (or default if null).
        // Returns the index of the item if found, otherwise -1.
        public int BinarySearch(T item, IComparer<T> comparer)
        {   
            if (comparer == null)
            {
            comparer = Comparer<T>.Default;
            }

            int left = 0, right = Count -1;
            while (left <= right)
            {

                int mid = (left + right) / 2;
                int result = comparer.Compare(data[mid], item);


                if (result == 0)
                {
                    return mid;
                }
                if (0 > result)
                {
                    left = mid + 1;
                }
                else 
                {
                    right = mid - 1;
                }
            }
            return -1;

        }


        
        // This method sorts the elements of the 'data' array in the 'Vector<T>' collection
        // using a default comparison.
        public void sort()
        {
            Array.Sort(data, 0 , Count);
        }

        // This method sorts the elements of the 'data' array in the 'Vector<T>' collection
        // using a custom comparer 
        public void Sort(IComparer<T> comparer)
        {
            if (comparer == null)
            {
                Array.Sort(data, 0, Count);
            }
            else{
                Array.Sort(data, 0, Count, comparer);
            }
        }

        // Sorts the elements of an rray using the specified sorting algorithm and comparer.
        // If the 'algorithm' is null, Array.Sort will be use to provided comparer.
        // Otherwise, it uses the specified sorting algorithm to sort the array.
        public void Sort (ISorter algorithm, IComparer<T> comparer)

        {
            if (algorithm == null)
            {
                Array.Sort(data, 0, Count, comparer);
            }

            else
            {
                algorithm.Sort(data, 0, Count, comparer);
            }

        }



        // This method adds a new element to the existing array.
        // If the internal array is out of capacity, its capacity is first extended to fit the new element.
        public void Add(T element)
        {
            if (Count == Capacity) ExtendData(DEFAULT_CAPACITY);
            data[Count] = element;
            Count++;
        }

        // This method searches for the specified object and returns the zero‐based index of the first occurrence within the entire data structure.
        // This method performs a linear search; therefore, this method is an O(n) runtime complexity operation.
        // If occurrence is not found, then the method returns –1.
        // Note that Equals is the proper method to compare two objects for equality, you must not use operator '=' for this purpose.
        public int IndexOf(T element)
        {
            for (var i = 0; i < Count; i++)
            {
                if (data[i].Equals(element)) return i;
            }
            return -1;
        }

        // This method inserts an element at the specified index.
        // It first validates the index to ensure it is within the allowed range, throwing an IndexOutOfRangeException if it is not.
        // If the array data has reached its capacity, it expands the storage using ExtendData method before proceeding.
        // The method then shifts all elements from the specified index onward one position to the right to create space for the new element.
        // After shifting, the new element is placed at the given index, and the Count is incremented to reflect the updated size.
        // Finally, PrintContents() is called to display the modified state of the data structure.

        public void Insert(int index, T element)
        {

             if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            if (Count == Capacity) 
            {
                ExtendData(DEFAULT_CAPACITY);
            }
                

            for ( int i = Count -1; i >=index; i --)
            {
                data [i +1] = data[i];
                
            }
            data[index] = element;
            Count ++;
            PrintContents();
        }
        
        // This a additional function that I implement my self to understand the insertion of insert method and how the data shifted/move.
        public void PrintContents()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.Write(data[i] + " ");
            }
            Console.WriteLine();
        }
        // Clears all elements in the collection without changing its capacity.
        // The Count is set to 0, and all elements are reset to their default values.
        public void Clear()
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = default(T);
            }
            Count = 0;
        }

        // Reuses IndexOf instead of looping again
        public bool Contains(T item)
        {
            return IndexOf(item) != -1; 
        }

        
       // Removes the first occurrence of the specified item.
       // Shifts elements left and updates the count.
       // Returns true if the item was removed, otherwise false.
       public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index == -1)
            {
                return false;
            }

            RemoveAt(index);
            return true;
        }


        // Removes the element at the specified index and shifts the following elements left.
        // The last element is set to its default value, and the Count is decreased.
       public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
            for (int i = index; i < Count - 1; i++)
            {
                data[i] = data[i + 1];
            }
            data[Count - 1] = default(T);
            Count--;
        }

        // Returns a string representation of the vector. If the vector is empty, it returns "[]".
        // Otherwise, it creates a string with all elements separated by commas and enclosed in square brackets.
        public override string ToString()
        {
        
            if (Count == 0)
            {
                return "[]";
            }
            StringBuilder result = new StringBuilder();
            result.Append("[");

        
            for (int i = 0; i < Count; i++)
            {
                result.Append(data[i]);

                
                if (i < Count - 1)
                {
                    result.Append(", ");
                }
            }

            result.Append("]");
            return result.ToString(); 
        }
    }
}

