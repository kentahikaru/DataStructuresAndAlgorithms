using NUnit.Framework;
using Structures.BinarySearchTree.BinarySearchTree;

namespace BinarySearchTreeTests
{
    public class Tests
    {
        BinarySearchTree bst { get; set; } = null;

        [SetUp]
        public void Setup()
        {
            if(this.bst == null)
                bst = new BinarySearchTree();

            bst.Add(3, "three");
            bst.Add(4, "four");
            bst.Add(5, "five");
            bst.Add(2, "two");
            bst.Add(8, "eight");
            bst.Add(6, "six");
            bst.Add(7, "seven");
        }

        [Test]
        public void TestTree()
        {
            Node node = bst.Get(5);
            Assert.That(node.right.key, Is.EqualTo(8));
        }

        [Test]
        public void TestGetNode()
        {
            Node node = bst.Get(8);
            Assert.That(node.key, Is.EqualTo(8));
            Assert.That(node.value, Is.EqualTo("eight"));
        }

        [Test]
        public void TestIncludeTrue()
        {
            Assert.True(bst.Includes(8));
        }

        [Test]
        public void TestIncludeFalse()
        {
            Assert.False(bst.Includes(9));
        }

        [Test]
        public void TestRemoveNode()
        {
            bst.Remove(5);

            Node node = bst.Get(4);
            Assert.That(node.right.key, Is.EqualTo(6));
        }

        [Test]
        public void TestRemoveAll()
        {
            bst.RemoveAll();

            Assert.Null(bst.GetRoot());
        }

        [TearDown]
        public void TearDown()
        {
            bst.RemoveAll();
            this.bst = null;
        }
    }
}