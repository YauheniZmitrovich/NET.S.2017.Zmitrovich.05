using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Task1.Logic
{
    /// <summary>
    /// The class helps to compute the Greatest Common Divisor (GCD) of numbers.
    /// </summary>
    public static class SearcherGCD
    {

        #region ClassicalSearchingByEuclid

        /// <summary>
        /// Computes GCD of two numbers by classical Euclidian algorithm.
        /// </summary>
        /// <returns>
        /// GCD of two number in long representation.
        /// </returns>
        public static long SearchByEuclid(long a, long b)
        {
            long temp;
            while (a != 0)
            {
                temp = a;
                a = b % a;
                b = temp;
            }

            return (Math.Abs(b));
        }

        /// <summary>
        /// Computes GCD of two numbers by classical Euclidian algorithm.
        /// Also returns the algorythm running time.
        /// </summary>
        /// <returns>
        /// GCD of two number in long representation.
        /// </returns>
        /// <param name="time"> The algorythm running time in long representation. </param>
        public static long SearchByEuclid(out long time, long a, long b)
        {
            var sw = Stopwatch.StartNew();

            long gcd = SearchByEuclid(a, b);

            time = sw.ElapsedTicks;


            return gcd;
        }

        /// <summary>
        /// Computes GCD of three numbers by classical Euclidian algorithm.
        /// </summary>
        /// <returns>
        /// GCD of two number in long representation.
        /// </returns>
        /// <param name="time"> The algorythm running time in long representation. </param>
        public static long SearchByEuclid(out long time, long a, long b, long c)
        {
            var sw = Stopwatch.StartNew();

            long gcd = SearchByEuclid(a, b);
            gcd = SearchByEuclid(gcd, c);

            time = sw.ElapsedTicks;


            return gcd;
        }

        /// <summary>
        /// Computes GCD of some numbers by classical Euclidian algorithm.
        /// </summary>
        /// <returns>
        /// GCD of two number in long representation.
        /// </returns>
        /// <param name="time"> The algorythm running time in long representation. </param>
        public static long SearchByEuclid(out long time, params long[] nums)
        {
            CheckInputArray(nums);

            var sw = Stopwatch.StartNew();

            long gcd = SearchByEuclid(nums[0], nums[1]);

            for (int i = 2; i < nums.Length; i++)
            {
                gcd = SearchByEuclid(gcd, nums[i]);
            }

            time = sw.ElapsedTicks;

            return gcd;
        }

        #endregion


        #region SearchingByStein

        /// <summary>
        /// Computes GCD of two numbers by Stein's algorithm.
        /// </summary>
        /// <returns> GCD of two number in long representation. </returns>
        public static long SearchByStein(long a, long b)
        {
            long? gcd = null;

            if (a == 0)
                gcd = b;
            else if (b == 0)
                gcd = a;
            else if (a == b)
                gcd = a;
            else if (a == 1 || b == 1)
                gcd = 1;

            if (gcd != null)
                return Math.Abs((long)gcd);

            if ((a & 1) == 0)
                gcd = ((b & 1) == 0) ? SearchByStein(a >> 1, b >> 1) << 1
                    : SearchByStein(a >> 1, b);
            else
                gcd = ((b & 1) == 0) ? SearchByStein(a, b >> 1)
                    : SearchByStein(b, a > b ? a - b : b - a);

            return Math.Abs((long)gcd);
        }

        /// <summary>
        /// Computes GCD of two numbers by Stein's algorithm.
        /// Also returns the algorythm running time.
        /// </summary>
        /// <returns> GCD of two number in long representation. </returns>
        /// <param name="time"> The algorythm running time in long representation. </param>
        public static long SearchByStein(out long time, long a, long b)
        {
            var sw = Stopwatch.StartNew();

            long gcd = SearchByStein(a, b);

            time = sw.ElapsedTicks;


            return gcd;
        }

        /// <summary>
        /// Computes GCD of three numbers by Stein's algorithm.
        /// </summary>
        /// <returns> GCD of two number in long representation. </returns>
        /// <param name="time"> The algorythm running time in long representation. </param>
        public static long SearchByStein(out long time, long a, long b, long c)
        {
            var sw = Stopwatch.StartNew();

            long gcd = SearchByStein(a, b);
            gcd = SearchByStein(gcd, c);

            time = sw.ElapsedTicks;

            return gcd;
        }

        /// <summary>
        /// Computes GCD of some numbers by Stein's algorithm.
        /// </summary>
        /// <returns> GCD of two number in long representation. </returns>
        /// <param name="time"> The algorythm running time in long representation. </param>
        public static long SearchByStein(out long time, params long[] nums)
        {
            CheckInputArray(nums);

            var sw = Stopwatch.StartNew();


            long gcd = SearchByStein(nums[0], nums[1]);

            for (int i = 2; i < nums.Length; i++)
            {
                gcd = SearchByStein(gcd, nums[i]);
            }


            time = sw.ElapsedTicks;

            return gcd;
        }

        #endregion


        #region PrivateFunctions

        private static void CheckInputArray(long[] nums)
        {
            if (nums == null)
                throw new ArgumentNullException();

            if (nums.Length < 2)
                throw new ArgumentException();
        }

        #endregion

    }
}
