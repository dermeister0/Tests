using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReaderWriterLockSlimTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(LockRecursionException))]
        public void TestMethod1()
        {
            var slimLock = new ReaderWriterLockSlim();
            slimLock.EnterReadLock();
            slimLock.EnterReadLock();
        }

        [TestMethod]
        [ExpectedException(typeof(LockRecursionException))]
        public void TestMethod2()
        {
            var slimLock = new ReaderWriterLockSlim();
            slimLock.EnterReadLock();
            slimLock.EnterWriteLock();
        }

        [TestMethod]
        public void TestMethod3()
        {
            var slimLock = new ReaderWriterLockSlim();
            slimLock.EnterUpgradeableReadLock();
            slimLock.EnterReadLock();

            Assert.AreEqual(true, slimLock.IsReadLockHeld);
            Assert.AreEqual(false, slimLock.IsWriteLockHeld);
            Assert.AreEqual(true, slimLock.IsUpgradeableReadLockHeld);

            slimLock.ExitReadLock();

            Assert.AreEqual(false, slimLock.IsReadLockHeld);
            Assert.AreEqual(false, slimLock.IsWriteLockHeld);
            Assert.AreEqual(true, slimLock.IsUpgradeableReadLockHeld);

            slimLock.EnterWriteLock();
            Assert.AreEqual(false, slimLock.IsReadLockHeld);
            Assert.AreEqual(true, slimLock.IsWriteLockHeld);
            Assert.AreEqual(true, slimLock.IsUpgradeableReadLockHeld);
            slimLock.ExitWriteLock();

            Assert.AreEqual(false, slimLock.IsReadLockHeld);
            Assert.AreEqual(false, slimLock.IsWriteLockHeld);
            Assert.AreEqual(true, slimLock.IsUpgradeableReadLockHeld);
        }

        [TestMethod]
        [ExpectedException(typeof(LockRecursionException))]
        public void TestMethod4()
        {
            var slimLock = new ReaderWriterLockSlim();
            slimLock.EnterUpgradeableReadLock();
            slimLock.EnterUpgradeableReadLock();
        }

        [TestMethod]
        public void TestMethod5()
        {
            var slimLock = new ReaderWriterLockSlim();
            slimLock.EnterUpgradeableReadLock();
            slimLock.EnterReadLock();

            Assert.AreEqual(true, slimLock.IsReadLockHeld);
            Assert.AreEqual(false, slimLock.IsWriteLockHeld);
            Assert.AreEqual(true, slimLock.IsUpgradeableReadLockHeld);

            slimLock.ExitUpgradeableReadLock();

            Assert.AreEqual(true, slimLock.IsReadLockHeld);
            Assert.AreEqual(false, slimLock.IsWriteLockHeld);
            Assert.AreEqual(false, slimLock.IsUpgradeableReadLockHeld);
        }
    }
}
