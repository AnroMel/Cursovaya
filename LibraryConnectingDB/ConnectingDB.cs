using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using LibraryConnectingDB.Models;
using System.Reflection;

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
        public Lesson FirstOrDefaultCodLesson(int moduleID, int Numb)
        {
            using (var db = new ConnectDB())
            {

                Lesson lesson = db.Lessons.FirstOrDefault(i => i.ModuleId == moduleID && i.Numb == Numb);
                return lesson;

            }
        }


        public User FirstOrDefaultLoginAndPassword(string Login, string password)
        {
            using (var db = new ConnectDB())
            {
                User user;
                while (true)
                {
                    try
                    {
                        user = db.Users.FirstOrDefault(i => i.Login == Login && i.Password == password);
                        return user;
                    }
                    catch (Exception) { }
                }
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
                StudentWrite write = db.Write.FirstOrDefault(i => i.StudentId == user.Id && i.LessonId == lesson.Code);
                return write;
            }
        }

        public void UpdateWriteMarkAndCount(StudentWrite write, decimal mark)
        {
            using (var db = new ConnectDB())
            {
                var StudWrite = db.Write.FirstOrDefault(i => i.LessonId == write.LessonId && i.StudentId == write.StudentId);
                
                if (write.CountAttempt == 0)
                {
                    StudWrite.Mark = decimal.Multiply(mark, 0.9m);

                }
                if (write.CountAttempt == 1)
                {
                    StudWrite.Mark = decimal.Multiply(mark, 0.8m);
                }
                StudWrite.CountAttempt = StudWrite.CountAttempt + 1;
                db.Write.Update(StudWrite);
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

        public int GetModuleCount()
        {
            using (var db = new ConnectDB())
            {
                return db.Module.Count();
            }
        }

        public int GetModuleLessonsCount(int moduleid)
        {
            using (var db = new ConnectDB())
            {
                return db.Lessons.Count(l => l.ModuleId == moduleid);
            }
        }
        //public void DecreaseWriteMark(StudentWrite write)
        //{
        //    using (var db = new ConnectDB())
        //    {//Попытка может и ноль потом решим
        //        if (write.CountAttempt == 1)
        //        {
        //            write.Mark = decimal.Multiply(write.Mark,0.8m);
        //        }
        //        if(write.CountAttempt == 2)
        //        {
        //            write.Mark = decimal.Multiply(write.Mark, 0.6m);
        //        }
        //        db.SaveChanges();
        //    }
        //}


        public void UpdatePassword(string login, string HashPassword)
        {
            using (var db = new ConnectDB())
            {
                User user = FirstOrDefault(login);
                user.Password= HashPassword;
                db.Users.Update(user);
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