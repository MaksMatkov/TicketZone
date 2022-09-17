using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.BLL.ViewModels;
using TiketsTerminal.Domain.Models;

namespace TiketsTerminal.Bll.Interfaces
{
    public interface IUserService
    {
        public UserViewModel Get(int id);

        public List<UserViewModel> GetAll();

        public void Save(UserViewModel item);
    
        public void Delete(UserViewModel item);
        public UserViewModel GetForAuthenticate(string email, string password);
        void RegisterNewUser(UserViewModel user);
        void RegisterNewAdmin(UserViewModel user);
    }
}
