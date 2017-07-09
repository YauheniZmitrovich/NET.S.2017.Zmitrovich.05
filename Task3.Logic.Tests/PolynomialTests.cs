using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task3.Logic.Tests
{

    [TestFixture]
    public class PolynomialTests
    {

        #region ConstructorTests

        [Test]
        [Category("Polynomial")]
        public void Polynomial_NullArray_ThrowsArgumentNullException()
        {
            var ex = Assert.Catch<ArgumentNullException>(() => new Polynomial(null));
            StringAssert.Contains("Value cannot be null.", ex.Message);
        }

        [Test]
        [Category("Polynomial")]
        public void Polynomial_EmptyArray_ThrowsArgumentException()
        {
            double[] arr = { };

            var ex = Assert.Catch<ArgumentException>(() => new Polynomial(arr));
            StringAssert.Contains("Value does not fall within the expected range.", ex.Message);
        }

        [Test]
        [Category("Polynomial")]
        public void Polynomial_ArrayWithNullMembers_ThrowsArgumentException()
        {
            double[] arr = { 5, 0, 2, 0 };

            var ex = Assert.Catch<ArgumentException>(() => new Polynomial(arr));
            StringAssert.Contains("Value does not fall within the expected range.", ex.Message);
        }

        #endregion


        #region CalculatingTests
        [Test]
        [Category("Polynomial")]
        public void CalculateSum_5CoefficientsAndNum2_Returns129()
        {
            double[] coeffs = { 1.0, 2.0, 3.0, 4.0, 5.0 };
            Polynomial pol = new Polynomial(coeffs);
            double expectedResult = 129;   //5*2^4 + 4*2^3 + 3*2^2 + 2*2^1 + 1*2^0 = 129

            double res = pol.CalculateSum(2);

            Assert.AreEqual(expectedResult, res);
        }
        #endregion


        #region IndexerTests

        [Test]
        [Category("Polynomial")]
        public void Indexer_Pass5_Returns6thCoefficient()
        {
            double[] arr = { 10, 11, 12, 13, 14, 15 };
            Polynomial pol = new Polynomial(arr);
            double expetedRes = 15.0;

            double res = pol[5];

            Assert.AreEqual(expetedRes, res);
        }

        [TestCase(9)]
        [TestCase(-10)]
        [TestCase(0)]
        [Category("Polynomial")]
        public void Indexer_IndexOutOfRange_ThrowsIndexOutOfRangeExceptions(int i)
        {
            double[] arr = { 10, 11, 12, 13, 14, 15 };
            Polynomial pol = new Polynomial(arr);

            double res;

            Assert.Catch<IndexOutOfRangeException>(() => res = pol[i]);
        }

        #endregion


        #region EqualsTests

        [Test]
        [Category("Polynomial")]
        public void EqualsObj_RefEquals_RetrunsTrue()
        {
            double[] arr = { 12.34, 12.1 };
            Polynomial ob1 = new Polynomial(arr);
            object ob2 = ob1;

            Assert.True(ob1.Equals(ob2));
        }

        [Test]
        [Category("Polynomial")]
        public void EqualsPol_PolEquals_RetrunsTrue()
        {
            double[] arr = { 12.34, 12.1 };
            Polynomial ob1 = new Polynomial(arr);
            Polynomial ob2 = new Polynomial(arr);

            Assert.True(ob1.Equals(ob2));
        }

        #endregion


        #region Operator+ Tests

        [Test]
        [CategoryAttribute("Polynomial")]
        public void OperatorPlus_TwoPolynomial_ReturnsPolynomial()
        {
            double[] arr1 = { 12.5, 13.0, 13.5 };
            double[] arr2 = { 7.5, 7.0 };
            double[] expectedArr = { 20, 20, 13.5 };

            Polynomial pol1 = new Polynomial(arr1);
            Polynomial pol2 = new Polynomial(arr2);
            Polynomial expectedPol = new Polynomial(expectedArr);

            Polynomial resPol = pol1 + pol2;

            Assert.True(expectedPol == resPol);
        }

        [Test]
        [CategoryAttribute("Polynomial")]
        public void OperatorPlus_NullArray_ThrowsArgumentNullException()
        {
            double[] arr1 = { 12.5, 13.0, 13.5 };
            double[] arr2 = null;
            double[] res;
            Polynomial pol1 = new Polynomial(arr1);

            Assert.Catch<ArgumentNullException>(() => res = pol1 + arr2);
        }

        [Test]
        [Ignore("TODO")]
        [CategoryAttribute("Polynomial")]
        public void OperatorPlus_Overflow_ThrowsOverflowException()
        {
            double[] arr1 = { double.MaxValue, 13.0, 13.5 };
            double[] arr2 = { 10, 13.0, 13.5 };
            double[] res;
            Polynomial pol1 = new Polynomial(arr1);
            Polynomial pol2 = new Polynomial(arr2);

            Assert.Catch<OverflowException>(() => res = pol1 + pol2);
        }
        #endregion


        #region Operator- Tests

        [Test]
        [CategoryAttribute("Polynomial")]
        public void OperatorMinus_TwoPolynomial_ReturnsPolynomial()
        {
            double[] arr1 = { 7.5, 7.0 };
            double[] arr2 = { 12.5, 13.0, 13.5 };
            double[] expectedArr = { -5, -6, -13.5 };

            Polynomial pol1 = new Polynomial(arr1);
            Polynomial pol2 = new Polynomial(arr2);
            Polynomial expectedPol = new Polynomial(expectedArr);

            Polynomial resPol = pol1 - pol2;

            Assert.True(expectedPol == resPol);
        }

        [Test]
        [CategoryAttribute("Polynomial")]
        public void OperatorMinus_NullArray_ThrowsArgumentNullException()
        {
            double[] arr1 = { 12.5, 13.0, 13.5 };
            double[] arr2 = null;
            double[] res;
            Polynomial pol1 = new Polynomial(arr1);

            Assert.Catch<ArgumentNullException>(() => res = pol1 - arr2);
        }

        #endregion
    }
}
