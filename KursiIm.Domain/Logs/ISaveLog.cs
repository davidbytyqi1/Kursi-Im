using System;
using System.Collections.Generic;
using System.Text;

namespace KursiIm.Domain.Logs
{
    public interface ISaveLog
    {
        void LogInformation(string message);
        void LogWarning(string message);
        void LogError(string message);
        void LogError(Exception exception, string message);
    }
}
