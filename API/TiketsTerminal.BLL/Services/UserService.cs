using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.Bll.Interfaces;
using TiketsTerminal.BLL.ViewModels;
using TiketsTerminal.DAL.Infrastructure;
using TiketsTerminal.Domain.Models;
using TiketsTerminal.Domain.Models.ValueModels;

namespace TiketsTerminal.BLL.Services
{
    public class UserService : IUserService
    {
        public readonly UnitOfWork uow;
        public readonly AutoMapper.IMapper mapper;

        public UserService(UnitOfWork _uow, AutoMapper.IMapper _mapper)
        {
            uow = _uow;
            mapper = _mapper;
        }

        public UserViewModel Get(int id)
        {
            return mapper.Map<UserViewModel>(uow.UserRepository.Get(id));
        }

        public List<UserViewModel> GetAll()
        {
            return mapper.Map<List<UserViewModel>>(uow.UserRepository.GetAll());
        }

        public void RegisterNewUser(UserViewModel user)
        {
            if(user.FK_Role == Domain.Enums.Role.Admin)
                throw new ArgumentException("Role is not valid");

            var RegData = new RegData(
                new Email(user.Email),
                new Password(user.Password),
                new Role((int)user.FK_Role),
                user.ID, user.Name);
            var User = new User(RegData);
            uow.UserRepository.Save(User);
            uow.SaveChnages();
        }

        public void Save(UserViewModel user)
        {
            var RegData = new RegData(
                new Email(user.Email),
                new Password(user.Password),
                new Role((int)user.FK_Role),
                user.ID, user.Name);
            var User = new User(RegData);
            uow.UserRepository.Save(User);
            uow.SaveChnages();
        }

        public void Delete(UserViewModel item)
        {
            uow.UserRepository.Delete(mapper.Map<User>(item));
            uow.SaveChnages();
        }

        public UserViewModel GetForAuthenticate(string email, string password)
        {
            return mapper.Map<UserViewModel>(uow.UserRepository.GetForAuthenticate(email, password));
        }
    }
}
