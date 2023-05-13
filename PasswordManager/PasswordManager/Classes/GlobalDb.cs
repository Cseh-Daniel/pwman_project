using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Classes
{
    public static class GlobalDb
    {

        static public Database db;

        static GlobalDb()
        {
            db = new Database();
        }

    }
}
