using AutoMapper;
using KursiIm.Business;
using KursiIm.Domain.Logs;
using KursiIm.Domain.Users;
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
    //private readonly ILogRepository _logRepository;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IMapper _mapper;
   // private readonly IGeneralService _generalService;

    public LogService(IUserRepoService userRepoService,
                     // ILogRepository logRepository,
                      IHttpContextAccessor contextAccessor,
                      IMapper mapper
                    //  IGeneralService generalService
                    )
    {
        _userRepoService = userRepoService;
       // _logRepository = logRepository;
        _contextAccessor = contextAccessor;
        _mapper = mapper;
        //_generalService = generalService;
    }

        public void AddLogDataChange(byte[] before, byte[] after, DataChangeStatus action, string TableName)
        {
            throw new NotImplementedException();
        }

        public void AddLogFailedAuthentication(string username)
        {
           // throw new NotImplementedException();
        }

        public void AddLogUserAuthorization(int authorizationStatus, bool isFromPortal)
        {
            throw new NotImplementedException();
        }

        public Response<LogUserAuthorization> SetLogUserAuthorization(int authorizationStatus, bool isFromPortal)
        {
            throw new NotImplementedException();
        }
    }
}
