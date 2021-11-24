﻿using Yolol.Grammar.AST.Expressions;
using Yolol.Grammar.AST.Expressions.Unary;
using Yolol.Grammar.AST.Statements;

namespace Yolol.Analysis.TreeVisitor.Reduction
{
    public class SimpleBracketElimination
        : BaseTreeVisitor
    {
        protected override BaseExpression Visit(Bracketed brk)
        {
            var inner = Visit(brk.Parameter);

            return inner switch
            {
                Variable v => v,
                ConstantNumber n => n,
                ConstantString s => s,
                Bracketed b => b,
                _ => base.Visit(new Bracketed(inner)),
            };
        }

        protected override BaseStatement Visit(Assignment ass)
        {
            var right = Visit(ass.Right);
            var left = Visit(ass.Left);

            if (right is Bracketed brk)
                return base.Visit(new Assignment(left, brk.Parameter));
            else
                return base.Visit(ass);
        }

        protected override BaseStatement Visit(Goto @goto)
        {
            var right = Visit(@goto.Destination);

            if (right is Bracketed brk)
                return base.Visit(new Goto(brk.Parameter));
            else
                return base.Visit(@goto);
        }

        protected override BaseStatement Visit(If @if)
        {
            var cond = Visit(@if.Condition);
            var tru = Visit(@if.TrueBranch);
            var fas = Visit(@if.FalseBranch);

            if (cond is Bracketed brk)
                return base.Visit(new If(brk.Parameter, tru, fas));
            else
                return base.Visit(@if);
        }
    }
}
