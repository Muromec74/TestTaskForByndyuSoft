using System;
using System.Numerics;

namespace TestTaskForByndyuSoft
{
    public class Program
    {
        public static void Main()
         {
            var testArray = new int[] { 4, 0, 3, 19, 492, -10, 1 };
            try
            {
                var result = testArray.GetSumTwoMinimals();
                Console.WriteLine(String.Format("Otvet: {0}", result));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

    public static class ArrayExtension
    {
        public static T GetSumTwoMinimals<T>(this T[] array)
            where T : struct, IComparable<T>, INumber<T>
        {
            var listOfValidTypes = new HashSet<Type>() { typeof(int), typeof(double), typeof(decimal), typeof(short), typeof(ushort) }; 
            if (!listOfValidTypes.Contains(typeof(T)))
                throw new ArgumentException("Supported only numeric types!");
            if (array == null || array.Length < 2)
                throw new ArgumentException("The array must contain at least two elements!");
            T min_1 = array[0];
            T min_2 = array[1];
            for (int i = 2; i< array.Length; i++)
            {
                if (array[i]<min_1)
                {
                    if (min_1 < min_2)
                        min_2 = min_1;
                    min_1 = array[i];
                }
                else if (array[i]< min_2)
                {
                    min_2= array[i];
                }
            }
            return min_1 + min_2;
        }
    }

}