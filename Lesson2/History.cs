using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Lesson2
{
    static class History
    {
        /// <summary>
        ///     Приватная константа, чтоб изменять в одном месте
        /// </summary>
        private const string LogFileName = "LogFile.json";

        /// <summary>
        ///     Прочитать все логи, превратить в лист LogEvent-ов
        /// </summary>
        /// <returns></returns>
        private static List<SessionLog> ReadLog()
        {
            if (File.Exists(LogFileName) && new FileInfo(LogFileName).Length > 0)
            {
                return JsonConvert.DeserializeObject<List<SessionLog>>(File.ReadAllText(LogFileName));
            }
            return new List<SessionLog>();
        }

        /// <summary>
        ///     Записывает перебор элементов в файл логов
        /// </summary>
        private static void WriteLogs(IEnumerable<SessionLog> Histories)
        {
            File.WriteAllText(LogFileName, JsonConvert.SerializeObject(Histories, Formatting.Indented));
        }

        /// <summary>
        ///     Сохраняет текущую историю
        /// </summary>
        public static void SaveHistory(SessionLog History)
        {
            var curLog = ReadLog();
            curLog.Add(History);
            WriteLogs(curLog);
        }
    }
}
