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

namespace Gsort.Mwanzowadata
{
    public class Mwananch
    {
        public Mwananch()
        {

        }
        [PrimaryKey, AutoIncrement, Column("_Id")]
        public int Id
        {
            get;
            set;
        }
        public String Message
        {
            get;
            set;
        }
    }
}