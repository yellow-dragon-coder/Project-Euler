using ProjectEuler.Problems.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace ProjectEuler.Tests
{
    [TestClass]
    public class ExtensionMethodsTests
    {
        [TestMethod]
        public void IsPrimeMethodShouldWork()
        {
            IsFalse(1.IsPrime());
            IsTrue(2.IsPrime());
            IsTrue(3.IsPrime());
            IsFalse(4.IsPrime());
            IsFalse(9.IsPrime());
            IsTrue(19.IsPrime());
            IsTrue(37.IsPrime());
            IsTrue(6857.IsPrime());
        }
    }
}
