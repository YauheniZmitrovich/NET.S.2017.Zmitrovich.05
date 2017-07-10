using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Logic
{

    /// <summary>
    /// Representation of polynomial. 
    /// </summary>
    public sealed class Polynomial : ICloneable
    {

        private readonly double[] _coeffs;


        #region Polynomial's pivot

        /// <summary>
        /// Constructor takes coefficients from double array. 
        /// </summary>
        /// <param name="coeffs">
        /// Coefficient of a polynomial.
        /// </param>
        public Polynomial(params double[] coeffs)
        {
            CheckInputCoeffs(coeffs);

            _coeffs = new double[coeffs.Length];

            coeffs.CopyTo(_coeffs, 0);
        }

        /// <summary>
        /// Calculate sum of monomials.
        /// </summary>
        /// <returns>
        /// Sum of monomials in double.
        /// </returns>
        /// <param name="num">
        /// Double variable for polynomial.
        /// </param>
        public double CalculateSum(double num)
        {
            double sum = 0;

            for (int i = 0; i < this.Length; i++)
                sum += this[i] * Math.Pow(num, i);

            return sum;
        }

        #endregion


        #region PropertiesIndexerСonverters

        /// <summary>
        /// Polynomical coefficient's number.
        /// </summary>
        public int Length
        {
            get { return _coeffs.Length; }
        }

        /// <summary>
        /// Indexer returns a double coefficient.
        /// </summary>
        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= _coeffs.Length)
                    throw new ArgumentOutOfRangeException();

                return _coeffs[index];
            }
        }

        /// <summary>
        /// Return double array with polynomial's coefficients.
        /// </summary>
        /// <returns>
        /// Double array with polynomial's coefficients.
        /// </returns>
        public double[] GetCoefficients()
        {
            double[] coeffs = new double[_coeffs.Length];

            _coeffs.CopyTo(coeffs, 0);

            return coeffs;
        }

        /// <summary>
        /// Implicit representation of polynomial in double array.
        /// </summary>
        public static implicit operator double[] (Polynomial pol)
        {
            return pol.GetCoefficients();
        }

        #endregion


        #region Static operator methods

        /// <summary>
        /// Adds two double arrays of polynomial's coefficients.
        /// </summary>
        /// <returns>
        /// Object with total coefficients.
        /// </returns>
        public static Polynomial Add(Polynomial pol1, Polynomial pol2)
        {
            return pol1 + pol2;
        }

        /// <summary>
        /// Subtracts two double arrays of polynomial's coefficients.
        /// </summary>
        /// <returns>
        /// Object with total coefficients.
        /// </returns>
        public static Polynomial Subtract(Polynomial pol1, Polynomial pol2)
        {
            return pol1 - pol2;
        }

        /// <summary>
        /// Multiplies two double arrays of polynomial's coefficients.
        /// </summary>
        /// <returns>
        /// Object with total coefficients.
        /// </returns>
        public static Polynomial Multiply(Polynomial pol1, Polynomial pol2)
        {
            return pol1 * pol2;
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

            return GetCoefficients().SequenceEqual(pol.GetCoefficients());
        }

        public override int GetHashCode()
        {
            return _coeffs.GetHashCode();
        }

        public override string ToString()
        {
            string str = "";

            foreach (double c in GetCoefficients())//Is it OK? 
                str += c.ToString() + " ";

            //There are 4 ways:
            //1) use (double[])this 
            //In my opinion it's less readable code.
            //2) public method GetCoefficient()
            //Does java developer write like this every same situation?
            //3) property 
            //Maybe it's the best way. But we already have two almost equal entity.
            //Three is too much.//Or two it's also too much?
            //4) not a word more

            //OK,property. Why not?
            //As I understood,since we returns copy of our object(double[]) 
            // => we can't use property. 
            //So if we return a reference then we can use it.
            //
            //Summary:
            //If we have a ref type (example:array) as part of our class :
            //property - for reference returning.
            //method - for object's copy returning
            //
            //Where do I have mistakes in my thoughts?
            //Thank you for your attention.


            return str;
        }

        #endregion


        #region ICloneable implementation

        object ICloneable.Clone()
        {
            return new Polynomial(GetCoefficients());
        }

        #endregion


        #region OperatorsOverloading


        #region Operators == and !=

        public static bool operator ==(Polynomial pol1, Polynomial pol2)
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

            return new Polynomial(Subtr(ob1, ob2));
        }

        public static Polynomial operator -(double[] ob1, Polynomial ob2)
        {
            CheckInputArrays(ob1, ob2);

            return new Polynomial(Subtr(ob1, ob2));
        }

        public static Polynomial operator -(Polynomial ob1, double[] ob2)
        {
            CheckInputArrays(ob1, ob2);

            return new Polynomial(Subtr(ob1, ob2));
        }

        #endregion

        #region Operator*

        public static Polynomial operator *(Polynomial ob1, Polynomial ob2)
        {
            CheckInputArrays(ob1, ob2);

            return new Polynomial(Mult(ob1, ob2));
        }

        public static Polynomial operator *(double[] ob1, Polynomial ob2)
        {
            CheckInputArrays(ob1, ob2);

            return new Polynomial(Mult(ob1, ob2));
        }

        public static Polynomial operator *(Polynomial ob1, double[] ob2)
        {
            CheckInputArrays(ob1, ob2);

            return new Polynomial(Mult(ob1, ob2));
        }

        #endregion


        #endregion


        #region Private


        #region Checkers

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

        private static void CheckInputArrays(double[] arr1, double[] arr2)
        {
            if (arr1 == null || arr2 == null)
                throw new ArgumentNullException();
        }

        private static void CheckInputArrays(double[] arr1)
        {
            if (arr1 == null)
                throw new ArgumentNullException();
        }

        #endregion

        #region OperatorFuncs

        private static double[] Sum(double[] arr1, double[] arr2)
        {
            double[] longest = (arr1.Length > arr2.Length) ? arr1 : arr2;
            double[] shortest = (longest == arr1) ? arr2 : arr1;

            double[] resArr = new double[longest.Length];
            longest.CopyTo(resArr, 0);

            for (int i = 0; i < shortest.Length; i++)
                resArr[i] += shortest[i];

            return resArr;
        }

        private static double[] Subtr(double[] arr1, double[] arr2)
        {
            double[] longest = (arr1.Length > arr2.Length) ? arr1 : arr2;

            double[] resArr = new double[longest.Length];
            arr1.CopyTo(resArr, 0);

            for (int i = 0; i < arr2.Length; i++)
                resArr[i] -= arr2[i];

            return resArr;
        }

        private static double[] Mult(double[] arr1, double[] arr2)
        {
            double[] res = new double[arr1.Length + arr2.Length - 1];

            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < arr2.Length; j++)
                {
                    res[i + j] += arr1[i] * arr2[j];
                }
            }

            return res;
        }

        #endregion


        #endregion

    }
}
