using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Newtonsoft.Json.Linq;
using Android.Support.V7.Widget;
using Android.Widget;
using Firebase.Database;
using Gsort.Mwanzowadata;
using System;

namespace Gsort
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = false)]
    public class NoticeBoard : Activity
    {
        //SQLiteDatabase sqliteDb = new SQLiteDatabase();
        List<Mwananch1> _pick1c = new List<Mwananch1>();
        ListView listViewData;
        List<County> datame = new List<County>();
        Nakuruc32 db1;
        TextView txterror;
        RecyclerView myrecyclerView;
        List<County> counties;
        ProgressBar progressBar;
        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.noticeboard);
            listViewData = (ListView)FindViewById(Resource.Id.listView1);
            db1 = new Nakuruc32();
            myrecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView1);
            progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);
            //CreateDatabase();
            //myrecyclerVAdapter();
            await LoadData();
            //LoadDataList();
        }

        private async Task LoadData()
        {
            progressBar.Visibility = Android.Views.ViewStates.Visible;
            myrecyclerView.Visibility = Android.Views.ViewStates.Invisible;
            
            try
            {
                var firebase = new FirebaseClient("https://gsort-398b4.firebaseio.com/");
                var items = await firebase.Child("Countyc32").OnceAsync<County>();
                RecyclerVAdapter recyclerV = null;
                datame.Clear();
                foreach (var _item in items)
                {
                    County County32 = new County
                    {
                        Id = _item.Key,
                        Origin = _item.Object.Origin,
                        statement = _item.Object.statement,
                        Date = _item.Object.Date,
                        Plate = _item.Object.Plate,
                        Town = _item.Object.Town,
                        Amount = _item.Object.Amount
                    };

                    datame.Add(County32);
                }
                myrecyclerView.SetLayoutManager(new LinearLayoutManager(myrecyclerView.Context));
                recyclerV = new RecyclerVAdapter(datame);
                myrecyclerView.SetAdapter(recyclerV);
                progressBar.Visibility = Android.Views.ViewStates.Invisible;
                myrecyclerView.Visibility = Android.Views.ViewStates.Visible;
                recyclerV.NotifyDataSetChanged();
            }
            catch(Exception ex)
            {
                txterror.Visibility = Android.Views.ViewStates.Visible;
            }

        }
        /*public void LoadDataList()
        {
            countyDataTransit = new CountyDataTransit();
            countyDataTransit.Create();
            countyDataTransit.retrieveInfo += County_retrieveData;
        }

        public void County_retrieveData(object sender, CountyDataTransit.AlumniDataArgs e)
        {
            counties = e.County1;
            myrecyclerVAdapter();

        }
        public void myrecyclerVAdapter()
        {
            myrecyclerView.SetLayoutManager(new LinearLayoutManager(myrecyclerView.Context));
            RecyclerVAdapter recyclerV = new RecyclerVAdapter(counties);
            myrecyclerView.SetAdapter(recyclerV);
        }*/
        /*public void CreateDatabase()
        {
            counties = new List<County>
            {
                new County { Origin = "M-Pesa", Date = "2020/15/03", Plate = "KDF 001A", statement = "MJHDF7GD7T7376 Confirmed. You have sent KSh5,000 to Nakuru County Parking fee. Your balance is KSh4,000", Town = "Molo" },
                new County { Origin = "M-Pesa", Date = "2020/15/03", Plate = "KDB 101A", statement = "MJHDF7GD7T7376 Confirmed. You have sent KSh1,000 to Nakuru County Parking fee. Your balance is KSh10,000", Town = "Nakuru" },
                new County { Origin = "M-Pesa", Date = "2020/15/03", Plate = "KDH 361B", statement = "MJHDF7GD7T7376 Confirmed. You have sent KSh150 to Nakuru County Parking fee. Your balance is KSh3,000", Town = "GilGil" },
                new County { Origin = "M-Pesa", Date = "2020/15/03", Plate = "KDR 001Z", statement = "MJHDF7GD7T7376 Confirmed. You have sent KSh3,000 to Nakuru County Parking fee. Your balance is KSh17,000", Town = "Naivasha" }
            };
        }
        private void LoadData()
        {
            _pick1c = db1.LoginOnClick();
            var adapter = new CustomAdapter(this, _pick1c);
            listViewData.Adapter = adapter;
        }*/
    }
}