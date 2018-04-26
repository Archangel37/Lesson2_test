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
            if (checkBoxShowTime.Checked)
            {
                var childParser = new ParserChild();
                try
                {
                    textBoxResult.Text = childParser.EvalExpression(Normalize(textBoxStringExpression.Text)).ToString();
                }
                catch (CustomException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    var exc = new CustomException();
                    MessageBox.Show(exc.GetExceptionNeededInfo(ex), ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var newParser = new Parser();

                try
                {
                    textBoxResult.Text = newParser.EvalExpression(Normalize(textBoxStringExpression.Text)).ToString();
                }
                catch (CustomException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    var exc = new CustomException();
                    MessageBox.Show(exc.GetExceptionNeededInfo(ex), ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }
    }
}