using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Logic
{
    public sealed class Polynomial
    {

        public Polynomial(params double[] coeffs)
        {
            CheckInputCoeffs(coeffs);

            _coeffs = new double[coeffs.Length];

            coeffs.CopyTo(_coeffs, 0);
        }

        public double CalculateSum(double num)
        {
            double sum = 0;

            for (int i = 0; i < _coeffs.Length; i++)
                sum += _coeffs[i] * Math.Pow(num, i);

            return sum;
        }


        #region PropertiesIndexatorСonverter

        public int Length
        {
            get { return _coeffs.Length; }
        }

        public double this[int index]
        {
            get
            {
                if (index < 1 || index >= _coeffs.Length)
                    throw new IndexOutOfRangeException();

                return _coeffs[index];
            }
        }

        public static implicit operator double[] (Polynomial pol)
        {
            return pol?._coeffs;
        }

        #endregion


        #region ObjectMethodsOverloading

        public override bool Equals(object obj)
        {
            return ReferenceEquals(obj, this);
        }

        public bool Equals(Polynomial pol)
        {
            if (pol?.Length != Length)
                return false;

            return _coeffs.SequenceEqual((double[])pol);
        }

        public override int GetHashCode()
        {
            return _coeffs.GetHashCode();
        }

        public override string ToString()
        {
            string str = "";

            foreach (double c in _coeffs)
                str += c.ToString() + " ";

            return str;
        }

        #endregion


        #region OperatorsOverloading


        #region Operators == and !=

        public static bool operator == (Polynomial pol1, Polynomial pol2)
        {
            return pol1.Equals(pol2);
        }

        public static bool operator !=(Polynomial pol1, Polynomial pol2)
        {
            return !(pol1 == pol2);
        }

        #endregion

        #region Operator+

        public static Polynomial operator +(Polynomial ob1, Polynomial ob2)
        {
            CheckInputArrays(ob1, ob2);

            return new Polynomial(Sum(ob1, ob2));
        }

        public static Polynomial operator +(double[] ob1, Polynomial ob2)
        {
            CheckInputArrays(ob1, ob2);

            return new Polynomial(Sum(ob1, ob2));
        }

        public static Polynomial operator +(Polynomial ob1, double[] ob2)
        {
            CheckInputArrays(ob1, ob2);

            return new Polynomial(Sum(ob1, ob2));
        }

        #endregion

        #region Operator-

        public static Polynomial operator -(Polynomial ob1, Polynomial ob2)
        {
            CheckInputArrays(ob1, ob2);

            return new Polynomial(Subtract(ob1, ob2));
        }

        public static Polynomial operator -(double[] ob1, Polynomial ob2)
        {
            CheckInputArrays(ob1, ob2);

            return new Polynomial(Subtract(ob1, ob2));
        }

        public static Polynomial operator -(Polynomial ob1, double[] ob2)
        {
            CheckInputArrays(ob1, ob2);

            return new Polynomial(Subtract(ob1, ob2));
        }

        #endregion

        #endregion


        #region Private

        private static void CheckInputCoeffs(double[] coeffs)
        {
            if (coeffs == null)
                throw new ArgumentNullException();
            if (coeffs.Length == 0)
                throw new ArgumentException();

            foreach (double d in coeffs)
            {
                if (d == 0)
                    throw new ArgumentException();
            }
        }

        private static void CheckInputArrays(double[] arr1,double[] arr2)
        {
            if (arr1 == null || arr2 == null)
                throw new ArgumentNullException();
        }

        private static double[] Sum(double[] arr1, double[] arr2)
        {
            double[] longest = (arr1.Length > arr2.Length) ? arr1 : arr2;
            double[] shortest = (longest == arr1) ? arr2 : arr1;

            double[] resArr = new double[longest.Length];
            longest.CopyTo(resArr, 0);

            checked
            {
                for (int i = 0; i < shortest.Length; i++)
                    resArr[i] += shortest[i];
            }

            return resArr;
        }

        private static double[] Subtract(double[] arr1, double[] arr2)
        {
            double[] longest = (arr1.Length > arr2.Length) ? arr1 : arr2;

            double[] resArr = new double[longest.Length];
            arr1.CopyTo(resArr, 0);

            checked
            {
                for (int i = 0; i < arr2.Length; i++)
                    resArr[i] -= arr2[i];
            }

            return resArr;
        }

        private readonly double[] _coeffs;

  

        #endregion

    }
}
