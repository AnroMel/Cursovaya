using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using LibraryConnectingDB.Models;

namespace LibraryConnectingDB
{
    public partial class ConnectingDB : IConnectDB
    {
        public void AddUserToDB(User user)
        {
            using (var db = new ConnectDB())
            {
                db.Users.Add(user);

                try
                {
                    while (true)
                    {
                        db.SaveChanges();
                        break;
                    }
                }
                catch (Exception) { }
            }
        }

        public void AddLessonToDB(Lesson lesson)
        {
            using (var db = new ConnectDB())
            {
                db.Lessons.Add(lesson);
                try
                {
                    while (true)
                    {
                        db.SaveChanges();
                        break;
                    }
                }
                catch (Exception) { }
            }
        }
    }
    

}