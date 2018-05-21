using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Lesson2
{
    public partial class FormStringParser : Form
    {
        public FormStringParser()
        {
            InitializeComponent();
        }


        /// <summary>
        ///     Нормализация введённого текста - удаление всех пробелов
        /// </summary>
        /// <param name="expression">Входная строка для нормализации (удаление пробелов)</param>
        /// <returns></returns>
        private static string Normalize(string expression)
        => Regex.Replace(expression, @"\s+", string.Empty);
        

        /// <summary>
        ///     Собственно, само использование класса парсера ParserClass (убрал использование потомка)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calculate_Click(object sender, EventArgs e)
        {
            JsonHelper.CreateLog();

            var _logEvent = new LogEvent
            {
                Expression = textBoxStringExpression.Text
            };

            DateTime startQuery = DateTime.Now;
            _logEvent.QueryTime = startQuery;

            var newParser = new Parser();

            try
            {
                _logEvent.Result = newParser.EvalExpression(Normalize(textBoxStringExpression.Text));
                _logEvent.Duration = DateTime.Now - startQuery;
                textBoxResult.Text = _logEvent.Result.ToString();
            }
            catch (CustomException ex)
            {
                MessageBox.Show(ex.Message);
            }

            JsonHelper.AddOneLogEvent(_logEvent);
        }
    }
}