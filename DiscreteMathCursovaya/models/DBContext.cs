using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscreteMathCursovaya.models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("workstation id=DescMathCurse.mssql.somee.com;packet size=4096;user id=azhidkov_SQLLogin_1;pwd=xjvn4dhqpx;data source=DescMathCurse.mssql.somee.com;persist security info=False;initial catalog=DescMathCurse;encrypt=true;trustServerCertificate=true;");
        }
    }
}
