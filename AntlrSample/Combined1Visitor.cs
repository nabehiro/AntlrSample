using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntlrSample
{
    class Combined1Visitor : Combined1BaseVisitor<int>
    {
        public override int VisitInt(Combined1Parser.IntContext context)
        {
            return int.Parse(context.INT().GetText());
        }

        public override int VisitAddSub(Combined1Parser.AddSubContext context)
        {
            var left = Visit(context.expr(0));
            var right = Visit(context.expr(1));
            if (context.op.Type == Combined1Parser.ADD)
                return left + right;
            else
                return left - right;
        }

        public override int VisitMulDiv(Combined1Parser.MulDivContext context)
        {
            var left = Visit(context.expr(0));
            var right = Visit(context.expr(1));
            if (context.op.Type == Combined1Parser.MUL)
                return left * right;
            else
                return left / right;
        }

        public override int VisitParens(Combined1Parser.ParensContext context)
        {
            return Visit(context.expr());
        }
    }
}
