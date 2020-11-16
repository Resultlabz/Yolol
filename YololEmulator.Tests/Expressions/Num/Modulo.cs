﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YololEmulator.Tests.Expressions.Num
{
    [TestClass]
    public class Modulo
    {
        [TestMethod]
        public void ConstantConstant()
        {
            var result = TestExecutor.Execute("a = 1 % 2");

            var a = result.GetVariable("a");

            Assert.AreEqual(1, (int)a.Value.Number);
        }

        [TestMethod]
        public void VariableConstant()
        {
            var result = TestExecutor.Execute("a = 5", "b = a % 3");

            var a = result.GetVariable("a");
            var b = result.GetVariable("b");

            Assert.AreEqual(5, (int)a.Value.Number);
            Assert.AreEqual(2, (int)b.Value.Number);
        }

        [TestMethod]
        public void ConstantVariable()
        {
            var result = TestExecutor.Execute("a = 3", "b = 5 % a");

            var a = result.GetVariable("a");
            var b = result.GetVariable("b");

            Assert.AreEqual(3, (int)a.Value.Number);
            Assert.AreEqual(2, (int)b.Value.Number);
        }
    }
}
