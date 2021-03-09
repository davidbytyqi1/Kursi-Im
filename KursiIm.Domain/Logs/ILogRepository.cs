using KursiIm.Domain.KursiIm;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace KursiIm.Domain.Logs
{
    public interface ILogRepository
    {
        void AddLogUserAuhtorization(LogUserAuthorization _);
        IEnumerable<LogUserAuthorization> GetLogUserAuthorizationsByIdUser(int idUser);
        IEnumerable<LogUserAuthorization> GetLogUserAuthorizations();
        void AddLogFailedAuthentication(LogFailedAuthentication _);
        IEnumerable<LogFailedAuthentication> GetLogFailedAuthentications(Expression<Func<LogFailedAuthentication, bool>> criteria);
        void AddLogDataChange(LogDataChange _);
        IEnumerable<LogDataChange> GetLogDataChanges();
        IEnumerable<LogDataChange> GetLogDataChanges(Expression<Func<LogDataChange, bool>> criteria);
        void AddLogUserActivity(LogUserActivity _);
        IEnumerable<LogUserActivity> GetLogUserActivitiesByIdUser(int idUser);
        IEnumerable<LogUserActivity> GetLogUserActivities();
        int GetTableByName(string TableName);
        IEnumerable<Tables> GetTables();
        IEnumerable<LogUserAuthorizationStatus> GetLogUserAuthorizationStatus();
        IEnumerable<LogUserActivityStatus> GetLogUserActivityStatus();
    }
}
