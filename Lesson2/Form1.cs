﻿using System;
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
        ///     Собственно, само использование класса парсера ParserClass-> Нормализуем текст -> Засовываем в char[] ->
        ///     Парсим/вычисляем
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calculate_Click(object sender, EventArgs e)
        {
            DateTime starTime = DateTime.Now;
            textBoxResult.Text = ParserClass.EvalExpression(Normalize(textBoxStringExpression.Text)).ToString();
            MessageBox.Show($"Totally spent: {(DateTime.Now - starTime).TotalMilliseconds}", "Time Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}