using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database.Sqlite;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Gsort.Mwanzowadata
{
    class NyumbaTatu : SQLiteOpenHelper
    {
        private new const string DatabaseName = "nakuruc32.db3";
        //specifies the database version (increment this number each time you make database related changes)
        private const int DatabaseVersion = 3;

        public NyumbaTatu(Context context) : base(context, DatabaseName, null, DatabaseVersion)
        {
        }
        public override void OnCreate(SQLiteDatabase db)
        {
            //create database tables
            db.ExecSQL(@"
                        CREATE TABLE IF NOT EXISTS NYUMBA (
                            Id              INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name       TEXT NOT NULL,
                            Phone        TEXT NOT NULL,
                            Available           TEXT NOT NULl,
                            SubCounty           TEXT NOT NULl,
                            Ptype           TEXT NOT NULl,
                            Rent           Text NOT NULL,
                            RoomSize        TEXT NOT NULL)");

            //create database indexes
            db.ExecSQL(@"CREATE INDEX IF NOT EXISTS NAME_NYUMBA ON NYUMBA (NAME)");
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