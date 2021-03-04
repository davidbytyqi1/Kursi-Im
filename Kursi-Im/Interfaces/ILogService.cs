using KursiIm.Business;
using KursiIm.Domain.KursiIm;
using KursiIm.Domain.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KursiImSource.Interfaces
{
    public interface ILogService
    {
        void AddLogUserAuthorization(int authorizationStatus, bool isFromPortal);
        void AddLogFailedAuthentication(string username);
        Response<LogUserAuthorization> SetLogUserAuthorization(int authorizationStatus, bool isFromPortal);
        void AddLogDataChange(byte[] before, byte[] after, DataChangeStatus action, string TableName);
    }
}
