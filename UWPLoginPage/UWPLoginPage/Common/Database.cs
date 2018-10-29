using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPLoginPage.Common
{
    public class Database
    {
        string path;
        SQLiteConnection cnn;

        public Database()
        {
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "MyDatabase.sqlite");
            cnn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            //Create table
            cnn.CreateTable<User>();
        }
        public int Register(User user)
        {
            return cnn.Insert(new User() {
                UserName = user.UserName,
                Password = user.Password,
                Email = user.Email
            });
        }

        public bool Login(string user, string password)
        {
            var query = cnn.Table<User>().Where(t => t.UserName == user && t.Password == password);

            if (query.Count() > 0)
                return true;
            else
                return false;
        }
    }
}
