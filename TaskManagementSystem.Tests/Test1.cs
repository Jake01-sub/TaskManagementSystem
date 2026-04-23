using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TaskManagementSystem;

namespace TaskManagementSystem.Tests
{
    [TestClass]
    public class PriorityTests
    {
        private AbstractTask CreateTestTask(int priority)
        {
            return new ProjectTask(999, "Test Task", priority);
        }

        [TestMethod]
        public void SetPriority_ValidValue_NoException()
        {
            try
            {
                AbstractTask task = CreateTestTask(3);
                Assert.AreEqual(3, task.Priority, "Priority should be set to 3.");
            }
            catch (Exception)
            {
                Assert.Fail("No exception should be thrown for a valid priority.");
            }
        }

        [TestMethod]
        public void SetPriority_BoundarySix_ThrowsArgumentException()
        {
            var ex = Assert.ThrowsException<ArgumentException>(() => CreateTestTask(6));
            StringAssert.Contains(ex.Message, "Priority must be between 1 and 5");
        }

        [TestMethod]
        public void SetPriority_NegativeValue_ThrowsArgumentException()
        {
            var ex = Assert.ThrowsException<ArgumentException>(() => CreateTestTask(-1));
            StringAssert.Contains(ex.Message, "Priority must be between 1 and 5");
        }

        [TestMethod]
        public void SetPriority_BoundaryZero_ThrowsArgumentException()
        {
            var ex = Assert.ThrowsException<ArgumentException>(() => CreateTestTask(0));
            StringAssert.Contains(ex.Message, "Priority must be between 1 and 5");
        }

        [TestMethod]
        public void SetPriority_BoundaryFive_NoException()
        {
            try
            {
                AbstractTask task = CreateTestTask(5);
                Assert.AreEqual(5, task.Priority);
            }
            catch
            {
                Assert.Fail("5 is a valid priority, no exception expected.");
            }
        }

        [TestMethod]
        public void SetPriority_BoundaryOne_NoException()
        {
            try
            {
                AbstractTask task = CreateTestTask(1);
                Assert.AreEqual(1, task.Priority);
            }
            catch
            {
                Assert.Fail("1 is a valid priority, no exception expected.");
            }
        }
    }
}