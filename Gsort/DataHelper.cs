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
using Firebase;
using Firebase.Database;

namespace Gsort
{
    public class DataHelper
    {
        public static FirebaseDatabase Getdatabase()
        {
            var app = FirebaseApp.InitializeApp(Application.Context);
            FirebaseDatabase database;
            if (app == null)
            {
                var option = new Firebase.FirebaseOptions.Builder()
                .SetApplicationId("gsort-398b4")
                .SetApiKey("AIzaSyCzZz8q0xX3xxurQFZcgShiTHnwdxtn4iw")
                .SetDatabaseUrl("https://gsort-398b4.firebaseio.com/")
                .SetStorageBucket("gsort-398b4.appspot.com")
                .Build();
                app = FirebaseApp.InitializeApp(Application.Context, option);
                database = FirebaseDatabase.GetInstance(app);
            }
            else
            {
                database = FirebaseDatabase.GetInstance(app);
            }
            return database;
        }
    }
}