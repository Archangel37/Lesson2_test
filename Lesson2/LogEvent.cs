using System;

namespace Lesson2
{
    /// <summary>
    ///     Класс события лога
    /// </summary>
    [Serializable]
    class LogEvent
    {
        /// <summary>
        ///     Выражение, которое парсится
        /// </summary>
        public string Expression;
        /// <summary>
        ///     Полученный результат
        /// </summary>
        public double Result;
        /// <summary>
        ///     Время запроса
        /// </summary>
        public DateTime QueryTime;
        /// <summary>
        ///     Продолжительность вычислений
        /// </summary>
        public TimeSpan Duration;
    }
}
