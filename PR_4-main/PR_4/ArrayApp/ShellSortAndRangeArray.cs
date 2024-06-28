using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayApp
{
    public class ShellSortAndRangeArray<T> where T : IComparable
    {
        public T[] array
        {
            get; private set;
        }
        public double n { get; set; }
        public ShellSortAndRangeArray(T[] array)
        {
            this.array = array;
            ShellSort();// Вызов метода сортировки
            GetRange();
        }
        /// <summary>
        /// Метод для сортировки массива методом Шелла
        /// </summary>  
        void ShellSort()
        {
            int n = array.Length;
            int gap = n / 2;
            // Уменьшение разрыва на каждой итерации
            while (gap > 0)
            {
                for (int i = gap; i < n; i++)
                {
                    T temp = array[i];
                    int j;
                    for (j = i; j >= gap && array[j - gap].CompareTo(temp) > 0; j -= gap)
                    {
                        array[j] = array[j - gap];
                    }
                    array[j] = temp;
                }
                gap /= 2;
            }
        }
        /// <summary>
        /// Метод для получения диапазона значений в массиве
        /// </summary>
        void GetRange()
        {
            dynamic min = array[0];
            dynamic max = array[0];
            // Перебор всех элементов массива
            foreach (T item in array)
            {
                if (item.CompareTo(min) < 0) min = item;
                if (item.CompareTo(max) > 0) max = item;
            }
            n = max - min;// Возврат диапазона значений
        }
    }
}
