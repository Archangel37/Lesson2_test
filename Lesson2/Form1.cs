using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Lesson2
{
    public partial class FormStringParser : Form
    {

        public FormStringParser()
        {
            InitializeComponent();
            curHistory.SessionStartTime = DateTime.Now;
            FormClosing += FormStringParser_FormClosing;
        }

        /// <summary>
        ///     Инициализированный объект класса History
        /// </summary>
        SessionLog curHistory = new SessionLog();  


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
            curHistory.EventsList.Add(new LogEvent { Expression = textBoxStringExpression.Text, QueryTime = DateTime.Now });
            int index = curHistory.EventsList.Count - 1;

            var newParser = new Parser();

            try
            {
                curHistory.EventsList[index].Result = newParser.EvalExpression(Normalize(textBoxStringExpression.Text));
                curHistory.EventsList[index].Duration = DateTime.Now - curHistory.EventsList[index].QueryTime;
                textBoxResult.Text = curHistory.EventsList[index].Result.ToString(CultureInfo.InvariantCulture);
            }
            catch (CustomException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        ///     Событие при закрывании формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormStringParser_FormClosing(object sender, FormClosingEventArgs e)
        {
            curHistory.SessionEndTime = DateTime.Now;
            History.SaveHistory(curHistory);
        }
    }
}