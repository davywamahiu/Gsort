using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.Database.Sqlite;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Gsort.Mwanzowadata;

namespace Gsort
{
    class Nakuruc32
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
        public long RegisterOnClick(Mwananch1 tb1)
        {
            using (var db = new SQLite.SQLiteConnection(_helper.WritableDatabase.Path))
            {
                try
                {
                    lock (locker)
                    {
                        if (tb1.Id != 0)
                        {
                            return tb1.Id;
                        }
                        else
                        {
                            return db.Insert(tb1);
                        }
                    }
                }
                catch (SQLiteDiskIOException)
                {
                    Thread.Sleep(500);
                    return RegisterOnClick(tb1);
                    //exception handling code to go here
                }
                finally
                {
                    db.ToString();
                }
            }
        }
        public List<Mwananch1> LoginOnClick()
        {

            try
            {
                using (var database = new SQLite.SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Nakuruc32.db3")))
                {
                    lock (locker)
                    {
                        return database.Table<Mwananch1>().ToList();
                    }
                }

            }
            catch (SQLiteException ex)
            {
                Log.Info("Failed", ex.Message);
                return null;
                //exception handling code to go here
            }
        }
        public bool LoginOnClick(int Id)
        {

            try
            {
                using (var database = new SQLite.SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Nakuruc32.db3")))
                {
                    lock (locker)
                    {
                        database.Query<Mwananch1>("SELECT * FROM Mwananch1 WHERE Id=?", Id);
                        return true;
                    }
                }

            }
            catch (SQLiteException ex)
            {
                Log.Info("Failed", ex.Message);
                return false;
                //exception handling code to go here
            }
        }
        public bool RemoveOnClick(Mwananch1 mwananch2)
        {

            try
            {
                using (var database = new SQLite.SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Nakuruc32.db3")))
                {
                    lock (locker)
                    {
                        database.Delete(mwananch2);
                        return true;
                    }
                }

            }
            catch (SQLiteException ex)
            {
                Log.Info("Failed", ex.Message);
                return false;
                //exception handling code to go here
            }
        }
    }
}