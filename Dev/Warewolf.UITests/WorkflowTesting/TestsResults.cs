﻿using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Warewolf.UITests
{
    [CodedUITest]
    public class TestResults
    {
        public static void GetSelectedTestPendingResult(WpfListItem test, int instance = 1)
        {
            Point point;
            switch (instance)
            {
                case 2:
                    var test2 = test as Test2;
                    Assert.IsNotNull(test2);
                    Assert.IsTrue(test2.Pending.Exists);
                    Assert.IsTrue(test2.Pending.TryGetClickablePoint(out point));
                    break;
                case 3:
                    var test3 = test as Test3;
                    Assert.IsNotNull(test3);
                    Assert.IsTrue(test3.Pending.Exists);
                    Assert.IsTrue(test3.Pending.TryGetClickablePoint(out point));
                    break;
                default:
                    var test1 = test as Test1;
                    Assert.IsNotNull(test1);
                    Assert.IsTrue(test1.Pending.Exists);
                    Assert.IsTrue(test1.Pending.TryGetClickablePoint(out point));
                    break;
            }
        }

        public static void GetSelectedTestInvalidResult(WpfListItem test, int instance = 1)
        {
            switch (instance)
            {
                case 2:
                    var test2 = test as Test2;
                    Assert.IsNotNull(test2);
                    Assert.IsTrue(test2.Invalid.Exists);
                    break;
                case 3:
                    var test3 = test as Test3;
                    Assert.IsNotNull(test3);
                    Assert.IsTrue(test3.Invalid.Exists);
                    break;
                default:
                    var test1 = test as Test1;
                    Assert.IsNotNull(test1);
                    Assert.IsTrue(test1.Invalid.Exists);
                    break;
            }
        }
        public static void GetSelectedTestPassingResult(WpfListItem test, int instance = 1)
        {
            if (instance == 2)
            {
                var test2 = test as Test2;
                Assert.IsNotNull(test2);
                Assert.IsTrue(test2.Passing.Exists);
            }
            if (instance == 3)
            {
                var test3 = test as Test3;
                Assert.IsNotNull(test3);
                Assert.IsTrue(test3.Passing.Exists);
            }
            if (instance == 1)
            {
                var test1 = test as Test1;
                Assert.IsNotNull(test1);
                Assert.IsTrue(test1.Passing.Exists);
            }            
        }

        public static void GetSelectedTestFailingResult(WpfListItem test, int instance)
        {
            //Point point;
            switch (instance)
            {
                case 2:
                    var test2 = test as Test2;
                    Assert.IsNotNull(test2);
                    Assert.IsTrue(test2.Failing.Exists);
                    //Assert.IsTrue(test2.Failing.TryGetClickablePoint(out point));
                    break;
                case 3:
                    var test3 = test as Test3;
                    Assert.IsNotNull(test3);
                    Assert.IsTrue(test3.Failing.Exists);
                    //Assert.IsTrue(test3.Failing.TryGetClickablePoint(out point));
                    break;
                default:
                    var test1 = test as Test1;
                    Assert.IsNotNull(test1);
                    Assert.IsTrue(test1.Failing.Exists);
                    //Assert.IsTrue(test1.Failing.TryGetClickablePoint(out point));
                    break;
            }
        }
    }
}