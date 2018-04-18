using System;
using System.Windows.Forms;

namespace Lesson2
{
    class ParserChild: Parser
    {
        public override double EvalExpression(string expr)
        {
            this.expr = expr;
            index = 0;
            var timeStart = DateTime.Now;
            var parseResult = base.EvalExpression(expr);
            MessageBox.Show($"Totally spent(general short): {(DateTime.Now - timeStart):g}", "Time Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return parseResult;
        }
    }
}
