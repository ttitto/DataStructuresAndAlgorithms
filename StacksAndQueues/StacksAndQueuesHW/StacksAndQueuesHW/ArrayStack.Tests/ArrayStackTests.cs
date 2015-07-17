﻿namespace ArrayStack.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using DS.Implementations;

    [TestClass]
    public class ArrayStackTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Peek on empty stack should throw InvalidOperationException")]
        public void PeekOnEmptyStackShouldThrowException()
        {
            ArrayStack<int> stack = new ArrayStack<int>(4);
            stack.Peek();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Pop on empty stack should throw InvalidOperationException")]
        public void PopOnEmptyStackShouldThrowException()
        {
            ArrayStack<int> stack = new ArrayStack<int>(4);
            stack.Pop();
        }

        [TestMethod]
        public void PushPopShouldSetCountCorrectlyAndReturnCorrectElement()
        {
            ArrayStack<int> stack = new ArrayStack<int>(4);

            Assert.AreEqual(0, stack.Count, "Count for newly created stack is not correct.");
            stack.Push(3);
            Assert.AreEqual(1, stack.Count, "Count for a single pushed element is not correct.");
            Assert.AreEqual(3, stack.Pop(), "Popped element is not correct.");
            Assert.AreEqual(0, stack.Count, "Count for single pushed and popped element is not correct.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Pop on empty stack should throw InvalidOperationException")]
        public void PushPopManyElementsShouldSetCountCorrectlyAndReturnCorrectElement()
        {
            ArrayStack<string> stack = new ArrayStack<string>();

            Assert.AreEqual(0, stack.Count, "Count for newly created stack is not correct.");

            for (int i = 0; i < 1000; i++)
            {
                stack.Push(i.ToString());
                Assert.AreEqual(i + 1, stack.Count, string.Format("Count is not correct for element {0}", i));
            }

            for (int i = 1000; i >= 0; i--)
            {
                Assert.AreEqual((i - 1).ToString(), stack.Pop(), "Popped element is not correct.");
                Assert.AreEqual(i - 1, stack.Count, "Count after element popping is not correct");
            }
        }

        [TestMethod]
        public void PushPeekManyElementsShouldSetCountCorrectlyAndReturnCorrectElement()
        {
            ArrayStack<string> stack = new ArrayStack<string>();

            Assert.AreEqual(0, stack.Count, "Count for newly created stack is not correct.");

            for (int i = 0; i < 1000; i++)
            {
                stack.Push(i.ToString());
            }

            for (int i = 1000; i >= 0; i--)
            {
                Assert.AreEqual("999", stack.Peek(), "Peeked element is not correct.");
                Assert.AreEqual(1000, stack.Count, "Count after element peeking is not correct");
            }
        }

        [TestMethod]
        public void PushPopFromStackWithInitialCapacity1ShouldWorkCorrectly()
        {
            ArrayStack<int> stack = new ArrayStack<int>(1);

            Assert.AreEqual(0, stack.Count, "Count for newly created stack is not correct.");

            stack.Push(34);
            Assert.AreEqual(1, stack.Count, "Count for stack with 1 element is not correct.");

            stack.Push(55);
            Assert.AreEqual(2, stack.Count, "Count for stack with 2 elements is not correct.");

            Assert.AreEqual(55, stack.Pop(), "Popped element is not correct.");
            Assert.AreEqual(1, stack.Count, "Count is not correct.");

            Assert.AreEqual(34, stack.Pop(), "Popped element is not correct.");
            Assert.AreEqual(0, stack.Count, "Count for empty stack after popping the last element not correct.");
        }

        [TestMethod]
        public void ToArrayShouldReturnArrayWithReversedElements()
        {
            ArrayStack<int> stack = new ArrayStack<int>();

            stack.Push(5);
            stack.Push(-2);
            stack.Push(9);
            stack.Push(45);

            CollectionAssert.AreEqual(new int[]{45, 9, -2, 5}, stack.ToArray(), "ToArray does not return correct order of elements");
        }

        [TestMethod]
        public void ToArrayOfEmptyStackShouldReturnEmptyArray()
        {
            ArrayStack<int> stack = new ArrayStack<int>();

            CollectionAssert.AreEqual(new int[] { }, stack.ToArray(), "ToArray does not return empty array for empty stack.");
        }
    }
}
