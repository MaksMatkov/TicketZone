using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.Domain.Enums;

namespace TiketsTerminal.Infrastucture.Infrastructure
{
    public class ConnectionStringsConfiguration
    {
        public string msSqlConnectionString { get; set; }
        public string sqlLiteConnectionString { get; set; }
        public DbType DbType { get; set; }
    }
}
