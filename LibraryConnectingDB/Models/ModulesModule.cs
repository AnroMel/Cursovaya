using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConnectingDB.Models
{
    public class Module
    {
        [Key]
        public int id { get; set; }
        public partial class ConnectDB : DbContext
        {
            public DbSet<Module> Module { get; set; }
        }
    }
}
