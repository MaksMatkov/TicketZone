using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiketsTerminal.BLL.ViewModels;
using TiketsTerminal.Domain.Models;

namespace TiketsTerminal.API.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>()
                .ForMember("ID", el => el.MapFrom(v => v.ID))
                .ForMember("Email", el => el.MapFrom(v => v.Email))
                .ForMember("Name", el => el.MapFrom(v => v.Name))
                .ForMember("FK_Role", el => el.MapFrom(v => v.FK_Role))
                .ForMember("Password", el => el.MapFrom(v => v.Password)).ReverseMap();
        }
    }
}
