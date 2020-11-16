﻿using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yolol.Execution;

namespace YololEmulator.Tests
{
    [TestClass]
    public class MachineStateTests
    {
        [TestMethod]
        public void EnumerateEmpty()
        {
            var s = new MachineState(new ConstantNetwork()).ToArray();
            Assert.AreEqual(0, s.Length);
        }

        [TestMethod]
        public void Enumerate()
        {
            var s = new MachineState(new ConstantNetwork());

            s.GetVariable("name");

            var arr = s.ToArray();
            Assert.AreEqual(1, arr.Length);
        }

        [TestMethod]
        public void ExternalVariable()
        {
            var n = new ConstantNetwork();
            n.Get("name").Value = new Value((Number)13);
            var s = new MachineState(n);

            Assert.AreEqual((Number)13, s.GetVariable(":name").Value.Number);
        }
    }
}
