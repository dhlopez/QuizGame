using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace QuestionsGame.UWP
{
    class SQLite_UWP : ISQLite
    {
        public SQLite_UWP() { }

        #region ISQLite implementation
        SQLiteAsyncConnection ISQLite.GetConnection()
        {
            var sqliteFilename = "QGame.db3";
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);

            var conn = new SQLiteAsyncConnection(/*new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), */path);

            // Return the database connection 
            return conn;
        }
        #endregion
    }
}
