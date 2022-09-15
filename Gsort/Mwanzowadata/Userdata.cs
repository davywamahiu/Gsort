using System;
using Android.Database.Sqlite;
using Android.Content;
using Gsort.Mwanzowadata;
using SQLite;

namespace Gsort.Mwanzowadata
{
    public class MkaaziWaNakuru : SQLiteOpenHelper
    {
        private new const string DatabaseName = "nakuruc32.db3";
        //specifies the database version (increment this number each time you make database related changes)
        private const int DatabaseVersion = 3;

        public MkaaziWaNakuru(Context context) : base(context, DatabaseName, null, DatabaseVersion)
        {
        }
        public override void OnCreate(SQLiteDatabase db)
        {
            //create database tables
            db.ExecSQL(@"
                        CREATE TABLE IF NOT EXISTS MWANANCH1 (
                            Id              INTEGER PRIMARY KEY AUTOINCREMENT,
                            Firstname       TEXT NOT NULL,
                            Lastname        TEXT NOT NULL,
                            Phone           TEXT NOT NULl,
                            NatId           TEXT NOT NULl,
                            Terms           BOOLEAN NOT NULL,
                            DocumentPath        TEXT NOT NULL)");

            //create database indexes
            db.ExecSQL(@"CREATE INDEX IF NOT EXISTS FIRST_NAME_MWANANCH1 ON MWANANCHI (FIRST_NAME)");
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



