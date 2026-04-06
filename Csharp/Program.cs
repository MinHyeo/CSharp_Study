using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace CSharp_Study
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. List
            List<int> list = new List<int>();
            list.Add(1);                // 삽입
            int listValue = list[0];    // 접근
            list.Remove(0);             // 삭제

            // 2. Dictionary
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            dictionary["one"] = 1;                      // 삽입
            dictionary["two"] = 2;                      
            int dictionaryValue = dictionary["one"];    // 접근
            dictionary.Remove("one");                   // 삭제

            // 3. Queue
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);                   // 삽입
            queue.Enqueue(2);
            int queueValue = queue.Peek();      // 맨 앞의 요소 반환
            int queueValue2 = queue.Dequeue();  // 삭제

            // 4. Stack
            Stack<int> stack = new Stack<int>();
            stack.Push(1);                  // 삽입
            stack.Push(2);
            int stackValue = stack.Pop();   // 삭제

            // 5. HashSet
            HashSet<int> hasSet = new HashSet<int>();
            hasSet.Add(1);                      // 삽입
            hasSet.Add(2);
            bool contains = hasSet.Contains(1); // 탐색
            hasSet.Remove(2);                   // 삭제

            // 6. LinkedList
            LinkedList<int> linkedList = new LinkedList<int>();
            linkedList.AddLast(1);                      // 삽입
            linkedList.AddLast(2);
            int firstValue = linkedList.First.Value;    // 맨 앞 요소 접근
            linkedList.Remove(1);                       // 삭제

            // 7. SortedList
            SortedList<string, int> sortedList = new SortedList<string, int>();
            sortedList.Add("one", 1);                   // 삽입
            sortedList.Add("two", 2);
            int sortedListValue = sortedList["one"];    // 접근
            sortedList.Remove("two");                   // 삭제

            // 8. SortedDictionary
            SortedDictionary<string, int> sortedDictionary = new SortedDictionary<string, int>();
            sortedDictionary.Add("one", 1);                         // 삽입
            sortedDictionary.Add("two", 2);
            int sortedDictionaryValue = sortedDictionary["one"];    // 접근
            sortedDictionary.Remove("two");                         // 삭제
        }
    }
}
