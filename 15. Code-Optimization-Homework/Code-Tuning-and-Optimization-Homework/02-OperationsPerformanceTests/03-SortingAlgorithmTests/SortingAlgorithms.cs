namespace _03_SortingAlgorithmTests
{
    using System;

    public static class SortingAlgorithms
    {
        public static void InsertionSort(IComparable[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int j = i + 1;

                while (j > 0 && arr[j - 1].CompareTo(arr[j]) > 0)
                {
                    var temp = arr[j - 1];
                    arr[j - 1] = arr[j];
                    arr[j] = temp;
                    j--;
                }
            }
        }

        public static void SelectionSort(IComparable[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i].CompareTo(arr[j]) > 0)
                    {
                        var tmp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = tmp;
                    }
                }
            }
        }

        public static void Quicksort(IComparable[] elements, int left, int right)
        {
            int i = left, j = right;
            IComparable pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    IComparable tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                Quicksort(elements, left, j);
            }

            if (i < right)
            {
                Quicksort(elements, i, right);
            }
        }
    }
}
