using AutoMapper;
using GM.Core.Domain;
using GM.Core.Shared.ModelViews.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GM.Manager.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserView>().ReverseMap();
            CreateMap<User, NewUser>().ReverseMap();
            CreateMap<User, UserLogged>().ReverseMap();
            CreateMap<Role, RoleView>().ReverseMap();
            CreateMap<Role, ReferenceRole>().ReverseMap();
        }
    }
}
