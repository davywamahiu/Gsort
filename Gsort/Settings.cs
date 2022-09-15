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
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = false)]
    public class Settings : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.settings);
            Switch swtch = FindViewById<Switch>(Resource.Id.switch1);
            TextView txtvw = FindViewById<TextView>(Resource.Id.textView9);
            swtch.Checked = true;
            Switch swtch1 = FindViewById<Switch>(Resource.Id.switch2);
            swtch1.Checked = true;
            Switch swtch2 = FindViewById<Switch>(Resource.Id.switch3);
            swtch2.Checked = true;
            swtch.CheckedChange += (s, b) =>
            {
                bool isChecked = b.IsChecked;
                if (isChecked)
               
                    Console.WriteLine("Save is on.");
              
                else
               
                   Console.WriteLine("Save is off.");
               
            };
            swtch1.CheckedChange += (a, b) =>
            {
                bool isChecked = b.IsChecked;
                if (isChecked)

                    Console.WriteLine("Save is on.");

                else

                    Console.WriteLine("Save is off.");

            };
            swtch2.CheckedChange += (a, b) =>
            {
                bool isChecked = b.IsChecked;
                if (isChecked)

                    Console.WriteLine("Save is on.");

                else

                    Console.WriteLine("Save is off.");

            };
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