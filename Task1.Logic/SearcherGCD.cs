using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Task1.Logic
{
    /// <summary>
    /// The class helps to compute the greatest common divisor (GCD) of numbers.
    /// </summary>
    public static class SearcherGCD
    {

        #region ClassicalSearchingByEuclid

        /// <summary>
        /// Computes GCD of two numbers by classical Euclidian algorithm.
        /// </summary>
        /// <returns>
        /// Tuple(gcd, time) where time is the algorythm running time.
        /// </returns>
        public static (int gcd, long time) SearchByEuclid(int a, int b)
        {
            var sw = Stopwatch.StartNew();

            return (_SearchByEuclid(a, b), sw.ElapsedTicks);
        }

        /// <summary>
        /// Computes GCD of three numbers by classical Euclidian algorithm.
        /// </summary>
        /// <returns>
        /// Tuple(gcd, time) where time is the algorythm running time.
        /// </returns>
        public static (int gcd, long time) SearchByEuclid(int a, int b, int c)
        {
            var sw = Stopwatch.StartNew();

            int gcd = _SearchByEuclid(a, b);
            gcd = _SearchByEuclid(gcd, c);

            return (gcd, sw.ElapsedTicks);
        }

        /// <summary>
        /// Computes GCD of some numbers by classical Euclidian algorithm.
        /// </summary>
        /// <returns>
        /// Tuple(gcd, time) where time is the algorythm running time.
        /// </returns>
        public static (int gcd, long time) SearchByEuclid(params int[] nums)
        {
            CheckInputArray(nums);

            var sw = Stopwatch.StartNew();


            int gcd = _SearchByEuclid(nums[0], nums[1]);

            for (int i = 2; i < nums.Length; i++)
            {
                gcd = _SearchByEuclid(gcd, nums[i]);
            }

            return (gcd, sw.ElapsedTicks);
        }

        #endregion


        #region SearchingByStein

        /// <summary>
        /// Computes GCD of two numbers by Stein's algorithm.
        /// </summary>
        /// <returns>
        /// Tuple(gcd, time) where time is the algorythm running time.
        /// </returns>
        public static (int gcd, long time) SearchByStein(int a, int b)
        {
            var sw = Stopwatch.StartNew();

            return (_SearchByStein(a, b), sw.ElapsedTicks);
        }

        /// <summary>
        /// Computes GCD of three numbers by Stein's algorithm.
        /// </summary>
        /// <returns>
        /// Tuple(gcd, time) where time is the algorythm running time.
        /// </returns>
        public static (int gcd, long time) SearchByStein(int a, int b, int c)
        {
            var sw = Stopwatch.StartNew();

            int gcd = _SearchByStein(a, b);
            gcd = _SearchByStein(gcd, c);

            return (gcd, sw.ElapsedTicks);
        }

        /// <summary>
        /// Computes GCD of some numbers by Stein's algorithm.
        /// </summary>
        /// <returns>
        /// Tuple(gcd, time) where time is the algorythm running time.
        /// </returns>
        public static (int gcd, long time) SearchByStein(params int[] nums)
        {
            CheckInputArray(nums);

            var sw = Stopwatch.StartNew();


            int gcd = _SearchByStein(nums[0], nums[1]);

            for (int i = 2; i < nums.Length; i++)
            {
                gcd = _SearchByStein(gcd, nums[i]);
            }

            return (gcd, sw.ElapsedTicks);
        }

        #endregion


        #region PrivateFunctions

        private static int _SearchByEuclid(int a, int b)
        {
            int temp;
            while (a != 0)
            {
                temp = a;
                a = b % a;
                b = temp;
            }

            return (Math.Abs(b));
        }

        private static int _SearchByStein(int a, int b)
        {
            int? gcd = null;

            if (a == 0)
                gcd = b;
            else if (b == 0)
                gcd = a;
            else if (a == b)
                gcd = a;
            else if (a == 1 || b == 1)
                gcd = 1;

            if (gcd != null)
                return Math.Abs((int)gcd);

            if ((a & 1) == 0)
                gcd = ((b & 1) == 0) ? _SearchByStein(a >> 1, b >> 1) << 1
                    : _SearchByStein(a >> 1, b);
            else
                gcd = ((b & 1) == 0) ? _SearchByStein(a, b >> 1)
                    : _SearchByStein(b, a > b ? a - b : b - a);

            return Math.Abs((int)gcd);
        }

        private static void CheckInputArray(int[] nums)
        {
            if (nums == null)
                throw new ArgumentNullException();

            if (nums.Length < 2)
                throw new ArgumentException();
        }

        #endregion

    }
}
