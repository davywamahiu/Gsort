using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace Gsort
{
    class Nyumba
    {
        public Nyumba()
        {

        }
        [PrimaryKey, AutoIncrement, Column("_Id")]
        public int Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string Ptype
        {
            get;
            set;
        }
        public string Phone
        {
            get;
            set;
        }
        public string RoomSize
        {
            get;
            set;
        }
        public string Available
        {
            get;
            set;
        }
        public string Rent
        {
            get;
            set;
        }
        public string SubCounty
        {
            get;
            set;
        }
    }
}