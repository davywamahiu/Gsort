using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Gsort
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = false)]
    public class Rental : Activity
    {
        NakuruRentals db3;
        List<Nyumba> _pick1c = new List<Nyumba>();
        ListView listViewData;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.rental);
            listViewData = (ListView)FindViewById(Resource.Id.listView1);
            db3 = new NakuruRentals();
            EditText editText = FindViewById<EditText>(Resource.Id.editText1);
            EditText edtText = FindViewById<EditText>(Resource.Id.editText2);
            var spinner = FindViewById<Spinner>(Resource.Id.spinner1);
            string firstitem = spinner.SelectedItem.ToString();
            spinner.ItemSelected += (a, b) =>
            {
                if (firstitem.Equals(spinner.SelectedItem.ToString()))
                {

                }
                else
                {
                    
                    Toast.MakeText(this, "You housing plan is selected as" + b.Parent.GetItemIdAtPosition(b.Position), ToastLength.Short).Show();
                }
            };
            var spinner1 = FindViewById<Spinner>(Resource.Id.spinner2);
            string firstitem1 = spinner1.SelectedItem.ToString();
            spinner1.ItemSelected += (a, b) =>
            {
                if (firstitem.Equals(spinner1.SelectedItem.ToString()))
                {

                }
                else
                {
                    
                    Toast.MakeText(this, "You rent is selected as" + b.Parent.GetItemIdAtPosition(b.Position), ToastLength.Short).Show();
                }
            };
            var spinner2 = FindViewById<Spinner>(Resource.Id.spinner3);
            string firstitem2 = spinner2.SelectedItem.ToString();
            spinner2.ItemSelected += (a, b) =>
            {
                if (firstitem.Equals(spinner2.SelectedItem.ToString()))
                {

                }
                else
                {
                    Toast.MakeText(this, "You location is selected as" + b.Parent.GetItemIdAtPosition(b.Position), ToastLength.Short).Show();
                }
            };
            var spiner4 = FindViewById<Spinner>(Resource.Id.spinner4);
            string firstitem4 = spiner4.SelectedItem.ToString();
            spiner4.ItemSelected += (a, b) =>
            {
                if (firstitem.Equals(spiner4.SelectedItem.ToString()))
                {

                }
                else
                {
                    string select1 = spiner4.SelectedItem.ToString();
                    Toast.MakeText(this, "Number of room is selected as" + b.Parent.GetItemIdAtPosition(b.Position), ToastLength.Short).Show();
                }
            };
            var spinner5 = FindViewById<Spinner>(Resource.Id.spinner5);
            string firstitem5 = spinner5.SelectedItem.ToString();
            spinner5.ItemSelected += (a, b) =>
            {
                if (firstitem.Equals(spinner5.SelectedItem.ToString()))
                {

                }
                else
                {
                    Toast.MakeText(this, "Occupation is selected as" + b.Parent.GetItemIdAtPosition(b.Position), ToastLength.Short).Show();
                }
            };
            // Create your application here
            LoadData();
            Button btnSubmit = FindViewById<Button>(Resource.Id.button17);
            Button btnback = FindViewById<Button>(Resource.Id.btn5);
            btnback.Click += BtnBackClick;
            btnSubmit.Click += (s, e) =>
            {
                Nyumba nyumba = new Nyumba
                {
                    Name = editText.Text,
                    Phone = editText.Text,
                    Ptype = firstitem.ToString(),
                    RoomSize = firstitem1.ToString(),
                    Available = firstitem4.ToString(),
                    Rent = firstitem5.ToString(),
                    SubCounty = spiner4.ToString()
                };
                db3.AddHome(nyumba);
                Toast.MakeText(this, "Records saved successfully", ToastLength.Long).Show();
                StartActivity(typeof(MainActivity));
            };
            // Create your application here

        }
        private void LoadData()
        {
            _pick1c = db3.RetrieveData();
            var adapter = new CustomAdapta(this, _pick1c);
            listViewData.Adapter = adapter;
        }
        private void BtnBackClick(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
}