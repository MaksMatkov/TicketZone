using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiketsTerminal.API.DTOs;
using TiketsTerminal.Domain.Enums;
using TiketsTerminal.Domain.Models;

namespace TiketsTerminal.API.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, AddUserResponse>()
                .ForMember("id", el => el.MapFrom(v => v.ID))
                .ForMember("name", el => el.MapFrom(v => v.Name)).ReverseMap();

            CreateMap<AddUserRequest, User>()
                .ForMember("Name", el => el.MapFrom(v => v.name))
                .ForMember("Password", el => el.MapFrom(v => v.password))
                .ForMember("Email", el => el.MapFrom(v => v.email)).ReverseMap();

            CreateMap<User, GetUserResponse>()
                .ForMember("id", el => el.MapFrom(v => v.ID))
                .ForMember("name", el => el.MapFrom(v => v.Name))
                .ForMember("isApproved", el => el.MapFrom(v => v.IsApproved))
                .ForMember("email", el => el.MapFrom(v => v.Email)).ReverseMap();

            //Film
            CreateMap<Film, GetFilmResponse>()
                .ForMember("id", el => el.MapFrom(v => v.ID))
                .ForMember("name", el => el.MapFrom(v => v.Name))
                .ForMember("description", el => el.MapFrom(v => v.Description))
                .ForMember("trailerUrl", el => el.MapFrom(v => v.TrailerUrl))
                .ForMember("posterUrl", el => el.MapFrom(v => v.PosterUrl))
                .ReverseMap();

            CreateMap<Film, GetFilmLiteResponse>()
               .ForMember("id", el => el.MapFrom(v => v.ID))
               .ForMember("name", el => el.MapFrom(v => v.Name))
               .ForMember("posterUrl", el => el.MapFrom(v => v.PosterUrl))
               .ReverseMap();


            CreateMap<AddFilmRequest, Film>()
               .ForMember("Name", el => el.MapFrom(v => v.name))
               .ForMember("Description", el => el.MapFrom(v => v.description))
               .ForMember("TrailerUrl", el => el.MapFrom(v => v.trailerUrl))
               .ForMember("PosterUrl", el => el.MapFrom(v => v.posterUrl))
               .ReverseMap();

            CreateMap<Film, AddFilmResponse>()
               .ForMember("id", el => el.MapFrom(v => v.ID))
               .ForMember("name", el => el.MapFrom(v => v.Name))
               .ReverseMap();
            

            //viewing times
            CreateMap<FilmViewingTime, GetFilmViewingTimeLiteResponse>()
                .ForMember("id", el => el.MapFrom(v => v.ID))
                .ForMember("date", el => el.MapFrom(v => v.Date))
                .ReverseMap();

            CreateMap<FilmViewingTime, AddFilmViewingTimeResponse>()
                .ForMember("id", el => el.MapFrom(v => v.ID))
                .ForMember("date", el => el.MapFrom(v => v.Date))
                .ReverseMap();

            CreateMap<AddFilmViewingTimeRequest, FilmViewingTime>()
                .ForMember("Date", el => el.MapFrom(v => v.date))
                .ForMember("FK_Room", el => el.MapFrom(v => v.roomId))
                .ForMember("FK_Film", el => el.MapFrom(v => v.filmId))
                .ReverseMap();

            CreateMap<FilmViewingTime, GetFilmViewingTimeResponse>()
                .ForMember("id", el => el.MapFrom(v => v.ID))
                .ForMember("date", el => el.MapFrom(v => v.Date))
                .ForMember("roomNumber", el => el.MapFrom(v => (v.Room != null) ? v.Room.Number : 0))
                .ForMember("roomId", el => el.MapFrom(v => (v.Room != null) ? v.Room.ID : 0))
                .ForMember("ordersCount", el => el.MapFrom(v => (v.TicketOrders != null) ? v.TicketOrders.Where(el => el.Status != Status.Rejected).Count() : 0))
                .ForMember("seatsCount", el => el.MapFrom(v => (v.Room != null) ? v.Room.SeatsCount : 0))
                .ForMember("filmId", el => el.MapFrom(v => v.FK_Film))
                .ReverseMap();

            //Room
            CreateMap<Room, AddRoomResponse>()
                .ForMember("id", el => el.MapFrom(v => v.ID))
                .ForMember("number", el => el.MapFrom(v => v.Number)).ReverseMap();

            CreateMap<AddRoomRequest, Room>()
                .ForMember("Number", el => el.MapFrom(v => v.number))
                .ForMember("SeatsCount", el => el.MapFrom(v => v.seatsCount))
                .ReverseMap();

            CreateMap<Room, GetRoomResponse>()
                .ForMember("id", el => el.MapFrom(v => v.ID))
                .ForMember("number", el => el.MapFrom(v => v.Number))
                .ForMember("seatsCount", el => el.MapFrom(v => v.SeatsCount))
                .ReverseMap();


            //ticket order
            CreateMap<AddTicketOrderRequest, TicketOrder>()
                .ForMember("FK_Film_Viewing_Time", el => el.MapFrom(v => v.filmViewingTimeId))
                .ReverseMap();

            CreateMap<TicketOrder, AddTicketOrderResponse>()
                .ForMember("id", el => el.MapFrom(v => v.ID))
                .ReverseMap();

            CreateMap<TicketOrder, GetTicketOrderLiteResponse>()
                .ForMember("id", el => el.MapFrom(v => v.ID))
                .ForMember("userId", el => el.MapFrom(v => v.FK_User))
                .ForMember("filmViewingTimeId", el => el.MapFrom(v => v.FK_Film_Viewing_Time))
                .ForMember("creationDate", el => el.MapFrom(v => v.CreationDate))
                .ForMember("status", el => el.MapFrom(v => v.Status))
                .ReverseMap();

        }
    }
}
