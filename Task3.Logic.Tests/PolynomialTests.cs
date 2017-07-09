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

    }
}
