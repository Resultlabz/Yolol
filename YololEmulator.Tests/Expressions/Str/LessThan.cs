﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YololEmulator.Tests.Expressions.Str
{
    [TestClass]
    public class LessThan
    {
        [TestMethod]
        public void False()
        {
            var result = TestExecutor.Execute("a = \"zzz\" < \"aaa\"");

            var a = result.GetVariable("a");

            Assert.AreEqual(0, (int)a.Value.Number);
        }

        [TestMethod]
        public void True()
        {
            var result = TestExecutor.Execute("a = \"aaa\" < \"zzz\"");

            var a = result.GetVariable("a");

            Assert.AreEqual(1, (int)a.Value.Number);
        }
    }
}
