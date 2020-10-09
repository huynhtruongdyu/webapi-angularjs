namespace _1.Core.Domain
{
    public class Log : BaseEntity
    {
        public string Title { get; set; }
        public string Method { get; set; }
        public string Stacktrace { get; set; }
        public string Description { get; set; }
        public string IpAddress { get; set; }
        public string UserName { get; set; }
        public string ReferrerUrl { get; set; }
        public string ApiRequest { get; set; }
        public string ApiResponse { get; set; }
        public LogLevel LogLevel { get; set; }
        public LogType LogType { get; set; }
        public string Xid { get; set; }
    }

    public enum LogLevel
    {
        Error = 1,
        Debug = 2,
        Warning = 3,
        Information = 4
    }

    public enum LogType
    {
        ScheduleTask = 1,
        WebRequest = 2,
        ThirdParty = 3
    }
}