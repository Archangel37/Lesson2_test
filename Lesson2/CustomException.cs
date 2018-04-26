using System;
using System.Diagnostics;

namespace Lesson2
{
    class CustomException: Exception
    {
        public override string Message => GetExceptionNeededInfo(this);

        /// <summary>
        ///     Метод для преобразования мессаджей всех ошибок, поэтому паблик - могу использовать для своего эксепшена, а можно для общего
        /// </summary>
        /// <param name="ex">Произвольный подаваемый в метод эксепшен</param>
        /// <returns></returns>
        public string GetExceptionNeededInfo(Exception ex)
        {
            var st = new StackTrace(ex, true);
            return
            $"Ошибка во время выполнения метода: {st.GetFrame(0).GetMethod().Name}\n" +
            $"Тип ошибки: {GetType()}\n" +
            $"Файл: {st.GetFrame(1).GetFileName()}\n" +
            $"Метод: {st.GetFrame(1).GetMethod()}\n" +
            $"Строка в коде: {st.GetFrame(1).GetFileLineNumber()}\n";
        }
    }
}
