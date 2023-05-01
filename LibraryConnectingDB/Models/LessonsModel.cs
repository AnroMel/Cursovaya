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
    public class Lesson
    {
        [Key]
        public int? Code { get; set; }
        public int ModuleId { get; set; }
        public int Numb { get; set; }
    }
    public partial class ConnectDB : DbContext
    {
        public DbSet<Lesson> Lessons { get; set; }
    }
}
