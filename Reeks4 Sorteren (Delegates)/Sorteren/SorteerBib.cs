using System.Collections.Generic;
using System.Linq;

namespace Sorteren
{
    public class SorteerBib<T>
    {
        public static IList<T> SelectieSorteer(IList<T> lijst)
        {
            return SelectieSorteer(lijst, Comparer<T>.Default);
        }

        public static IList<T> SelectieSorteer(IList<T> lijst, IComparer<T> vergelijker)
        {
            T[] array = lijst.ToArray<T>();
            SelectieSorteer(array, vergelijker);
            return array.ToList<T>();
        }

        public static void SelectieSorteer(T[] array, IComparer<T> vergelijker)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (vergelijker.Compare(array[j], array[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                    T temp = array[i];
                    array[i] = array[minIndex];
                    array[minIndex] = temp;
                }
            }
        }

        public static IList<T> BubbleSorteer(IList<T> lijst)
        {
            return BubbleSorteer(lijst, Comparer<T>.Default);
        }

        public static void BubbleSorteer(T[] array)
        {
            BubbleSorteer(array, Comparer<T>.Default);
        }

        public static IList<T> BubbleSorteer(IList<T> lijst, IComparer<T> vergelijker)
        {
            T[] array = lijst.ToArray<T>();
            BubbleSorteer(array, vergelijker);
            return array.ToList<T>();
        }

        public static void BubbleSorteer(T[] array, IComparer<T> vergelijker)
        {
            for (int i = array.Length - 1; i >= 1; i--)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (vergelijker.Compare(array[j], array[j + 1]) > 0)
                    {
                        T temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

    }
}
