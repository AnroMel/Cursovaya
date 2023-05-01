﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LibraryConnectingDB.Models
{
    public class StudentWrite
    {
            public int? LessonsId { get; set; }
            public int? StudentId { get; set; }
            public int CountAttempt { get; set; }
            public decimal Mark;
    }
    public partial class ConnectDB : DbContext
    {
        public DbSet<StudentWrite> Write { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentWrite>().HasKey(w => new {w.StudentId , w.LessonsId});
            modelBuilder.Entity<StudentReply>().HasKey(r => new { r.StudentId, r.TaskId });
        }
    }
}
