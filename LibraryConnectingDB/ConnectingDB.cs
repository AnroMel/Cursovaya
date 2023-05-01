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

        public User FirstOrDefault(string login)
        {
            using (var db = new ConnectDB())
            {

                User user = db.Users.FirstOrDefault(i => i.Login == login);
                return user;

            }
        }

        public User FirstOrDefaultLoginAndPassword(string Login, string password)
        {
            using (var db = new ConnectDB())
            {
                User user = db.Users.FirstOrDefault(i => i.Login == Login && i.Password == password);
                return user;
            }
        }

        public void AddReplyToDB(StudentReply reply)
        {
            using (var db = new ConnectDB())
            {
                db.Reply.Add(reply);

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

        public StudentWrite FirstOrDefaultWrite(string login, int moduleId, int NumbLesson)
        {
            using (var db = new ConnectDB())
            {

                User user = db.Users.FirstOrDefault(i => i.Login == login);  
                Lesson lesson = db.Lessons.FirstOrDefault(i => i.ModuleId == moduleId && i.Numb == NumbLesson);

                StudentWrite write = db.Write.FirstOrDefault(i => i.StudentId == user.Id && i.LessonsId == lesson.Code);
                return write;
            }

        }

        //public StudentWrite UpdateWriteCount( StudentWrite write)
        //{
        //    using (var db = new ConnectDB())
        //    {
        //        write.CountAttempt++;
        //        return write;

        //    }
        //}

        public void DecreaseWriteMark(StudentWrite write)
        {
            using (var db = new ConnectDB())
            {//Попытка может и ноль потом решим
                if (write.CountAttempt == 1)
                {
                    write.Mark = decimal.Multiply(write.Mark,0.8m);
                }
                if(write.CountAttempt == 2)
                {
                    write.Mark = decimal.Multiply(write.Mark, 0.6m);
                }

            }
        }
    }
}