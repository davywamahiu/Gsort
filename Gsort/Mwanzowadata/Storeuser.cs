using System.Threading;
using Android.Content;
using Android.Database.Sqlite;

namespace Gsort.Mwanzowadata
{  

    public class Nakuru
    {
        public static object locker = new object();
        private MkaaziWaNakuru _helper;
        public void SetContext(Context context)
        {
            if (context != null)
            {
                _helper = new MkaaziWaNakuru(context);
            }
        }
        public long RegisterOnClick(Mwananchi addCust)
        {
             using (var db = new SQLite.SQLiteConnection(_helper.WritableDatabase.Path))
             {
                 try
                 {
                    lock(locker)
                    {
                        return db.Insert(addCust);
                    }
                 }
                 catch (SQLiteDiskIOException)
                 {
                     Thread.Sleep(500);
                     return RegisterOnClick(addCust);
                     //exception handling code to go here
                 }
                 finally
                 {
                    db.ToString();
                 }
             }
        }
        public Mwananchi LoginOnClick(string Phone, string Password)
        {
            using (var database = new SQLite.SQLiteConnection(_helper.ReadableDatabase.Path))
            {
                try
                {
                    lock (locker)
                    {
                        return database.Table<Mwananchi>().FirstOrDefault(u => u.Phone == Phone && u.Password == Password);
                    }
                }
                catch (SQLiteException)
                {
                    Thread.Sleep(500);
                    return LoginOnClick(Phone,Password);
                    //exception handling code to go here
                }
            }
        }
    }
}