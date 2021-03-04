using AutoMapper;
using KursiIm.Domain.KursiIm;
using KursiIm.Domain.Users;
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
        }
    }
}
