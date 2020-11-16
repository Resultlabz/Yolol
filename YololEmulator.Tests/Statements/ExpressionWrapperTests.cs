﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yolol.Execution;
using Yolol.Grammar.AST.Expressions;
using Yolol.Grammar.AST.Expressions.Binary;
using Yolol.Grammar.AST.Statements;

namespace YololEmulator.Tests.Statements
{
    [TestClass]
    public class ExpressionWrapperTests
    {
        [TestMethod]
        public void PropagatesRuntimeErrorTrue()
        {
            Assert.IsTrue(new ExpressionWrapper(new Divide(new ConstantString("a"), new ConstantString("b"))).CanRuntimeError);
        }

        [TestMethod]
        public void PropagatesRuntimeErrorFalse()
        {
            Assert.IsFalse(new ExpressionWrapper(new Add(new ConstantNumber((Number)1), new ConstantNumber((Number)2))).CanRuntimeError);
        }
    }
}
