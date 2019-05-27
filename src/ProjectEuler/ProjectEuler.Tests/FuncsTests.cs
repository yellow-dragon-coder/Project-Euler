using ProjectEuler.Problems.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static ProjectEuler.Problems.Helpers.Funcs;

namespace ProjectEuler.Tests
{
    [TestClass]
    public class FuncsTests
    {
        [TestMethod]
        public void IsPrimeTest()
        {
            IsFalse(9.IsPrime());
            IsTrue(19.IsPrime());
            IsTrue(37.IsPrime());
            IsTrue(6857.IsPrime());
        }

        [TestMethod]
        public void GcdTest()
        {
            AreEqual(0, Gcd(0, 0));
            AreEqual(1, Gcd(0, 1));
            AreEqual(1, Gcd(1, 0));
            AreEqual(6, Gcd(0, 6));
            AreEqual(6, Gcd(6, 0));
            AreEqual(1, Gcd(1, 1));
            AreEqual(2, Gcd(2, 2));
            AreEqual(1, Gcd(2, 3));
            AreEqual(3, Gcd(9, 3));
            AreEqual(2, Gcd(6, 4));
            AreEqual(2, Gcd(18, 14));
            AreEqual(300, Gcd(44100, 48000));
        }
    }
}
