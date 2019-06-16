﻿using System;
using YololEmulator.Execution;


namespace YololEmulator.Grammar.AST.Expressions.Binary
{
    public class EqualToExpression
        : BaseBinaryExpression
    {
        public EqualToExpression(BaseExpression lhs, BaseExpression rhs)
            : base(lhs, rhs)
        {
        }

        protected override Value Evaluate(string l, string r)
        {
            return new Value(l.Equals(r, StringComparison.OrdinalIgnoreCase) ? 1 : 0);
        }

        protected override Value Evaluate(Number l, Number r)
        {
            return new Value(l == r ? 1 : 0);
        }

        protected override Value Evaluate(string l, Number r)
        {
            return Evaluate(l, r.ToString());
        }

        protected override Value Evaluate(Number l, string r)
        {
            return Evaluate(l.ToString(), r);
        }
    }
}
