using System;
using System.Collections.Generic;
using System.Threading;
using Android.Content;
using Android.Database.Sqlite;

namespace Gsort.Mwanzowadata
{

    public class Message
    {
        public static object locker = new object();
        private Hospital _helper;
        public void SetContext(Context context)
        {
            if (context != null)
            {
                _helper = new Hospital(context);
            }
        }
        public long AddMessage(Mwananchi addCust)
        {
            using (var db = new SQLite.SQLiteConnection(_helper.WritableDatabase.Path))
            {
                try
                {
                    lock (locker)
                    {
                        return db.Insert(addCust);
                    }
                }
                catch (SQLiteDiskIOException)
                {
                    Thread.Sleep(500);
                    return AddMessage(addCust);
                    //exception handling code to go here
                }
                finally
                {
                    db.ToString();
                }
            }
        }
    }
}
        /*public Mwananchi LoginOnClick(string Phone, string Password)  
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
                    return LoginOnClick(Phone, Password);
                    //exception handling code to go here
                }
            }
        }*///retrieve a specific user by querying against their first name
        /*public Message GetUser(string firstname)
        {
            using (var database = new SQLite.SQLiteConnection(_helper.ReadableDatabase.Path))
            {
                try
                {
                    return database.Table<Mwananch>().FirstOrDefault(u => u.Message == firstname);
                }
                catch (SQLiteException)
                {
                    Thread.Sleep(500);
                    return GetUser(firstname);
                    //exception handling code to go here
                }
            }
        }*/

        //retrieve a list of all customers
  /*      public IList<Mwananch> GetAllCustomers()
        {
            using (var database = new SQLite.SQLiteConnection(_helper.ReadableDatabase.Path))
            {
                try
                {
                    return database.Table<Mwananch>().ToList();
                }
                catch (SQLiteException)
                {
                    Thread.Sleep(500);
                    return GetAllCustomers();
                    //exception handling code to go here
                }
            }
        }
    }
}*/