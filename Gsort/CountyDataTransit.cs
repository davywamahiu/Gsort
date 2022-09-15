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
using Firebase.Database;

namespace Gsort
{
    public class CountyDataTransit : Java.Lang.Object, IValueEventListener
    {
        List<County> datame = new List<County>();
        public event EventHandler<AlumniDataArgs> retrieveInfo;
        public class AlumniDataArgs : EventArgs
        {
            public List<County> County1 { get; set; }
        }
        public void OnCancelled(DatabaseError error)
        {
            
        }

        public void OnDataChange(DataSnapshot snapshot)
        {
            if (snapshot.Value != null)
            {
                Create();
                var resp = snapshot.Children;
                datame.Clear();
                foreach (DataSnapshot _dataSnapshot in resp.ToEnumerable<DataSnapshot>())
                {
                    County County32 = new County
                    {
                        
                        Id = _dataSnapshot.Key,
                        Origin = _dataSnapshot.Child("Id_number").Value.ToString(),
                        statement = _dataSnapshot.Child("Town").Value.ToString(),
                        Date = _dataSnapshot.Child("Amount_Payed").Value.ToString(),
                        Plate = _dataSnapshot.Child("Car_Number_Plate").Value.ToString(),
                        Town = _dataSnapshot.Child("PhoneNumber").Value.ToString(),
                        Amount = _dataSnapshot.Child("Payed_as").Value.ToString()
                    };
                    datame.Add(County32);

                }
                retrieveInfo.Invoke(this, new AlumniDataArgs {County1 = datame});
            }
        }
        private DatabaseReference db;
        public void Create()
        {
            db = FirebaseDatabase.GetInstance("https://gsort-398b4.firebaseio.com/").GetReference("County32");
            db.AddValueEventListener(this);
        }
    }
}