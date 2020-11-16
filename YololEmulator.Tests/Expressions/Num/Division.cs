﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YololEmulator.Tests.Expressions.Num
{
    [TestClass]
    public class Division
    {
        [TestMethod]
        public void DivNumConstantConstant()
        {
            var result = TestExecutor.Execute("a = 6 / 2");

            var a = result.GetVariable("a");

            Assert.AreEqual(3, (int)a.Value.Number);
        }

        [TestMethod]
        public void DivNumVariableConstant()
        {
            var result = TestExecutor.Execute("a = 6", "b = a / 3");

            var a = result.GetVariable("a");
            var b = result.GetVariable("b");

            Assert.AreEqual(6, (int)a.Value.Number);
            Assert.AreEqual(2, (int)b.Value.Number);
        }

        [TestMethod]
        public void DivNumConstantVariable()
        {
            var result = TestExecutor.Execute("a = 2", "b = 6 / a");

            var a = result.GetVariable("a");
            var b = result.GetVariable("b");

            Assert.AreEqual(2, (int)a.Value.Number);
            Assert.AreEqual(3, (int)b.Value.Number);
        }

        [TestMethod]
        public void Truncation()
        {
            Assert.AreEqual(1.666m, (decimal)TestExecutor.Execute("a = 5 / 3").GetVariable("a").Value.Number);
        }
    }
}
