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
    }
}
