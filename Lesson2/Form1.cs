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
        ///     Собственно, само использование класса парсера ParserClass либо его потомка
        ///     Парсим/вычисляем
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calculate_Click(object sender, EventArgs e)
        {
            //DateTime starTime = DateTime.Now;

            if (checkBoxShowTime.Checked)
            {
                var childParser = new ParserChild();
                textBoxResult.Text = childParser.EvalExpression(Normalize(textBoxStringExpression.Text)).ToString();
            }
            else
            {
                var newParser = new ParserClass();
                textBoxResult.Text = newParser.EvalExpression(Normalize(textBoxStringExpression.Text)).ToString();
            }
           
            //MessageBox.Show($"Totally spent: {(DateTime.Now - starTime).TotalMilliseconds}", "Time Info",
                //MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}