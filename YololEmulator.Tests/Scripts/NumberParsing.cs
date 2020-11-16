﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yolol.Execution;

namespace YololEmulator.Tests.Scripts
{
    [TestClass]
    public class NumberParsing
    {
        [TestMethod]
        public void ChaosAlphaSimplified()
        {
            var lines = new[] {
                "s=\"84726\" if s==\"\" then goto 1 end m=1 n=0 h=s",
                "if h==\"\" then s=h goto 6 else s=h-- t=s-h d=d-1 end",
                "d=(t==\"0\")+(t==\"1\")*2+(t==\"2\")*3+(t==\"3\")*4+(t==\"4\")*5+(t==\"5\")*6",
                "d=d+(t==\"6\")*7+(t==\"7\")*8+(t==\"8\")*9+(t==\"9\")*10-1",
                "if d==-1 then goto 6 end n=n+d*m m=m*10 goto 2",
                "OUTPUT=n"
            };

            var result = TestExecutor.Execute(lines);

            var output = result.GetVariable("output");

            Assert.AreEqual(84726, (int)output.Value.Number);
        }

        [TestMethod]
        public void ChaosAlphaCompound()
        {
            var lines = new[] {
                "s=\"8473426\" if s==\"\" then goto 1 end m=1 n=0 h=s",
                "if h==\"\" then s=h goto 6 else s=h-- t=s-h d-=1 end",
                "d=(t==\"0\")+(t==\"1\")*2+(t==\"2\")*3+(t==\"3\")*4+(t==\"4\")*5+(t==\"5\")*6",
                "d+=(t==\"6\")*7+(t==\"7\")*8+(t==\"8\")*9+(t==\"9\")*10-1",
                "if d==-1 then goto 6 end n+=d*m m*=10 goto 2",
                "OUTPUT=n"
            };

            var result = TestExecutor.Execute(lines);

            var output = result.GetVariable("output");

            Assert.AreEqual(8473426, (int)output.Value.Number);
        }

        public Number Azurethi(Number value)
        {
            var lines = new[] {
                $"i=\"{value}\" o=0 j=0",
                "c=i---i d=3*((c>1)+(c>4)+(c>7)) o+=(d+(c>d)-(c<d))*(10^j++) goto 2",
                ":o=o"
            };

            var result = TestExecutor.Execute2(100, lines);

            var output = result.GetVariable(":o");

            Assert.AreEqual(value, output.Value.Number);

            return output.Value.Number;
        }

        [TestMethod]
        public void Azurethi()
        {
            Azurethi((Number)1698615886);
        }

        [TestMethod]
        public void Classifying()
        {
            var code = "c=\"{0}\" i=1*(c>-1) i-=1*(i>c) i+=8*(i<c)";

            var state = TestExecutor.Execute(string.Format(code, "."));
            Console.WriteLine($"{state.GetVariable("c")} => {state.GetVariable("i")}");

            for (var i = 0; i < 16; i++)
            {
                var statei = TestExecutor.Execute(string.Format(code, i));
                Console.WriteLine($"{statei.GetVariable("c")} => {statei.GetVariable("i")}");
            }

            
        }

        [TestMethod]
        public void MyParser()
        {
            var state = TestExecutor.Execute("n=1030178 d=4 f=(10^(3+d)) a=1000*(n/f) b=(n-(a*10^d)) / 1000 o=a+b");
            Console.WriteLine(state.GetVariable("a"));
            Console.WriteLine(state.GetVariable("b"));
            Console.WriteLine(state.GetVariable("o"));
        }
    }
}
