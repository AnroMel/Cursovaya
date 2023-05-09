using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using LibraryConnectingDB.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryConnectingDB
{
    public interface IConnectDB
    {
        void AddUserToDB(User user);
        void AddWriteToDB(StudentWrite WriteTest);
        void AddTaskToDB(StudentTask Task);

        User FirstOrDefault(string login);
        Lesson FirstOrDefaultCodLesson(int moduleID, int Numb);
        User FirstOrDefaultLoginAndPassword(string Login, string password);
        StudentWrite FirstOrDefaultWrite(string login, int moduleId, int NumbLesson);

        int GetModuleCount();
        int GetModuleLessonsCount(int moduleid);

        void UpdatePassword(string login, string HashPassword);
        void UpdateWriteMarkAndCount(StudentWrite write, decimal mark);
        //void DecreaseWriteMark(StudentWrite write);

    }
}
