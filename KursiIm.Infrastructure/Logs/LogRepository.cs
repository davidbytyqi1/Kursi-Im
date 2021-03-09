using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KursiIm.Domain.KursiIm;
using KursiIm.Domain.Logs;
using KursiIm.Domain.SeedWork;

namespace KursiIm.Infrastructure.Logs
{
    public class LogRepository : ILogRepository
    {
        private readonly IRepository<LogUserAuthorization> _logUserAuthorizationRepository;
        private readonly IRepository<LogFailedAuthentication> _logFailedAuthenticationRepository;
        private readonly IRepository<LogDataChange> _logDataChangeRepository;
        private readonly IRepository<LogUserAuthorizationStatus> _logUserAuthorizationStatusRepository;
        private readonly IRepository<LogUserActivityStatus> _logUserActivityStatusRepository;
        private readonly IRepository<LogUserActivity> _logUserActivityRepository;
        private readonly IRepository<Tables> _logTableRepository;
        public LogRepository(IRepository<LogUserAuthorization> logUserAuthorizationRepository,
                             IRepository<LogFailedAuthentication> logFailedAuthenticationRepository,
                             IRepository<LogDataChange> logDataChangeRepository,
                             IRepository<LogUserAuthorizationStatus> logUserAuthorizationStatusRepository,
                             IRepository<Tables> logTableRepository,
                             IRepository<LogUserActivityStatus> logUserActivityStatusRepository,
                             IRepository<LogUserActivity> logUserActivityRepository)
        {
            _logUserAuthorizationRepository = logUserAuthorizationRepository;
            _logFailedAuthenticationRepository = logFailedAuthenticationRepository;
            _logDataChangeRepository = logDataChangeRepository;
            _logUserActivityStatusRepository = logUserActivityStatusRepository;
            _logUserAuthorizationStatusRepository = logUserAuthorizationStatusRepository;
            _logUserActivityRepository = logUserActivityRepository;
            _logTableRepository = logTableRepository;
        }

        # region LogUserAuthorization
        public void AddLogUserAuhtorization(LogUserAuthorization _)
        {
            _logUserAuthorizationRepository.Add(_);
        }

        public IEnumerable<LogUserAuthorization> GetLogUserAuthorizationsByIdUser(int idUser) => _logUserAuthorizationRepository.ListByCriteria(_ => _.Iduser == idUser).OrderByDescending(d => d.Id);
        public IEnumerable<LogUserAuthorization> GetLogUserAuthorizations() => _logUserAuthorizationRepository.ListAll().OrderByDescending(d => d.Id);

        #endregion



        # region LogFailedAuthentication
        public void AddLogFailedAuthentication(LogFailedAuthentication _)
        {
            _logFailedAuthenticationRepository.Add(_);
        }

        public IEnumerable<LogFailedAuthentication> GetLogFailedAuthentications(Expression<Func<LogFailedAuthentication, bool>> criteria) => _logFailedAuthenticationRepository.ListByCriteria(criteria).OrderByDescending(d => d.Id);

        #endregion


        # region LogDataChange
        public void AddLogDataChange(LogDataChange _)
        {
            _logDataChangeRepository.Add(_);
        }

        public IEnumerable<LogDataChange> GetLogDataChanges(Expression<Func<LogDataChange, bool>> criteria) => _logDataChangeRepository.ListByCriteria(criteria, "IdlogBrowserTypeNavigation", "IdlogDataChangeStatusNavigation", "IdlogOperatingSystemTypeNavigation", "IdtableNavigation").OrderByDescending(d => d.Id);
        public IEnumerable<LogDataChange> GetLogDataChanges() => _logDataChangeRepository.ListAll("IdlogBrowserTypeNavigation", "IdlogDataChangeStatusNavigation", "IdlogOperatingSystemTypeNavigation").OrderByDescending(d => d.Id);

        #endregion


        #region LogUserActivity
        public void AddLogUserActivity(LogUserActivity _)
        {
            _logUserActivityRepository.Add(_);
        }

        public IEnumerable<LogUserActivity> GetLogUserActivitiesByIdUser(int idUser) => _logUserActivityRepository.ListByCriteria(_ => _.Iduser == idUser).OrderByDescending(d => d.Id);
        public IEnumerable<LogUserActivity> GetLogUserActivities() => _logUserActivityRepository.ListAll().OrderByDescending(d => d.Id);
        public IEnumerable<LogUserAuthorizationStatus> GetLogUserAuthorizationStatus() => _logUserAuthorizationStatusRepository.ListAll().OrderByDescending(d => d.Id);
        public IEnumerable<LogUserActivityStatus> GetLogUserActivityStatus() => _logUserActivityStatusRepository.ListAll().OrderByDescending(d => d.Id);

        public int GetTableByName(string TableName)
        {
            var table = _logTableRepository.ListByCriteria(x => x.Title == TableName).FirstOrDefault();
            if (table == null)
            {
                var model = new Tables()
                {
                    Title = TableName
                };
                _logTableRepository.Add(model);
                return model.Id;
            }
            return table.Id;
        }
        public IEnumerable<Tables> GetTables() => _logTableRepository.ListAll();

        #endregion


    }
}
