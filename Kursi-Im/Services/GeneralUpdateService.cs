using KursiIm.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KursiImSource.Interfaces;
using KursiIm.Domain.Logs;

namespace KursiImSource.Services
{
    public class GeneralUpdateService<T> : IGeneralUpdateService<T> where T : BaseEntity
    {
        private readonly ILogService _logService;
        private readonly IRepository<T> _generalRepository;
        public GeneralUpdateService(ILogService logService,
                                    IRepository<T> generalRepository)
        {
            _logService = logService;
            _generalRepository = generalRepository;
        }
        public void UpdateAddLogDataChange(T entity, byte[] before, byte[] after)
        {
            _generalRepository.Update(entity);

            _logService.AddLogDataChange(before, after, DataChangeStatus.Edit, entity.GetType().Name);
        }

        public void DeleteAddLogDataChange(T entity, byte[] before, byte[] after)
        {
            _generalRepository.Delete(entity);

            _logService.AddLogDataChange(before, after, DataChangeStatus.Delete, entity.GetType().Name);
        }

        public void InsertAddLogDataChange(T entity, byte[] before, byte[] after = null)
        {
            try
            {
                _generalRepository.Add(entity);

                _logService.AddLogDataChange(before, after, DataChangeStatus.Insert, entity.GetType().Name);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
