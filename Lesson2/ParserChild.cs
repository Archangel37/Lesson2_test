using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson2
{
    class ParserChild: ParserClass
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
