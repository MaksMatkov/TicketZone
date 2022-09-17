using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.BLL.ViewModels;

namespace TiketsTerminal.BLL.Interfaces
{
    public interface IRoomService
    {
        public RoomViewModel Get(int id);

        public List<RoomViewModel> GetAll();

        public void Save(RoomViewModel item);

        public void Delete(RoomViewModel item);
    }
}
