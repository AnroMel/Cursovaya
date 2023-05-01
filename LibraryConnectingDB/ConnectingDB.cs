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

        //public void AddLessonToDB(Lesson lesson)
        //{
        //    using (var db = new ConnectDB())
        //    {
        //        db.Lessons.Add(lesson);
        //        try
        //        {
        //            while (true)
        //            {
        //                db.SaveChanges();
        //                break;
        //            }
        //        }
        //        catch (Exception) { }
        //    }
        //}
        public void AddWriteToDB(StudentWrite WriteTest)
        {
            using (var db = new ConnectDB())
            {
                db.Write.Add(WriteTest);

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
        public void AddTaskToDB(StudentTask Task)
        {
            using (var db = new ConnectDB())
            {
                db.Task.Add(Task);

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