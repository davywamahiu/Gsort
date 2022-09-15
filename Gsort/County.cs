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

namespace Gsort
{
    public class County
    {
        public string Origin { get; set; }
        public string statement { get; set; }
        public string Date { get; set; }
        public string Plate { get; set; }
        public string Town { get; set; }
        public string Amount { get; set; }
        public string Id { get; set; }
        public County()
        {

        }
        public string GetOrigin()
        {
            return Origin;
        }
        public string GetStatement()
        {
            return statement;
        }
        public string GetDate()
        {
            return Date;
        }
        public string GetPlate()
        {
            return Plate;
        }
        public string GetTown()
        {
            return Town;
        }
        public string GetId()
        {
            return Id;
        }
        public string GetAmount()
        {
            return Amount;
        }
    }
}