using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NoSenseTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //Please input : "12, 123, 14, 23, 17, 16"
            var line = Console.ReadLine();
            var items = line.Split(',').Select(int.Parse).ToArray();

            Console.WriteLine("0 = Found , -1 = Not Found \n");
            Console.WriteLine("Searching for 23 : " + items.ThisDoesntMakeAnySense(x => x == 23, () => -1));
            Console.WriteLine("Searching for 100 : " + items.ThisDoesntMakeAnySense(x => x == 100, () => -1));

            int[] emptyArray = null;
            try
            {
                emptyArray.ThisDoesntMakeAnySense(x => x == 3, () => -1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Trying to throw an exception : " + ex.Message);
            }

            Console.ReadKey();
        }
    }

    static class IEnumerableExtensions
    {
        public static T ThisDoesntMakeAnySense<T>(this IEnumerable<T> items,Predicate<T> predicate, Func<T> func)
        {
            if (items == null || predicate == null || func == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var item in items)
            {
                if (predicate(item))
                {
                    return default(T);
                }
            }
            return func();
        }
    }
}
