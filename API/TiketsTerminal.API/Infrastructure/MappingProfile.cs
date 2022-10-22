using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiketsTerminal.API.DTOs;
using TiketsTerminal.Domain.Models;

namespace TiketsTerminal.API.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, AddUserResponse>()
                .ForMember("Id", el => el.MapFrom(v => v.ID))
                .ForMember("Name", el => el.MapFrom(v => v.Name)).ReverseMap();

            CreateMap<AddUserRequest, User>()
                .ForMember("Name", el => el.MapFrom(v => v.Name))
                .ForMember("Password", el => el.MapFrom(v => v.Password))
                .ForMember("Email", el => el.MapFrom(v => v.Email)).ReverseMap();

            CreateMap<User, GetUserResponse>()
                .ForMember("ID", el => el.MapFrom(v => v.ID))
                .ForMember("Name", el => el.MapFrom(v => v.Name))
                .ForMember("IsApproved", el => el.MapFrom(v => v.IsApproved))
                .ForMember("Email", el => el.MapFrom(v => v.Email)).ReverseMap();

            //Film
            CreateMap<Film, GetFilmResponse>()
                .ForMember("ID", el => el.MapFrom(v => v.ID))
                .ForMember("Name", el => el.MapFrom(v => v.Name))
                .ForMember("Description", el => el.MapFrom(v => v.Description))
                .ForMember("TrailerUrl", el => el.MapFrom(v => v.TrailerUrl))
                .ForMember("PosterUrl", el => el.MapFrom(v => v.PosterUrl))
                .ReverseMap();

            CreateMap<Film, GetFilmLiteResponse>()
               .ForMember("ID", el => el.MapFrom(v => v.ID))
               .ForMember("Name", el => el.MapFrom(v => v.Name))
               .ForMember("PosterUrl", el => el.MapFrom(v => v.PosterUrl))
               .ReverseMap();


            CreateMap<AddFilmRequest, Film>()
               .ForMember("Name", el => el.MapFrom(v => v.Name))
               .ForMember("Description", el => el.MapFrom(v => v.Description))
               .ForMember("TrailerUrl", el => el.MapFrom(v => v.TrailerUrl))
               .ForMember("PosterUrl", el => el.MapFrom(v => v.PosterUrl))
               .ReverseMap();

            CreateMap<Film, AddFilmResponse>()
               .ForMember("ID", el => el.MapFrom(v => v.ID))
               .ForMember("Name", el => el.MapFrom(v => v.Name))
               .ReverseMap();
            

            //viewing times
            CreateMap<FilmViewingTime, GetFilmViewingTimeLiteResponse>()
                .ForMember("ID", el => el.MapFrom(v => v.ID))
                .ForMember("Date", el => el.MapFrom(v => v.Date))
                .ReverseMap();

            CreateMap<FilmViewingTime, AddFilmViewingTimeResponse>()
                .ForMember("ID", el => el.MapFrom(v => v.ID))
                .ForMember("Date", el => el.MapFrom(v => v.Date))
                .ReverseMap();

            CreateMap<AddFilmViewingTimeRequest, FilmViewingTime>()
                .ForMember("Date", el => el.MapFrom(v => v.Date))
                .ForMember("FK_Room", el => el.MapFrom(v => v.FK_Room))
                .ForMember("FK_Film", el => el.MapFrom(v => v.FK_Film))
                .ReverseMap();

            CreateMap<FilmViewingTime, GetFilmViewingTimeResponse>()
                .ForMember("ID", el => el.MapFrom(v => v.ID))
                .ForMember("Date", el => el.MapFrom(v => v.Date))
                .ForMember("RoomNumber", el => el.MapFrom(v => (v.Room != null) ? v.Room.Number : 0))
                .ForMember("OrdersCount", el => el.MapFrom(v => (v.TicketOrders != null) ? v.TicketOrders.Count() : 0))
                .ForMember("SeatsCount", el => el.MapFrom(v => (v.Room != null) ? v.Room.SeatsCount : 0))
                .ReverseMap();

            //Room
            CreateMap<Room, AddRoomResponse>()
                .ForMember("ID", el => el.MapFrom(v => v.ID))
                .ForMember("Number", el => el.MapFrom(v => v.Number)).ReverseMap();

            CreateMap<AddRoomRequest, Room>()
                .ForMember("Number", el => el.MapFrom(v => v.Number))
                .ForMember("SeatsCount", el => el.MapFrom(v => v.SeatsCount))
                .ReverseMap();

            CreateMap<Room, GetRoomResponse>()
                .ForMember("ID", el => el.MapFrom(v => v.ID))
                .ForMember("Number", el => el.MapFrom(v => v.Number))
                .ForMember("SeatsCount", el => el.MapFrom(v => v.SeatsCount))
                .ReverseMap();


            //ticket order
            CreateMap<AddTicketOrderRequest, TicketOrder>()
                .ForMember("FK_Film_Viewing_Time", el => el.MapFrom(v => v.FK_Film_Viewing_Time))
                .ReverseMap();

            CreateMap<TicketOrder, AddTicketOrderResponse>()
                .ForMember("ID", el => el.MapFrom(v => v.ID))
                .ReverseMap();

        }
    }
}
