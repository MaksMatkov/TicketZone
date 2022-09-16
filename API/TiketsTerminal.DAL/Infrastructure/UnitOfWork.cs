using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.Domain.Interfaces;

namespace TiketsTerminal.DAL.Infrastructure
{
    public class UnitOfWork
    {

        public readonly IUserRepository UserRepository;
        public UnitOfWork(IUserRepository _UserRepository)
        {
            UserRepository = _UserRepository;
        }
    }
}
