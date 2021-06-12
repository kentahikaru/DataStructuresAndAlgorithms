using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArrayStack;

namespace ArrayStackTests
{
    [TestClass]
    public class ArrayStackTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            ArrayStack.ArrayStack<int> arrayStack = new ArrayStack.ArrayStack<int>(2);
            // Act
            arrayStack.Push(10);

            // Assert
            Assert.AreEqual(10, arrayStack.Pop());
        }
    }
}