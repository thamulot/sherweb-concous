using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Concours
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestReverseInPlace()
        {
            try
            {
                ListUtils.ReverseInPlace(null);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentNullException));
                Assert.AreEqual((e as ArgumentException).ParamName, "values");
            }

            var list = new List<int> { 3, 2, 1 };
            ListUtils.ReverseInPlace(list);

            //Assert.AreEqual<List<int>>(list, new List<int> { 1, 2, 3 });
            Assert.AreEqual(list[0], 1);
            Assert.AreEqual(list[1], 2);
            Assert.AreEqual(list[2], 3);
        }

        [TestMethod]
        public void TestEmptyAndDispose()
        {
            try
            {
                ListUtils.EmptyAndDispose(null);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentNullException));
                Assert.AreEqual((e as ArgumentException).ParamName, "values");
            }

            var intsList = new List<int> { 1, 2, 3 };
            ListUtils.EmptyAndDispose(intsList);
            Assert.AreEqual(intsList.Count, 0);

            var disposableObj = new DisposableObj();
            var disposablesList = new List<IDisposable> { disposableObj };
            ListUtils.EmptyAndDispose(disposablesList);
            Assert.AreEqual(disposablesList.Count, 0);
            Assert.IsTrue(disposableObj.isDisposed);

            disposableObj = new DisposableObj();
            var mixedList = new ArrayList { 1, disposableObj, 3 };
            ListUtils.EmptyAndDispose(mixedList);
            Assert.AreEqual(disposablesList.Count, 0);
            Assert.IsTrue(disposableObj.isDisposed);
        }

        [TestMethod]
        public void TestDisposeAll()
        {
            try
            {
                ListUtils.DisposeAll(null);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentNullException));
                Assert.AreEqual((e as ArgumentException).ParamName, "values");
            }

            try
            {                
                ListUtils.DisposeAll(new List<int> { 1, 2, 3 });
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(InvalidCastException));
            }

            var obj = new DisposableObj();
            var list = new List<IDisposable> { obj };
            ListUtils.DisposeAll(list);

            Assert.IsTrue(obj.isDisposed);
        }
    }
}
