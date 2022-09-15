using System;
using System.Collections.Generic;
using System.IO;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Gsort.Mwanzowadata;
using SQLite;
using static Gsort.Mwanzowadata.Payments;

namespace Gsort
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class Login : Activity

    {
        Nakuru storeuser;
        EditText edtText3, edtText4;
        ProgressBar progress;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.login);
            edtText3 = FindViewById<EditText>(Resource.Id.editText3);
            edtText4 = FindViewById<EditText>(Resource.Id.editText4);
            Button login = FindViewById<Button>(Resource.Id.button1);
            progress = FindViewById<ProgressBar>(Resource.Id.progressBar1);
            storeuser = new Nakuru();
            storeuser.SetContext(this);
            login.Click += LoginOnClick;
            Button register  = FindViewById<Button>(Resource.Id.button);
            register.Click += RegisterOnClick;
            CreateDB();
            //CreatedatabasePath();
        }

        
        private void LoginOnClick(object sender, EventArgs e)
        {
            progress.Visibility = ViewStates.Visible;
            string Password1 = edtText4.Text;
            string Phone1 = edtText3.Text;
            if (string.IsNullOrEmpty(Phone1))
            {
                edtText3.SetError("Make sure no field is empty, and passwords match.", null);
            }
            if (string.IsNullOrEmpty(Password1))
            {
                edtText4.SetError("Make sure no field is empty, and passwords match.", null);
            }
            if(Password1.Length < 6)
            {
                edtText4.SetError("Password is too short.", null);
            }

            else
            {
                try
                {
                    if((Phone1.StartsWith("07") || Phone1.StartsWith("+2547"))&& Phone1.Length.Equals(10)|| Phone1.Length.Equals(13))
                    {
                        
                            try
                            {
                                string dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Nakuruc32.db3");
                                var db = new SQLiteConnection(dbpath);
                                var data = db.Table<Mwananchi>();
                                var data1 = data.Where(u => u.Phone == edtText3.Text && u.Password == edtText4.Text).FirstOrDefault();
                                if (data1 != null)
                                {
                                    Toast.MakeText(this, "Login is Successfull...,", ToastLength.Short).Show();
                                    StartActivity(typeof(MainActivity));
                                }
                                else
                                {
                                    Toast.MakeText(this, "Login is failed...,", ToastLength.Short).Show();
                                }
                            }
                            catch (Exception ex)
                            {
                                Toast.MakeText(this, "You do not have an account, please register a new account", ToastLength.Long).Show();
                            }
                    }
                    else
                    {
                        edtText3.SetError("Login Failed, or Phone number must start with 0 or + 254 / Hakikisha Namba yako ya simu inaanza na 07 ama + 254..., ", null);
                    }
                }
                catch (Exception)
                {
                    Toast.MakeText(this, "Login Failed. try again...,", ToastLength.Long).Show();
                    //exception handling code to go here
                }
                
                    
            }

        }
        public string CreateDB()
        {
            var output = "";
            output += " Wait Synching DB...";
            string dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Nakuruc32.db3");
            var db = new SQLiteConnection(dbpath);
            output += "\n Operation succeeded...";
            return output;
        }

        private void RegisterOnClick(object sender, EventArgs e)
        {
            StartActivity(typeof(Register));
            OverridePendingTransition(Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out);
        }
    }
}