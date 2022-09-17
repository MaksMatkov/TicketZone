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

            CreateMap<Film, FilmViewModel>()
                .ForMember("ID", el => el.MapFrom(v => v.ID))
                .ForMember("Name", el => el.MapFrom(v => v.Name))
                .ForMember("Description", el => el.MapFrom(v => v.Description))
                .ForMember("PosterUrl", el => el.MapFrom(v => v.PosterUrl))
                .ForMember("TrailerUrl", el => el.MapFrom(v => v.TrailerUrl)).ReverseMap();

            CreateMap<Room, RoomViewModel>()
                .ForMember("ID", el => el.MapFrom(v => v.ID))
                .ForMember("Number", el => el.MapFrom(v => v.Number))
                .ForMember("SeatsCount", el => el.MapFrom(v => v.SeatsCount)).ReverseMap();
        }
    }
}
