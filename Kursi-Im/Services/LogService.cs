﻿using AutoMapper;
using KursiIm.Business;
using KursiIm.Domain.KursiIm;
using KursiIm.Domain.Logs;
using KursiIm.Domain.Users;
using KursiIm.SharedModel.General;
using KursiIm.SharedModel.Logs;
using KursiImSource.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KursiImSource.Services
{
    public class LogService : ILogService
    {
        private readonly IUserRepoService _userRepoService;
        private readonly ILogRepository _logRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;
        // private readonly IGeneralService _generalService;

        public LogService(IUserRepoService userRepoService,
                          ILogRepository logRepository,
                          IHttpContextAccessor contextAccessor,
                          IMapper mapper
                        //  IGeneralService generalService
                        )
        {
            _userRepoService = userRepoService;
            _logRepository = logRepository;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
            //_generalService = generalService;
        }

        public void AddLogDataChange(byte[] before, byte[] after, DataChangeStatus action, string TableName)
        {
            var IdTable = _logRepository.GetTableByName(TableName);
            var entryUser = _userRepoService.GetUserByUsername(_contextAccessor.HttpContext.User?.Identity?.Name);
            var logDataChange = new LogDataChange
            {
                EntryDate = DateTime.Now,
                IdentryUser = entryUser != null ? entryUser.Id : 999999,
                EntryUser = entryUser != null ? entryUser.Account : "public",
                Before = before,
                After = after,
                Idtable = IdTable,
                ComputerName = NetworkHelper.GetComputerName(),
                Idaddress = NetworkHelper.GetIPAddress(),
                IdlogBrowserType = NetworkHelper.GetBrowserTypeId(),
                IdlogOperatingSystemType = NetworkHelper.GetOperatingSystemTypeId(),
                IsMobileDevice = NetworkHelper.IsMobileDevice(),
                IdlogDataChangeStatus = (int)action
            };
            _logRepository.AddLogDataChange(logDataChange);
        }

        public void AddLogFailedAuthentication(string username)
        {
            var logFailedAuth = new LogFailedAuthentication
            {
                Account = username,
                ComputerName = NetworkHelper.GetComputerName(),
                Ipaddress = NetworkHelper.GetIPAddress(),
                IdlogBrowserType = NetworkHelper.GetBrowserTypeId(),
                IdlogOperationSystemType = NetworkHelper.GetOperatingSystemTypeId(),
                IsMobileDevice = NetworkHelper.IsMobileDevice(),
                EntryDate = DateTime.Now
            };

            _logRepository.AddLogFailedAuthentication(logFailedAuth);
        }

        public void AddLogUserAuthorization(int authorizationStatus, bool isFromPortal)
        {
            var entryUser = isFromPortal ?
                            _userRepoService.GetUserByUsernamePortal(_contextAccessor.HttpContext.User.Identity.Name) :
                            _userRepoService.GetUserByUsername(_contextAccessor.HttpContext.User.Identity.Name);

            var logUserAuth = new LogUserAuthorization
            {
                Iduser = entryUser.Id,
                EntryDate = DateTime.Now,
                ComputerName = NetworkHelper.GetComputerName(),
                Ipaddress = NetworkHelper.GetIPAddress(),
                IdlogBrowserType = NetworkHelper.GetBrowserTypeId(),
                IdlogOperatingSystemType = NetworkHelper.GetOperatingSystemTypeId(),
                IsMobileDevice = NetworkHelper.IsMobileDevice(),
                IdlogUserAuthorizationStatus = authorizationStatus,
                EntryUser = entryUser.Account
            };

            _logRepository.AddLogUserAuhtorization(logUserAuth);
        }

        public Response<LogUserAuthorization> SetLogUserAuthorization(int authorizationStatus, bool isFromPortal)
        {
            AddLogUserAuthorization(authorizationStatus, isFromPortal);
            return new Response<LogUserAuthorization>(PublicResultStatusCodes.Done);
        }

        public void AddLogUserActivity(int idModule, int logUserActivityStatus, string Host, bool isPublic)
        {
            var entryUser = _userRepoService.GetUserByUsername(_contextAccessor.HttpContext.User.Identity.Name);
            var logDataChange = new LogUserActivity
            {
                EntryDate = DateTime.Now,
                Iduser = entryUser.Id,
                EntryUser = entryUser.Account,
                ComputerName = NetworkHelper.GetComputerName(),
                Ipaddress = NetworkHelper.GetIPAddress(),
                IdlogBrowserType = NetworkHelper.GetBrowserTypeId(),
                IdlogOperatingSystemType = NetworkHelper.GetOperatingSystemTypeId(),
                Idmodule = idModule,
                IsPublic = isPublic,
                Url = Host,
                IsMobileDevice = NetworkHelper.IsMobileDevice(),
                IdlogUserActivityStatus = logUserActivityStatus
            };
            _logRepository.AddLogUserActivity(logDataChange);
        }

        public Response<LogUserActivity> SetLogUserActivity(LogActivityModel _)
        {
            AddLogUserActivity(_.IdModule, _.ActivityStatus, _.Host, _.IsPublic);
            return new Response<LogUserActivity>(PublicResultStatusCodes.Done);
        }

        public IEnumerable<LogWithIdEntryUser> GetLogActivities(int idUser) => _mapper.Map<IList<LogWithIdEntryUser>>(_logRepository.GetLogUserActivitiesByIdUser(idUser));
        public IEnumerable<LogWithIdEntryUser> GetLogActivities() => _mapper.Map<IList<LogWithIdEntryUser>>(_logRepository.GetLogUserActivities());

        public Response<LogWithIdEntryUser> GetResponseLogActivities(int idUser) => new Response<LogWithIdEntryUser>(PublicResultStatusCodes.Done, GetLogActivities(idUser).ToList());

        public Response<TableModel> GetTables()
        {
            return new Response<TableModel>(PublicResultStatusCodes.Done, _mapper.Map<IList<TableModel>>(_logRepository.GetTables()).ToList());
        }

    }
}
