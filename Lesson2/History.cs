using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace Lesson2
{
    [Serializable]
    class History
    {
        public DateTime SessionStartTime;
        public DateTime SessionEndTime;
        public List<LogEvent> EventsList;

        public History()
        {
            SessionStartTime = default(DateTime);
            SessionEndTime = default(DateTime);
            EventsList = new List<LogEvent>();
        }

        /// <summary>
        ///     Приватная константа, чтоб изменять в одном месте
        /// </summary>
        private const string LogFileName = "LogFile.json";

        /// <summary>
        ///     Прочитать все логи, превратить в лист LogEvent-ов
        /// </summary>
        /// <returns></returns>
        private static List<History> ReadLog()
        {
            if (File.Exists(LogFileName) && new FileInfo(LogFileName).Length > 0)
            {
                return JsonConvert.DeserializeObject<List<History>>(File.ReadAllText(LogFileName));
            }
            return new List<History>();
        }

        /// <summary>
        ///     Записывает перебор элементов в файл логов
        /// </summary>
        /// <param name="Logs"></param>
        private static void WriteLogs(IEnumerable<History> Histories)
        {
            File.WriteAllText(LogFileName, JsonConvert.SerializeObject(Histories, Formatting.Indented));
        }

        /// <summary>
        ///     Сохраняет текущую историю
        /// </summary>
        public void SaveHistory()
        {
            var curLog = ReadLog();
            curLog.Add(this);
            WriteLogs(curLog);
        }
    }
}
