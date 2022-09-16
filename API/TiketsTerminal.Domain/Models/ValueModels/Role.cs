using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiketsTerminal.Domain.Models.ValueModels
{
    public class Role
    {
        public Role(int id)
        {
            if (!IsValid(id))
                throw new ArgumentException("Role is not valid");
            Value = (Enums.Role)id;
        }

        public Role(Enums.Role id)
        {
            Value = id;
        }

        public bool IsValid(int id)
        {
            return System.Enum.IsDefined(typeof(Enums.Role), id);
        }

        public Enums.Role Value { get; private set; }
    }
}
