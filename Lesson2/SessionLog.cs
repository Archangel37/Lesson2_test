using System;
using System.Collections.Generic;

namespace Lesson2
{
    [Serializable]
    class SessionLog
    {
        public DateTime SessionStartTime;
        public DateTime SessionEndTime;
        public List<LogEvent> EventsList;

        public SessionLog()
        {
            SessionStartTime = default(DateTime);
            SessionEndTime = default(DateTime);
            EventsList = new List<LogEvent>();
        }
    }
}
