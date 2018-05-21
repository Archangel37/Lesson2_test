using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;

namespace Lesson2
{
    /// <summary>
    ///     Класс для работы с Json-логом
    /// </summary>
    static class JsonHelper
    {
        /// <summary>
        ///     Приватная константа, чтоб изменять в одном месте
        /// </summary>
        private const string LogFileName = "LogFile.json";

        /// <summary>
        ///     Если нет лог-файла - создаст, если есть - игнор
        /// </summary>
        public static void CreateLog()
        {
            if (!File.Exists(LogFileName)) File.Create(LogFileName).Dispose();
        }

        /// <summary>
        ///     Прочитать все логи, превратить в лист LogEvent-ов
        /// </summary>
        /// <returns></returns>
        private static List<LogEvent> ReadLog()
        {
            if (File.Exists(LogFileName) && new FileInfo(LogFileName).Length >0)
            {
                return JsonConvert.DeserializeObject<List<LogEvent>>(File.ReadAllText(LogFileName));  
            }
            return new List<LogEvent>();
        }

        /// <summary>
        ///     Добавить один лог-эвент в файл логов
        /// </summary>
        /// <param name="_logEvent"></param>
        public static void AddOneLogEvent(LogEvent _logEvent)
        {
            var curLog = ReadLog();
            curLog.Add(_logEvent);
            WriteLogs(curLog);
        }

        /// <summary>
        ///     Записывает перебор элементов в файл логов
        /// </summary>
        /// <param name="Logs"></param>
        private static void WriteLogs(IEnumerable<LogEvent> Logs)
        {
            File.WriteAllText(LogFileName, JsonConvert.SerializeObject(Logs, Formatting.Indented));
        }
    }
}
