using System;
using System.Globalization;
using System.Linq;

namespace Lesson2
{
    internal class ParserClass
    {
        /// <summary>
        ///     (3) Публичное вычисление значение выражения из массива символов
        /// </summary>
        /// <param name="expr">массив символов</param>
        /// <returns></returns>
        public static double EvalExpression(string expr)
        {
            return SummSub(expr);
        }

        /// <summary>
        ///     (2) Получение сумм/вычитаний(та же сумма только число *(-1)) чисел  - Приватная, работает внутри класса
        /// </summary>
        /// <param name="expr"></param>
        /// <returns></returns>
        private static double SummSub(string expr)
        {
            int index = 0;
            double x = MultDiv(expr, ref index);
            //работает без условия на длину
            while (true)
            {
                char op = expr[index]; //операция
                if (op != '+' && op != '-') //"ленивый" булев оператор - если первое условие не выполняется, то второе не сравнивается
                    return x; //если операция не та, возвращаем "as is"
                index++;
                double y = MultDiv(expr, ref index);
                if (op == '+')
                    x += y;
                else
                    x -= y;
            }
        }

        /// <summary>
        ///     (1) Получение произведений, делений чисел
        /// </summary>
        /// <param name="expr"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private static double MultDiv(string expr, ref int index)
        {
            //получение double из выражения
            double x = GetDouble(expr, ref index);
            //работает без условия на длину
            while (true)
            {
                char op = expr[index];
                if (op != '/' && op != '*') //"ленивый" булев оператор - если первое условие не выполняется, то второе не сравнивается
                    return x; //если операции не те, возвращаем "as is"
                index++;
                double y = GetDouble(expr, ref index);
                if (op == '/')
                    x /= y;
                else if (op == '*')
                    x *= y;
            }
        }

        /// <summary>
        ///     (0) Получение числа из строки
        /// </summary>
        /// <param name="expr"></param>
        /// <param name="index"></param>
        /// <returns>(double)</returns>
        private static double GetDouble(string expr, ref int index)
        {
            string str_dbl = "0";
            while( char.IsDigit(expr[index]) || expr[index] == ',')
            {
                str_dbl = str_dbl + expr[index]; //необязательный .ToString() (c) ReSharper
                index++;
                if (index == expr.Length)
                {
                    index--;
                    break;
                }
            }

            //Посчитать количество запятых в числе, если больше 1 - кинуть ArgumentException()
            if (str_dbl.ToCharArray().Count(x => x == ',') > 1) throw new ArgumentException("Too many commas!");
            return double.Parse(str_dbl);
        }
    }
}