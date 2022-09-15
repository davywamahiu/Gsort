using System;
using Android.App;
using Gsort.Mwanzowadata;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Util;
using SQLite;
using System.IO;
using Android.Support.V4.Content;
using Android.Support.V4.App;
using System.Collections.Generic;
using Android;
using Xamarin.Forms;
using System.Threading.Tasks;
using Android.Runtime;

namespace Gsort
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = false)]
    public class Register : Activity
    {
        EditText edtText1, edtText2, edtText3, edtText4, edtText5;
        Android.Widget.Button btn45;
        Nakuru storeuser;
        Android.Widget.CheckBox chkBox1;
        Android.Widget.ProgressBar progress;
        string[] PermissionsArray = null;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.register);
            edtText1 = FindViewById<EditText>(Resource.Id.editText1);
            edtText2 = FindViewById<EditText>(Resource.Id.editText2);
            edtText3 = FindViewById<EditText>(Resource.Id.editText3);
            edtText4 = FindViewById<EditText>(Resource.Id.editText4);
            edtText5 = FindViewById<EditText>(Resource.Id.editText5);
            chkBox1 = FindViewById<Android.Widget.CheckBox>(Resource.Id.checkBox1);
            progress = FindViewById<Android.Widget.ProgressBar>(Resource.Id.progressBar1);
            storeuser = new Nakuru();

            TryToGetPermissions();
            storeuser.SetContext(this);
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
            Log.Info("DB_Path", folder);
            btn45 = FindViewById<Android.Widget.Button>(Resource.Id.button45);
            btn45.Click += RegisterOnClick;
            Android.Widget.Button regi = FindViewById<Android.Widget.Button>(Resource.Id.button46);
            regi.Click += LoginOnClick;
        }

        private void LoginOnClick(object sender, EventArgs e)
        {
            StartActivity(typeof(Login));
        }

        private void RegisterOnClick(object sender, EventArgs e)
        {
            progress.Visibility = ViewStates.Visible;
            string Password = edtText4.Text;
            string ConfirmPassword = edtText5.Text;
            string Phone = edtText3.Text;
            string First_Name = edtText1.Text;
            string Last_Name = edtText2.Text;


            if (string.IsNullOrEmpty(First_Name))
            {
                edtText1.SetError("First Name can not be empty", null);
            }
            if (string.IsNullOrEmpty(Last_Name))
            {
                edtText2.SetError("Last Name can not be empty", null);
            }
            if (string.IsNullOrEmpty(Phone))
            {
                edtText3.SetError("Phone number can not be empty", null);
            }

            if (string.IsNullOrEmpty(Password))
            {
                edtText4.SetError("Password can not be empty", null);
            }
            if (string.IsNullOrEmpty(ConfirmPassword))
            {
                edtText5.SetError("ConfirmPassword can not be empty", null);
            }
            if (Password.Length < 6)
            {
                edtText4.SetError("Password is too short must be 6 or more characters", null);
            }
            if (ConfirmPassword.Length < 6)
            {
                edtText5.SetError("ConfirmPassword is too short must be 6 or more characters", null);
            }
            else
            {

                if (Password.Equals(ConfirmPassword))
                {
                    try
                    {
                        if ((Phone.StartsWith("07") || Phone.StartsWith("+2547")) && Phone.Length.Equals(10) || Phone.Length.Equals(13))
                        {

                            try
                            {
                                Mwananchi tb1 = new Mwananchi
                                {
                                    Password = edtText4.Text,
                                    Phone = edtText3.Text,
                                    First_name = edtText1.Text,
                                    Last_name = edtText2.Text,
                                    Agreed = chkBox1.Checked
                                };
                                string dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Nakuruc32.db3");
                                var db = new SQLiteConnection(dbpath);
                                db.CreateTable<Mwananchi>();
                                db.Insert(tb1);
                                Toast.MakeText(this, "Registration was Successfull...,", ToastLength.Short).Show();
                                StartActivity(typeof(MainActivity));
                            }
                            catch (System.Exception ex)
                            {
                                Toast.MakeText(this, ex.ToString(), ToastLength.Long).Show();
                            }
                        }
                        else
                        {
                            Toast.MakeText(this, "Registration Failed,Phone number must start with 07 or +2547/ Hakikisha Namba yako ya simu inaanza na 07... ama +254...,", ToastLength.Long).Show();
                        }
                    }
                    catch (System.Exception)
                    {
                        Toast.MakeText(this, "Connection to database failed, try again...", ToastLength.Long).Show();
                        //exception handling code to go here
                    }
                }
                else
                {
                    Toast.MakeText(this, "We are sorry, your password mismatched...,", ToastLength.Short).Show();
                }
            }
        }
        #region RuntimePermissions

        private async Task TryToGetPermissions()
        {
            if ((int)Build.VERSION.SdkInt >= 23)
            {
                await GetPermissionsAsync();
                return;
            }


        }
        const int RequestLocationId = 0;
        const int RequestInternetId = 1;
        const int RequestStorageId = 2;
        const int RequestWriteId = 3;
        const int RequestSmsId = 4;
        const int RequestSettingsId = 5;
        readonly string[] PermissionsGroupLocation =
            {
                            //TODO add more permissions
                            Manifest.Permission.AccessCoarseLocation,
                            Manifest.Permission.AccessFineLocation,
                            Manifest.Permission.Internet,
                            Manifest.Permission.ReadExternalStorage,
                            Manifest.Permission.WriteExternalStorage,
                            Manifest.Permission.ReadSms,
                            Manifest.Permission.ReceiveSms,
                            Manifest.Permission.WriteSettings
             };
        async Task GetPermissionsAsync()
        {
            const string permission = Manifest.Permission.AccessFineLocation;
            const string permission1 = Manifest.Permission.Internet;
            const string permission2 = Manifest.Permission.WriteExternalStorage;
            const string permission3 = Manifest.Permission.ReadExternalStorage;
            const string permission4 = Manifest.Permission.ReadSms;
            const string permission5 = Manifest.Permission.WriteSettings;
            if (CheckSelfPermission(permission) == (int)Android.Content.PM.Permission.Granted)
            {
                //TODO change the message to show the permissions name
                Toast.MakeText(this, "Special permissions granted", ToastLength.Short).Show();
                return;
            }
            if (ShouldShowRequestPermissionRationale(permission))
            {
                //set alert for executing the task
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Permissions Needed");
                alert.SetMessage("The application need special permissions to continue");
                alert.SetNeutralButton("Request Permissions", (senderAlert, args) =>
                {
                    RequestPermissions(PermissionsGroupLocation, RequestLocationId);
                });

                alert.SetNegativeButton("Cancel", (senderAlert, args) =>
                {
                    Toast.MakeText(this, "Cancelled!", ToastLength.Short).Show();
                });

                Dialog dialog = alert.Create();
                dialog.Show();


                return;
            }
            if (ShouldShowRequestPermissionRationale(permission1))
            {
                //set alert for executing the task
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Permissions Needed");
                alert.SetMessage("The application need special permissions to continue");
                alert.SetNeutralButton("Request Permissions", (senderAlert, args) =>
                {
                    RequestPermissions(PermissionsGroupLocation, RequestInternetId);
                });

                alert.SetNegativeButton("Cancel", (senderAlert, args) =>
                {
                    Toast.MakeText(this, "Cancelled!", ToastLength.Short).Show();
                });

                Dialog dialog = alert.Create();
                dialog.Show();


                return;
            }
            if (ShouldShowRequestPermissionRationale(permission2))
            {
                //set alert for executing the task
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Permissions Needed");
                alert.SetMessage("The application need special permissions to continue");
                alert.SetNeutralButton("Request Permissions", (senderAlert, args) =>
                {
                    RequestPermissions(PermissionsGroupLocation, RequestStorageId);
                });

                alert.SetNegativeButton("Cancel", (senderAlert, args) =>
                {
                    Toast.MakeText(this, "Cancelled!", ToastLength.Short).Show();
                });

                Dialog dialog = alert.Create();
                dialog.Show();


                return;
            }
            if (ShouldShowRequestPermissionRationale(permission3))
            {
                //set alert for executing the task
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Permissions Needed");
                alert.SetMessage("The application need special permissions to continue");
                alert.SetNeutralButton("Request Permissions", (senderAlert, args) =>
                {
                    RequestPermissions(PermissionsGroupLocation, RequestWriteId);
                });

                alert.SetNegativeButton("Cancel", (senderAlert, args) =>
                {
                    Toast.MakeText(this, "Cancelled!", ToastLength.Short).Show();
                });

                Dialog dialog = alert.Create();
                dialog.Show();


                return;
            }
            if (ShouldShowRequestPermissionRationale(permission4))
            {
                //set alert for executing the task
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Permissions Needed");
                alert.SetMessage("The application need special permissions to continue");
                alert.SetNeutralButton("Request Permissions", (senderAlert, args) =>
                {
                    RequestPermissions(PermissionsGroupLocation, RequestSmsId);
                });

                alert.SetNegativeButton("Cancel", (senderAlert, args) =>
                {
                    Toast.MakeText(this, "Cancelled!", ToastLength.Short).Show();
                });

                Dialog dialog = alert.Create();
                dialog.Show();


                return;
            }
            if (ShouldShowRequestPermissionRationale(permission5))
            {
                //set alert for executing the task
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Permissions Needed");
                alert.SetMessage("The application need special permissions to continue");
                alert.SetNeutralButton("Request Permissions", (senderAlert, args) =>
                {
                    RequestPermissions(PermissionsGroupLocation, RequestSettingsId);
                });

                alert.SetNegativeButton("Cancel", (senderAlert, args) =>
                {
                    Toast.MakeText(this, "Cancelled!", ToastLength.Short).Show();
                });

                Dialog dialog = alert.Create();
                dialog.Show();


                return;
            }
            RequestPermissions(PermissionsGroupLocation, RequestLocationId);
            RequestPermissions(PermissionsGroupLocation, RequestInternetId);
            RequestPermissions(PermissionsGroupLocation, RequestStorageId);
            RequestPermissions(PermissionsGroupLocation, RequestWriteId);
            RequestPermissions(PermissionsGroupLocation, RequestSmsId);
            RequestPermissions(PermissionsGroupLocation, RequestSettingsId);
        }
        public override async void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            switch (requestCode)
            {
                case RequestLocationId:
                    {
                        if (grantResults[0] == (int)Android.Content.PM.Permission.Granted)
                        {
                            Toast.MakeText(this, "Special permissions granted", ToastLength.Short).Show();

                        }
                        else
                        {
                            //Permission Denied :(
                            Toast.MakeText(this, "Special permissions denied", ToastLength.Short).Show();

                        }
                    }
                    break;
                case RequestInternetId:
                    {
                        if (grantResults[1] == (int)Android.Content.PM.Permission.Granted)
                        {
                            Toast.MakeText(this, "Special permissions granted", ToastLength.Short).Show();

                        }
                        else
                        {
                            //Permission Denied :(
                            Toast.MakeText(this, "Special permissions denied", ToastLength.Short).Show();

                        }
                    }
                    break;
                case RequestStorageId:
                    {
                        if (grantResults[2] == (int)Android.Content.PM.Permission.Granted)
                        {
                            Toast.MakeText(this, "Write to Storage permissions granted", ToastLength.Short).Show();

                        }
                        else
                        {
                            //Permission Denied :(
                            Toast.MakeText(this, "Special permissions denied", ToastLength.Short).Show();

                        }
                    }
                    break;
                case RequestWriteId:
                    {
                        if (grantResults[3] == (int)Android.Content.PM.Permission.Granted)
                        {
                            Toast.MakeText(this, "Special permissions granted", ToastLength.Short).Show();

                        }
                        else
                        {
                            //Permission Denied :(
                            Toast.MakeText(this, "Special permissions denied", ToastLength.Short).Show();

                        }
                    }
                    break;
                case RequestSmsId:
                    {
                        if (grantResults[4] == (int)Android.Content.PM.Permission.Granted)
                        {
                            Toast.MakeText(this, "Special permissions granted", ToastLength.Short).Show();

                        }
                        else
                        {
                            //Permission Denied :(
                            Toast.MakeText(this, "Special permissions denied", ToastLength.Short).Show();

                        }
                    }
                    break;
                case RequestSettingsId:
                    {
                        if (grantResults[5] == (int)Android.Content.PM.Permission.Granted)
                        {
                            Toast.MakeText(this, "Special permissions granted", ToastLength.Short).Show();

                        }
                        else
                        {
                            //Permission Denied :(
                            Toast.MakeText(this, "Special permissions denied", ToastLength.Short).Show();

                        }
                    }
                    break;
            }
            //base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        #endregion
        // Create your application here
    }
}