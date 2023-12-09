using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Design_Pattern.Patterns
{
    public interface ISort
    {
        public void Sort(int[] collection, int n);
        public void Show(int[] collection);
    }
    public class BubbleSort : ISort
    {
        public void Show(int[] collection)
        {
            System.Console.WriteLine("Using BubbleSort:");
            foreach (var item in collection)
            {
                System.Console.Write($"{item}\t");
            }
            System.Console.WriteLine("");
        }

        public void Sort(int[] collection, int n)
        {
            int i, j, temp;
            bool swapped;
            for (i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (j = 0; j < n - i - 1; j++)
                {
                    if (collection[j] > collection[j + 1])
                    {
                        temp = collection[j];
                        collection[j] = collection[j + 1];
                        collection[j + 1] = temp;
                        swapped = true;
                    }
                }
                if (swapped == false)
                    break;
            }
        }
    }

    public class SelectionSort : ISort
    {
        public void Show(int[] collection)
        {
            System.Console.WriteLine("Using SelectionSort:");
            foreach (var item in collection)
            {
                System.Console.Write($"{item}\t");
            }
            System.Console.WriteLine("");
        }

        public void Sort(int[] collection, int n)
        {
            for (int i = 0; i < n - 1; i++)
            {
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (collection[j] < collection[min_idx])
                        min_idx = j;

                int temp = collection[min_idx];
                collection[min_idx] = collection[i];
                collection[i] = temp;
            }
        }
    }

    public class Context
    {
        private ISort _sort;
        public Context(ISort sort)
        {
            _sort = sort;
        }
        public void SetSort(ISort sort)
        {
            _sort = sort;
        }
        public void Show(int[] collection)
        {
            _sort.Show(collection);
        }
        public void Sort(int[] collection, int n)
        {
            _sort.Sort(collection, n);
        }
    }
}