using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConnectingDB.Models
{
    
    public class User
    {
        [Key]
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Group { get; set; }
    }
    public partial class ConnectDB : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
   
}
