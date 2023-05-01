using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConnectingDB.Models
{
    public class StudentReply
    {
        public int? score { get; set; }
        public int StudentId { get; set; }
        public int TaskId { get; set; }
       
    }
    public partial class ConnectDB : DbContext
    {
        public DbSet<StudentReply> Reply { get; set; }
        
    }
}
