using AutoMapper;
using KursiIm.Domain.KursiIm;
using KursiIm.Domain.Users;
using KursiIm.SharedModel.Administrations;
using KursiIm.SharedModel.General;
using KursiIm.SharedModel.Logs;
using KursiIm.SharedModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KursiImSource.Profiles
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CreateUserModel, User>().ReverseMap().ForMember(m => m.Password, a => a.Ignore());
            CreateMap<UserModel, User>().ReverseMap();
          //  CreateMap<NewPublicUserModel, User>().ReverseMap();
          //  CreateMap<RoleModel, Role>().ReverseMap();
           // CreateMap<NewRoleModel, Role>().ReverseMap();
          //  CreateMap<EditRoleModel, Role>().ReverseMap();
            CreateMap<DefinationBaseModel, RoleAuthorizationType>().ReverseMap();
            //CreateMap<RoleAuthorizationModel, RoleAuthorization>().ReverseMap();
           // CreateMap<NewRoleAuthorizationModel, RoleAuthorization>().ReverseMap();
            CreateMap<DefinationBaseModel, Module>().ReverseMap();
            CreateMap<DefinationBaseModel, UserAuthorizationType>().ReverseMap();
          //  CreateMap<DefinationBaseModel, UserList>().ReverseMap();
            CreateMap<LogWithIdUser, LogUserAuthorization>().ReverseMap();
            CreateMap<LogWithIdEntryUser, LogDataChange>().ReverseMap();
            CreateMap<LogWithIdEntryUser, LogUserActivity>().ReverseMap();
            CreateMap<LogWithAccount, LogFailedAuthentication>().ReverseMap();
            CreateMap<LogDataChangeModel, LogDataChange>().ReverseMap();
            CreateMap<ExportLogDataChange, LogDataChange>().ReverseMap();
          //  CreateMap<ActivityTypeModel, ActivityType>().ReverseMap();
          //  CreateMap<RoleViewAccess, RoleAuthorization>().ReverseMap();
          //  CreateMap<RoleViewAccess, UserAuthorization>().ReverseMap();
            CreateMap<TableModel, Tables>().ReverseMap();
            CreateMap<LogUserAuthorizationStatusModel, LogUserAuthorizationStatus>().ReverseMap();
            CreateMap<LogUserActivityStatusModel, LogUserActivityStatus>().ReverseMap();


           // CreateMap<ModuleModel, Module>().ReverseMap();



            CreateMap<LogUserAuthorization, LogUserAuthorizationModel>()
                .ForMember(dest => dest.LogBrowserType, opt => opt.MapFrom(src => src.IDLogBrowserTypeNavigation.Title))
                .ForMember(dest => dest.LogUserAuthorizationStatus, opt => opt.MapFrom(src => src.IDLogUserAuthorizationStatusNavigation.Title))
                .ForMember(dest => dest.LogOperatingSystemType, opt => opt.MapFrom(src => src.IDLogOperatingSystemTypeNavigation.Title));

            CreateMap<LogUserActivity, LogUserActivityModel>()
                .ForMember(dest => dest.LogBrowserType, opt => opt.MapFrom(src => src.IDLogBrowserTypeNavigation.Title))
                .ForMember(dest => dest.LogUserActivityStatus, opt => opt.MapFrom(src => src.IDLogUserActivityStatusNavigation.Title))
                .ForMember(dest => dest.LogOperatingSystemType, opt => opt.MapFrom(src => src.IDLogOperatingSystemTypeNavigation.Title))
                .ForMember(dest => dest.Module, opt => opt.MapFrom(src => src.IDModuleNavigation.Title));

            CreateMap<LogFailedAuthentication, LogFailedAuthenticationModel>()
             .ForMember(dest => dest.LogBrowserType, opt => opt.MapFrom(src => src.IDLogBrowserTypeNavigation.Title))
             .ForMember(dest => dest.LogOperatingSystemType, opt => opt.MapFrom(src => src.IDLogOperationSystemTypeNavigation.Title));

          
        }
    }
}
