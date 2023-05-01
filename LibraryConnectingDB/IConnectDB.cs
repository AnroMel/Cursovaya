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
        User FirstOrDefaultLoginAndPassword(string Login, string password);
    }
}
