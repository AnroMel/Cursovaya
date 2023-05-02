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
    public class StudentTask
    {
        [Key]
        public int Code { get; set; }
        public int LessonId { get; set; }
        public string? Answer { get; set; }
        public string? Question { get; set; }
    }
    public partial class ConnectDB : DbContext
    {
        public DbSet<StudentTask> Task { get; set; }
    }
}
