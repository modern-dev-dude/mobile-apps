using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReversePolishNotation;

namespace RpnTest
{
    [TestClass]
    public class RpnUnitTest
    {
        [TestMethod]
        public void RpnUnitTestMethod()
        {
            // Test RPN Notation conversion for 3 + 4 * 2 / (1 - 5) ^ 2 ^ 3 and ((1 + 2) ^ (3 + 4)) ^ (5 + 6
            string[] expectedValues = {"3 + 4 * 2 / (1 - 5) ^ 2 ^ 3","((1 + 2) ^ (3 + 4)) ^ (5 + 6)"};
            string[] valuesToTest = { "3 4 2 * 1 5 - 2 3 ^ ^ / +", "1 2 + 3 4 + ^ 5 6 + ^" };
            for(int i = 0; i < valuesToTest.Length; i++)
            {
                // test that the class is converting from RPN to Standard Notation
                string getInfix = ReversePolishNotation.RpnCalc.PostfixToInfix(valuesToTest[i]); 
                Assert.AreEqual(expectedValues[i], getInfix);
            }
        }
    }
}