using System;
using Android.Database.Sqlite;
using Android.Content;
using Gsort.Mwanzowadata;
using SQLite;

namespace Gsort
{
    public class Hospital : SQLiteOpenHelper
    {
        private new const string DatabaseName = "nakuru32";
        //specifies the database version (increment this number each time you make database related changes)
        private const int DatabaseVersion = 3;

        public Hospital(Context context) : base(context, DatabaseName, null, DatabaseVersion)
        {
        }
        public override void OnCreate(SQLiteDatabase db)
        {
            //create database tables
            db.ExecSQL(@"
                        CREATE TABLE IF NOT EXISTS MWANANCH (
                            Id              INTEGER PRIMARY KEY AUTOINCREMENT,
                            Message       TEXT NOT NULL)");

            //create database indexes
            db.ExecSQL(@"CREATE INDEX IF NOT EXISTS MESSAGE_MWANANCH ON MWANANCH (MESSAGE)");
        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            if (oldVersion < newVersion)
            {
                db.Dispose();
                //perform any database upgrade tasks for versions prior to  version 2              
            }

        }

    }
}



