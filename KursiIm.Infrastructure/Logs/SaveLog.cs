using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using KursiIm.Domain.Logs;

namespace KursiIm.Infrastructure.Logs
{
    public class SaveLog : ISaveLog
    {
        private readonly ILogger<SaveLog> _logger;
        public SaveLog(ILogger<SaveLog> logger)
        {
            _logger = logger;
        }

        public void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }

        public void LogWarning(string message)
        {
            _logger.LogWarning(message);
        }

        public void LogError(string message)
        {
            _logger.LogError(message);
        }

        public void LogError(Exception exception, string message)
        {
            _logger.LogError(exception, message);
        }

    }
}
