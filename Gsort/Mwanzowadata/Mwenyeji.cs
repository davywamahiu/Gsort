using System;
using SQLite;

namespace Gsort.Mwanzowadata
{
    public class Mwananchi
    {
        public Mwananchi()
        {

        }
        [PrimaryKey, AutoIncrement, Column("_Id")]
        public int Id
        {
            get;
            set;
        }
        public string First_name
        {
            get;
            set;
        }
        public string Last_name
        {
            get;
            set;
        }
        public string Phone
        {
            get;
            set;
        }
        public String Password
        {
            get;
            set;
        }
        public bool Agreed
        {
            get;
            set;
        }
    }
}