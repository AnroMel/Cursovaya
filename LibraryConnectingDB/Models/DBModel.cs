using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConnectingDB.Models
{
    public partial class ConnectDB : DbContext
    {
        public ConnectDB() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("workstation id=cursovaya.mssql.somee.com;packet size=4096;user id=Aleksandr_SQLLogin_1;pwd=dzhvb82x2m;data source=cursovaya.mssql.somee.com;persist security info=False;initial catalog=cursovaya;encrypt=true;trustServerCertificate=true;");
        }
    }
}
