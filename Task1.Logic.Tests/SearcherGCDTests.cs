using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static Task1.Logic.SearcherGCD;

namespace Task1.Logic.Tests
{
    [TestFixture]
    public class SearcherGCDTests
    {

        #region Testing_SearchByEuclid

        #region Testing_SearchByEuclid(int,int)

        [TestCase(18, -12, 6)]
        [TestCase(1000, 975, 25)]
        [TestCase(24, 24, 24)]
        [TestCase(1, 0, 1)]
        [TestCase(0, 0, 0)]
        [Category("Classical Euclidean algorithm")]
        public void SearchByEuclid_LeftNumGreaterThenRight_ReturnsGCD(int a, int b, int expectedRes)
        {
            //act
            var tuple = SearchByEuclid(a, b);

            //assert 
            Assert.AreEqual(expectedRes, tuple.gcd);
        }

        [TestCase(975, 1000, 25)]
        [TestCase(-18, 12, 6)]
        [TestCase(0, 0, 0)]
        [TestCase(0, 1, 1)]
        [Category("Classical Euclidean algorithm")]
        public void SearchByEuclid_RightNumGreaterThenLeft_ReturnsGCD(int a, int b, int expectedRes)
        {
            //act
            var tuple = SearchByEuclid(a, b);

            //assert 
            Assert.AreEqual(expectedRes, tuple.gcd);
        }

        #endregion


        #region Testing_SearchByEuclid(int,int,int)

        [TestCase(18, -12, 24, 6)]
        [TestCase(1000, 975, 250, 25)]
        [TestCase(24, 24, -24, 24)]
        [TestCase(1, 0, 0, 1)]
        [TestCase(0, 0, 0, 0)]
        [Category("Classical Euclidean algorithm")]
        public void SearchByEuclid_ThreeParams_ReturnsGCD(int a, int b, int c, int expectedRes)
        {
            //act
            var tuple = SearchByEuclid(a, b, c);

            //assert 
            Assert.AreEqual(expectedRes, tuple.gcd);
        }

        #endregion


        #region Testing_SearchByEuclid(params int[])

        [TestCase(6, 18, -12, 24, 36)]
        [TestCase(25, 1000, 975, 250, -1250, 250, -625)]
        [TestCase(24, 24, -24, 24, 24, 24, -24)]
        [TestCase(1, 0, 0, 0, 0, 0, 0, 1)]
        [TestCase(0, 0, 0, 0, 0)]
        [Category("Classical Euclidean algorithm")]
        public void SearchByEuclid_GoodNums_ReturnsGCD(int expectedRes, params int[] nums)
        {
            //act
            var tuple = SearchByEuclid(nums);

            //assert 
            Assert.AreEqual(expectedRes, tuple.gcd);
        }


        [Test]
        [Category("Classical Euclidean algorithm")]
        public void SearchByEuclid_NullArray_ThrowsArgumentNullExceptions()
        {
            var ex = Assert.Catch<ArgumentNullException>(() => SearchByEuclid(null));
            StringAssert.Contains("Value cannot be null.", ex.Message);
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [Category("Classical Euclidean algorithm")]
        public void SearchByEuclid_ArrayLengthLessThanTwo_ThrowsArgumentExceptions(params int[] nums)
        {
            var ex = Assert.Catch<ArgumentException>(() => SearchByEuclid(nums));
            StringAssert.Contains("Value does not fall within the expected range.", ex.Message);
        }

        #endregion

        #endregion


        #region Testing_SearchByStein

        #region Testing_SearchByStein(int,int)

        [TestCase(18, -12, 6)]
        [TestCase(1000, 975, 25)]
        [TestCase(24, 24, 24)]
        [TestCase(1, 0, 1)]
        [TestCase(0, 0, 0)]
        [Category("Stein's algorithm")]
        public void SearchByStein_LeftNumGreaterThenRight_ReturnsGCD(int a, int b, int expectedRes)
        {
            //act
            var tuple = SearchByStein(a, b);

            //assert 
            Assert.AreEqual(expectedRes, tuple.gcd);
        }

        [TestCase(975, 1000, 25)]
        [TestCase(-18, 12, 6)]
        [TestCase(0, 0, 0)]
        [TestCase(0, 1, 1)]
        [Category("Stein's algorithm")]
        public void SearchByStein_RightNumGreaterThenLeft_ReturnsGCD(int a, int b, int expectedRes)
        {
            //act
            var tuple = SearchByStein(a, b);

            //assert 
            Assert.AreEqual(expectedRes, tuple.gcd);
        }

        #endregion


        #region Testing_SearchByStein(int,int,int)

        [TestCase(18, -12, 24, 6)]
        [TestCase(1000, 975, 250, 25)]
        [TestCase(24, 24, -24, 24)]
        [TestCase(1, 0, 0, 1)]
        [TestCase(0, 0, 0, 0)]
        [Category("Stein's algorithm")]
        public void SearchByStein_ThreeParams_ReturnsGCD(int a, int b, int c, int expectedRes)
        {
            //act
            var tuple = SearchByStein(a, b, c);

            //assert 
            Assert.AreEqual(expectedRes, tuple.gcd);
        }

        #endregion


        #region Testing_SearchByStein(params int[])

        [TestCase(6, 18, -12, 24, 36)]
        [TestCase(25, 1000, 975, 250, -1250, 250, -625)]
        [TestCase(24, 24, -24, 24, 24, 24, -24)]
        [TestCase(1, 0, 0, 0, 0, 0, 0, 1)]
        [TestCase(0, 0, 0, 0, 0)]
        [Category("Stein's algorithm")]
        public void SearchByStein_GoodNums_ReturnsGCD(int expectedRes, params int[] nums)
        {
            //act
            var tuple = SearchByStein(nums);

            //assert 
            Assert.AreEqual(expectedRes, tuple.gcd);
        }


        [Test]
        [Category("Stein's algorithm")]
        public void SearchByStein_NullArray_ThrowsArgumentNullExceptions()
        {
            var ex = Assert.Catch<ArgumentNullException>(() => SearchByStein(null));
            StringAssert.Contains("Value cannot be null.", ex.Message);
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [Category("Stein's algorithm")]
        public void SearchByStein_ArrayLengthLessThanTwo_ThrowsArgumentExceptions(params int[] nums)
        {
            var ex = Assert.Catch<ArgumentException>(() => SearchByStein(nums));
            StringAssert.Contains("Value does not fall within the expected range.", ex.Message);
        }

        #endregion

        #endregion

    }
}