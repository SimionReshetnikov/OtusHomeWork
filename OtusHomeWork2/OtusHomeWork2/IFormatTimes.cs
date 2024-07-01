using System;

namespace OtusHomeWork2
{
    public interface IFormatTimes
    {
        public static string FormatTime(TimeSpan time)
        {
            return $"{time.Hours:00}h:{time.Minutes:00}m:{time.Seconds:00}s:{time.Milliseconds:00}ms";
        }
    }
}
