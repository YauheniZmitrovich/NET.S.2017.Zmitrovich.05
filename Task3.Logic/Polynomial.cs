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
            ChechInputCoeffs(coeffs);

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

        public static explicit operator double[] (Polynomial pol)
        {
            return pol?._coeffs;
        }


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



        #endregion


        #region Private

        private void ChechInputCoeffs(double[] coeffs)
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

        private readonly double[] _coeffs;

        #endregion

    }
}
