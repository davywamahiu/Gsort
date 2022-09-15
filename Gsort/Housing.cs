using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Gsort
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = false)]
    public class Housing : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.housing);
            Button btnback = FindViewById<Button>(Resource.Id.btn5);
            btnback.Click += BtnBackClick;
            // Create your application here
        }

        private void BtnBackClick(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
}