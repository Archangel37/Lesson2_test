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

        ///// <summary>
        ///// вычисления при помощи (new DataTable()).Compute(expression, null)
        /////</summary>
        ///// <param name="expression"></param>
        ///// <returns></returns> */
        //public double CalculateVerOne(string expression)
        //{
        //    try
        //    {
        //        return (double)(new DataTable()).Compute(expression, null);
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message, e.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return 0;
        //}
        //выяснить баг - "-бесконечность" (деление на 0, похоже в DataTable)
        //после удаления лишних пробелов из:
        //-5541 54 4 / -5566 6 46 * 45 66 - 544 * 46 6 4 *5 + 879879/ 87


        /// <summary>
        ///     Нормализация введённого текста - удаление всех пробелов, замена всех точек на запятые, принимаемые
        ///     методом double.Parse(str_dbl)
        /// </summary>
        /// <param name="expression">Входная строка для нормализации (удаление пробелов, замена точки на запятую)</param>
        /// <returns></returns>
        public string Normalize(string expression)
        => Regex.Replace(expression, @"\s+", string.Empty).Replace(".", ",");
        


        /// <summary>
        ///     Собственно, само использование класса парсера ParserClass-> Нормализуем текст -> Засовываем в char[] ->
        ///     Парсим/вычисляем
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calculate_Click(object sender, EventArgs e)
        {
            string normalizedString = Normalize(textBoxStringExpression.Text);
            char[] charArray = normalizedString.ToCharArray(0, normalizedString.Length);
            textBoxResult.Text = ParserClass.EvalExpression(charArray).ToString();
        }
    }
}