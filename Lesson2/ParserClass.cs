using System;
using System.Globalization;
using System.Linq;

namespace Lesson2
{
    internal class ParserClass
    {

        protected string expr;
        protected int index;


        /// <summary>
        ///     (4) Публичное вычисление значения выражения из массива символов, для перегрузки
        /// </summary>
        /// <param name="expr">массив символов</param>
        /// <returns></returns>
        public virtual double EvalExpression(string expr)
        {
            this.expr = expr;
            index = 0;
            return SummSub();
        }

        /// <summary>
        ///     (3) Получение сумм/вычитаний(та же сумма только число *(-1)) чисел  - Приватная, работает внутри класса//protected
        /// </summary>
        /// <param name="expr"></param>
        /// <returns></returns>
        protected double SummSub()
        {
            double x = MultDiv();
            //работает без условия на длину
            while (true)
            {
                char op = expr[index]; //операция
                if (op != '+' && op != '-') //"ленивый" булев оператор - если первое условие не выполняется, то второе не сравнивается
                    return x; //если операция не та, возвращаем "as is"
                index++;
                double y = MultDiv();
                if (op == '+')
                    x += y;
                else
                    x -= y;
            }
        }

        /// <summary>
        ///     (2) Получение произведений, делений чисел
        /// </summary>
        /// <param name="expr"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private double MultDiv()
        {
            //получение double из выражения
            double x = FactorialFunc();
            //работает без условия на длину
            while (true)
            {
                char op = expr[index];
                if (op != '/' && op != '*') //"ленивый" булев оператор - если первое условие не выполняется, то второе не сравнивается
                    return x; //если операции не те, возвращаем "as is"
                index++;
                double y = FactorialFunc();
                if (op == '/')
                    x /= y;
                else if (op == '*')
                    x *= y;
            }
        }

        /// <summary>
        ///     (1) Вычисление факториала
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private double Fact(double x) => x == 0 ? 1 : x * Fact(x - 1);

        /// <summary>
        ///     Парсинг факториала
        /// </summary>
        /// <returns></returns>
        private double FactorialFunc()
        {
            double x = GetDouble();
            if (index < expr.Length && expr[index] == '!')
            {
                index++;
                return Fact((int) x);
            }
            return x;
        }


        /// <summary>
        ///     (0) Получение числа из строки
        /// </summary>
        /// <returns>(double)</returns>
        private double GetDouble()
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