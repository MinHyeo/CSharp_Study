using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;

namespace CSharp_Study
{
    class Algorithm 
    {
        public void PrintArray(int[] array)
        {
            int len = array.Length;
            for(int i =0; i < len; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        private void Swap(int[] array, int i , int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        // 1. 선택 정렬(Selection Sort)
        public void SelectionSort(int[] array)
        {
            // 배열 깊은 복사
            // 참조에서 참조로 복사되어서 박싱/언박싱이 발생하지 않는다.
            int[] newArray = (int[])array.Clone();

            for(int i = 0; i < newArray.Length - 1; i++)
            {
                int tmp = i;
                for(int j = i + 1; j < newArray.Length; j++)
                {
                    if (newArray[tmp] >= newArray[j])
                        tmp = j;
                }
                Swap(newArray, i, tmp);
            }

            Console.WriteLine("선택 정렬");
            PrintArray(newArray);
        }

        // 2. 삽입 정렬
        public void InsertionSort(int[] array)
        {
            // 배열 깊은 복사
            int[] newArray = (int[])array.Clone();

            for (int i = 0; i < newArray.Length; i++)
            {
                int key = newArray[i];
                int j = i - 1;
                while(j >= 0 && key < newArray[j])
                {
                    Swap(newArray, j, j + 1);
                    j--;
                }
                newArray[j + 1] = key;
            }

            Console.WriteLine("삽입 정렬");
            PrintArray(newArray);
        }

        // 3. 버블 정렬
        public void BubbleSort(int[] array)
        {
            int[] newArray = (int[])array.Clone();

            for(int i = 0; i < newArray.Length - 1; i++)
            {
                for(int j = 1; j < newArray.Length - i; j++)
                {
                    if (newArray[j - 1] > newArray[j])
                    {
                        Swap(newArray, j - 1, j);
                    }
                }
            }

            Console.WriteLine("삽입 정렬");
            PrintArray(newArray);
        }

        private void Merge(int[] array, int s, int m, int e)
        {
            int n1 = m - s + 1;
            int n2 = e - m;

            int[] startArray = new int[n1];
            int[] endArray = new int[n2];

            Array.Copy(array, s, startArray, 0, n1);
            Array.Copy(array, m + 1, endArray, 0, n2);

            int i = 0, j = 0;
            int k = s;

            while (i < n1 && j < n2)
            {
                if (startArray[i] <= endArray[j])
                {
                    array[k] = startArray[i];
                    i++;
                }
                else
                {
                    array[k] = endArray[j];
                    j++;
                }
                k++;
            }

            while (i < n1) array[k++] = startArray[i++];
            while (j < n2) array[k++] = endArray[j++];
        }

        // 4. 합병 정렬(Merge Sort)
        public void MergeSort(int[] array, int s, int e)
        {
            if (s < e)
            {
                int mid = s + (e - s) / 2;

                MergeSort(array, s, mid);
                MergeSort(array, mid + 1, e);

                Merge(array, s, mid, e);
            }
        }

        // 5. 퀵 정렬
        public void QuickSort(int[] newArray, int s, int e)
        {
            //int[] newArray = (int[])array.Clone();

            int pivot = newArray[s];
            int bs = s;
            int be = e;
            while (s < e)
            {
                while (pivot <= newArray[e] && s < e)
                    e--;
                if (s > e)
                    break;

                while (pivot >= newArray[s] && s < e)
                    s++;
                if (s > e)
                    break;

                Swap(newArray, s, e);
            }
            Swap(newArray, bs, s);
            if (bs < s)
                QuickSort(newArray, bs, s - 1);
            if (be > e)
                QuickSort(newArray, s + 1, be);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // 정렬되지 않은 배열
            int[] array = new int[] { 5, 4, 10, 7, 9, 1, 3, 6 };
            Algorithm algorithm = new Algorithm();

            algorithm.SelectionSort(array);
            algorithm.InsertionSort(array);
            algorithm.BubbleSort(array);

            algorithm.MergeSort(array, 0, array.Length - 1);
            // 재귀 함수라서 여러 발생하는 문제 때문에 여기서 작성
            Console.WriteLine("합병 정렬");
            algorithm.PrintArray(array);

            array = new int[] { 5, 4, 10, 7, 9, 1, 3, 6 };
            algorithm.QuickSort(array, 0, array.Length - 1);
            // 재귀 함수라서 여러 발생하는 문제 때문에 여기서 작성
            Console.WriteLine("퀵 정렬");
            algorithm.PrintArray(array);
        }
    }
}
