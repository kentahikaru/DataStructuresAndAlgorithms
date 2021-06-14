using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleMovingAverage;

namespace SimpleMovingAverageTests
{
    [TestClass]
    public class SimpleMovingAverageTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            SimpleMovingAverage.SimpleMovingAverage sma = new SimpleMovingAverage.SimpleMovingAverage(3);
            int[] array = new int[] {1,2,3,4,5};
            double result = 0;

            // Act
            foreach(int val in array)
            {
                result = sma.Update(val);
            }

            // Assert
            Assert.AreEqual(4,result);
        }
    }
}