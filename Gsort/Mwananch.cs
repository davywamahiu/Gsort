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
    public class Mwananch1
    {
        public Mwananch1()
        {

        }
        [PrimaryKey, AutoIncrement, Column("_Id")]
        public int Id
        {
            get;
            set;
        }
        public string Phone
        {
            get;
            set;
        }
        public string Firstname
        {
            get;
            set;
        }
        public string Lastname
        {
            get;
            set;
        }
        public string NatId
        {
            get;
            set;
        }
        public string Documentpath
        {
            get;
            set;
        }
        public bool Terms
        {
            get;
            set;
        }
    }
}