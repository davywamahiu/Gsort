using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using Gsort.Mwanzowadata;
using SQLite;

namespace Gsort
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = false)]
    public class Tender : Activity
    {
        EditText fname, lname, Docpath, phone1, Nid;
        ListView listView;
        public static string CHANNEL_ID = "10023";
        CheckBox Chkbox;  
        List<string> _pick1c = new List<string>();
        ArrayAdapter<string> arrayAdapter;
        Mwenyewe2 _chaguo = new Mwenyewe2();
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.health);
            Button btnback = FindViewById<Button>(Resource.Id.btn5);
            btnback.Click += BtnBackClick;
            // Create your application here
            
            listView = (ListView)FindViewById(Resource.Id.listView71);
            _chaguo.Id1 = 1;
            _chaguo.Name1 = "Health Services Tenders";
            _chaguo.Kielelezo1 = "All information about Health";
            _pick1c.Add(_chaguo.ToString());
            _chaguo.Id1 = 2;
            _chaguo.Name1 = "Road maintanance & Repair Tenders";
            _chaguo.Kielelezo1 = "Want to work with us, learn about how we tender and the process involved";
            _pick1c.Add(_chaguo.ToString());
            _chaguo.Id1 = 3;
            _chaguo.Name1 = "Strategic Infrustructure Tenders";
            _chaguo.Kielelezo1 = "Apply for Business permits here";
            _pick1c.Add(_chaguo.ToString());
            _chaguo.Id1 = 4;
            _chaguo.Name1 = "County Offices Tenders";
            _chaguo.Kielelezo1 = "County Offices Tenders";
            _pick1c.Add(_chaguo.ToString());
            _chaguo.Id1 = 5;
            _chaguo.Name1 = "County Assembly Suppliers";
            _chaguo.Kielelezo1 = "All landlords should subscribe here for best services to their tenants";
            _pick1c.Add(_chaguo.ToString());
            _chaguo.Id1 = 6;
            _chaguo.Name1 = "Agricultural Tenders";
            _chaguo.Kielelezo1 = "Pata soko lakuuzia bidhaa zako";
            _pick1c.Add(_chaguo.ToString());
            _chaguo.Id1 = 7;
            _chaguo.Name1 = "Casual workers Tenders";
            _chaguo.Kielelezo1 = "Recruit docmented workers for jobs within the county for casual jobs";
            _pick1c.Add(_chaguo.ToString());
            arrayAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSelectableListItem, _pick1c);
            listView.Adapter = arrayAdapter;
            listView.ItemClick += (s, e) =>
            {
                for (int i = 0; i < listView.Count; i++)
                {
                    if (e.Position == i)
                    {
                        listView.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.LawnGreen);
                    }
                    else
                    {
                        listView.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Transparent);
                    }
                }
                switch (e.Position)
                {
                    case 0:
                        Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                        AlertDialog alertDialog = dialog.Create();
                        alertDialog.SetTitle("Health Tenders");
                        alertDialog.SetIcon(Resource.Mipmap.assembly);
                        alertDialog.SetMessage("Nakuru county is a corruption free zone. Apply for available Tenders");
                        alertDialog.SetButton("OK", (c, ev)=> {

                            Dialog alertDialog12 = new Dialog(this);
                            alertDialog12.SetTitle("Hotels / Hoteli kubwa");
                            alertDialog12.SetContentView(Resource.Layout.infrmationgrab);
                            Chkbox = alertDialog12.FindViewById<CheckBox>(Resource.Id.checkBox1);
                            fname = alertDialog12.FindViewById<EditText>(Resource.Id.eText2);
                            lname = alertDialog12.FindViewById<EditText>(Resource.Id.eText3);
                            phone1 = alertDialog12.FindViewById<EditText>(Resource.Id.eText1);
                            Docpath = alertDialog12.FindViewById<EditText>(Resource.Id.eText5);
                            Nid = alertDialog12.FindViewById<EditText>(Resource.Id.eText4);
                            alertDialog12.Window.SetSoftInputMode(SoftInput.AdjustResize);
                            alertDialog12.Window.SetLayout(WindowManagerLayoutParams.MatchParent, WindowManagerLayoutParams.WrapContent);
                            alertDialog12.Window.SetBackgroundDrawableResource(Android.Resource.Color.White);
                            Button btnOk = alertDialog12.FindViewById<Button>(Resource.Id.button1);
                            btnOk.Click += BtnOkPop;

                            Button btnCancel = alertDialog12.FindViewById<Button>(Resource.Id.button2);
                            btnCancel.Click += BtnCancelPop; alertDialog12.Show();
                        });
                        alertDialog.SetButton2("Back", (c, ev) => { });
                        alertDialog.Show();
                        break;
                    case 1:
                        Android.App.AlertDialog.Builder dialog1 = new AlertDialog.Builder(this);
                        AlertDialog alertDialog1 = dialog1.Create();
                        alertDialog1.SetTitle("Road maintanance & Repair Tenders");
                        alertDialog1.SetMessage("Nakuru county is a corruption free zone. Apply for available Tenders");
                        alertDialog1.SetButton("OK", (c, ev) => {

                            Dialog alertDialog12 = new Dialog(this);
                            alertDialog12.SetTitle("Hotels / Hoteli kubwa");
                            alertDialog12.SetContentView(Resource.Layout.infrmationgrab);
                            Chkbox = alertDialog12.FindViewById<CheckBox>(Resource.Id.checkBox1);
                            fname = alertDialog12.FindViewById<EditText>(Resource.Id.eText2);
                            lname = alertDialog12.FindViewById<EditText>(Resource.Id.eText3);
                            phone1 = alertDialog12.FindViewById<EditText>(Resource.Id.eText1);
                            Docpath = alertDialog12.FindViewById<EditText>(Resource.Id.eText5);
                            Nid = alertDialog12.FindViewById<EditText>(Resource.Id.eText4);
                            alertDialog12.Window.SetSoftInputMode(SoftInput.AdjustResize);
                            alertDialog12.Window.SetLayout(WindowManagerLayoutParams.MatchParent, WindowManagerLayoutParams.WrapContent);
                            alertDialog12.Window.SetBackgroundDrawableResource(Android.Resource.Color.White);
                            Button btnOk = alertDialog12.FindViewById<Button>(Resource.Id.button1);
                            btnOk.Click += BtnOkPop;

                            Button btnCancel = alertDialog12.FindViewById<Button>(Resource.Id.button2);
                            btnCancel.Click += BtnCancelPop; alertDialog12.Show();
                        });
                        alertDialog1.SetButton2("Back", (c, ev) => { });
                        alertDialog1.Show();

                        break;
                    case 2:
                        Android.App.AlertDialog.Builder dialog2 = new AlertDialog.Builder(this);
                        AlertDialog alertDialog2 = dialog2.Create();
                        alertDialog2.SetTitle("Strategic Infrustructure Tenders");
                        alertDialog2.SetMessage("Nakuru county is a corruption free zone. Apply for available Tenders");
                        alertDialog2.SetButton("OK", (c, ev) => {

                            Dialog alertDialog12 = new Dialog(this);
                            alertDialog12.SetTitle("Hotels / Hoteli kubwa");
                            alertDialog12.SetContentView(Resource.Layout.infrmationgrab);
                            Chkbox = alertDialog12.FindViewById<CheckBox>(Resource.Id.checkBox1);
                            fname = alertDialog12.FindViewById<EditText>(Resource.Id.eText2);
                            lname = alertDialog12.FindViewById<EditText>(Resource.Id.eText3);
                            phone1 = alertDialog12.FindViewById<EditText>(Resource.Id.eText1);
                            Docpath = alertDialog12.FindViewById<EditText>(Resource.Id.eText5);
                            Nid = alertDialog12.FindViewById<EditText>(Resource.Id.eText4);
                            alertDialog12.Window.SetSoftInputMode(SoftInput.AdjustResize);
                            alertDialog12.Window.SetLayout(WindowManagerLayoutParams.MatchParent, WindowManagerLayoutParams.WrapContent);
                            alertDialog12.Window.SetBackgroundDrawableResource(Android.Resource.Color.White);
                            Button btnOk = alertDialog12.FindViewById<Button>(Resource.Id.button1);
                            btnOk.Click += BtnOkPop;

                            Button btnCancel = alertDialog12.FindViewById<Button>(Resource.Id.button2);
                            btnCancel.Click += BtnCancelPop; alertDialog12.Show();
                        });
                        alertDialog2.SetButton2("Back", (c, ev) => { });
                        alertDialog2.Show();
                        break;
                    case 3:
                        Android.App.AlertDialog.Builder dialog3 = new AlertDialog.Builder(this);
                        AlertDialog alertDialog3 = dialog3.Create();
                        alertDialog3.SetTitle("County Offices Tenders");
                        alertDialog3.SetMessage("Nakuru county is a corruption free zone. Apply for available Tenders");
                        alertDialog3.SetButton("OK", (c, ev) => {

                            Dialog alertDialog12 = new Dialog(this);
                            alertDialog12.SetTitle("Hotels / Hoteli kubwa");
                            alertDialog12.SetContentView(Resource.Layout.infrmationgrab);
                            Chkbox = alertDialog12.FindViewById<CheckBox>(Resource.Id.checkBox1);
                            fname = alertDialog12.FindViewById<EditText>(Resource.Id.eText2);
                            lname = alertDialog12.FindViewById<EditText>(Resource.Id.eText3);
                            phone1 = alertDialog12.FindViewById<EditText>(Resource.Id.eText1);
                            Docpath = alertDialog12.FindViewById<EditText>(Resource.Id.eText5);
                            Nid = alertDialog12.FindViewById<EditText>(Resource.Id.eText4);
                            alertDialog12.Window.SetSoftInputMode(SoftInput.AdjustResize);
                            alertDialog12.Window.SetLayout(WindowManagerLayoutParams.MatchParent, WindowManagerLayoutParams.WrapContent);
                            alertDialog12.Window.SetBackgroundDrawableResource(Android.Resource.Color.White);
                            Button btnOk = alertDialog12.FindViewById<Button>(Resource.Id.button1);
                            btnOk.Click += BtnOkPop;

                            Button btnCancel = alertDialog12.FindViewById<Button>(Resource.Id.button2);
                            btnCancel.Click += BtnCancelPop; alertDialog12.Show();
                        });
                        alertDialog3.SetButton2("Back", (c, ev) => { });
                        alertDialog3.Show();
                        break;
                    case 4:
                        Android.App.AlertDialog.Builder dialog4 = new AlertDialog.Builder(this);
                        AlertDialog alertDialog4 = dialog4.Create();
                        alertDialog4.SetTitle("County Assembly Suppliers");
                        alertDialog4.SetIcon(Resource.Mipmap.assembly1);
                        alertDialog4.SetMessage("Nakuru county is a corruption free zone. Apply for available Tenders");
                        alertDialog4.SetButton("OK", (c, ev) => {
                            Dialog alertDialog12 = new Dialog(this);
                            alertDialog12.SetTitle("Hotels / Hoteli kubwa");
                            alertDialog12.SetContentView(Resource.Layout.infrmationgrab);
                            Chkbox = alertDialog12.FindViewById<CheckBox>(Resource.Id.checkBox1);
                            fname = alertDialog12.FindViewById<EditText>(Resource.Id.eText2);
                            lname = alertDialog12.FindViewById<EditText>(Resource.Id.eText3);
                            phone1 = alertDialog12.FindViewById<EditText>(Resource.Id.eText1);
                            Docpath = alertDialog12.FindViewById<EditText>(Resource.Id.eText5);
                            Nid = alertDialog12.FindViewById<EditText>(Resource.Id.eText4);
                            alertDialog12.Window.SetSoftInputMode(SoftInput.AdjustResize);
                            alertDialog12.Window.SetLayout(WindowManagerLayoutParams.MatchParent, WindowManagerLayoutParams.WrapContent);
                            alertDialog12.Window.SetBackgroundDrawableResource(Android.Resource.Color.White);
                            Button btnOk = alertDialog12.FindViewById<Button>(Resource.Id.button1);
                            btnOk.Click += BtnOkPop;

                            Button btnCancel = alertDialog12.FindViewById<Button>(Resource.Id.button2);
                            btnCancel.Click += BtnCancelPop; alertDialog12.Show();
                        });
                        alertDialog4.SetButton2("Back", (c, ev) => { });
                        alertDialog4.Show();
                        break;
                    case 5:
                        Android.App.AlertDialog.Builder dialog5 = new AlertDialog.Builder(this);
                        AlertDialog alertDialog5 = dialog5.Create();
                        alertDialog5.SetTitle("Agricultural Tenders");
                        alertDialog5.SetIcon(Resource.Mipmap.farm);
                        alertDialog5.SetMessage("Nakuru county is a corruption free zone. Apply for available Tenders");
                        alertDialog5.SetButton("OK", (c, ev) => {

                            Dialog alertDialog12 = new Dialog(this);
                            alertDialog12.SetTitle("Hotels / Hoteli kubwa");
                            alertDialog12.SetContentView(Resource.Layout.infrmationgrab);
                            Chkbox = alertDialog12.FindViewById<CheckBox>(Resource.Id.checkBox1);
                            fname = alertDialog12.FindViewById<EditText>(Resource.Id.eText2);
                            lname = alertDialog12.FindViewById<EditText>(Resource.Id.eText3);
                            phone1 = alertDialog12.FindViewById<EditText>(Resource.Id.eText1);
                            Docpath = alertDialog12.FindViewById<EditText>(Resource.Id.eText5);
                            Nid = alertDialog12.FindViewById<EditText>(Resource.Id.eText4);
                            alertDialog12.Window.SetSoftInputMode(SoftInput.AdjustResize);
                            alertDialog12.Window.SetLayout(WindowManagerLayoutParams.MatchParent, WindowManagerLayoutParams.WrapContent);
                            alertDialog12.Window.SetBackgroundDrawableResource(Android.Resource.Color.White);
                            Button btnOk = alertDialog12.FindViewById<Button>(Resource.Id.button1);
                            btnOk.Click += BtnOkPop;

                            Button btnCancel = alertDialog12.FindViewById<Button>(Resource.Id.button2);
                            btnCancel.Click += BtnCancelPop; alertDialog12.Show();
                        });
                        alertDialog5.SetButton2("Back", (c, ev) => { });
                        alertDialog5.Show();
                        break;
                    case 6:
                        Android.App.AlertDialog.Builder dialog6 = new AlertDialog.Builder(this);
                        AlertDialog alertDialog6 = dialog6.Create();
                        alertDialog6.SetTitle("Casual workers Tenders");
                        alertDialog6.SetMessage("Nakuru county is a corruption free zone. Apply for available Tenders");
                        alertDialog6.SetButton("OK", (c, ev) => {

                            Dialog alertDialog12 = new Dialog(this);
                            alertDialog12.SetTitle("Hotels / Hoteli kubwa");
                            alertDialog12.SetContentView(Resource.Layout.infrmationgrab);
                            Chkbox = alertDialog12.FindViewById<CheckBox>(Resource.Id.checkBox1);
                            fname = alertDialog12.FindViewById<EditText>(Resource.Id.eText2);
                            lname = alertDialog12.FindViewById<EditText>(Resource.Id.eText3);
                            phone1 = alertDialog12.FindViewById<EditText>(Resource.Id.eText1);
                            Docpath = alertDialog12.FindViewById<EditText>(Resource.Id.eText5);
                            Nid = alertDialog12.FindViewById<EditText>(Resource.Id.eText4);
                            alertDialog12.Window.SetSoftInputMode(SoftInput.AdjustResize);
                            alertDialog12.Window.SetLayout(WindowManagerLayoutParams.MatchParent, WindowManagerLayoutParams.WrapContent);
                            alertDialog12.Window.SetBackgroundDrawableResource(Android.Resource.Color.White);
                            Button btnOk = alertDialog12.FindViewById<Button>(Resource.Id.button1);
                            btnOk.Click += BtnOkPop;

                            Button btnCancel = alertDialog12.FindViewById<Button>(Resource.Id.button2);
                            btnCancel.Click += BtnCancelPop; alertDialog12.Show();
                        });
                        alertDialog6.SetButton2("Back", (c, ev) => { });
                        alertDialog6.Show();
                        break;
                }
            };
        }

        private void BtnCancelPop(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }

        private void BtnOkPop(object sender, EventArgs e)
        {

            try
            {
                
                string dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Nakuruc32.db3");
                var db = new SQLiteConnection(dbpath);
                db.CreateTable<Mwananch1>();
                Mwananch1 tb2 = new Mwananch1
                {
                    Firstname = fname.Text,
                    Lastname = lname.Text,
                    Phone = phone1.Text,
                    Documentpath = Docpath.Text,
                    NatId = Nid.Text,
                    Terms = Chkbox.Checked
                };
                db.Insert(tb2);
                Toast.MakeText(this, "Details sent Successfully...,", ToastLength.Short).Show();
                StartActivity(typeof(MainActivity));
                NotificationCompat.Builder builder = new NotificationCompat.Builder(this, CHANNEL_ID)
                    .SetContentTitle("Gsort Notification")
                    .SetSubText("You Tender application has been received, you will receive an update after your details have been processed")
                    .SetContentText("Hi, you have a new notification")
                    .SetDefaults(VibrationEffect.DefaultAmplitude)
                    .SetSmallIcon(Resource.Mipmap.shellnaks);
                Notification notification = builder.Build();
                NotificationManager notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;
                const int notificationId = 0;
                notificationManager.Notify(notificationId, notification);
            }
            catch (Exception ex)
            {
                Clear();
                Toast.MakeText(this, ex.ToString(), ToastLength.Long).Show();
            }
        }

        private void Clear()
        {
            fname.Text = "";
            lname.Text = "";
            phone1.Text = "";
            Docpath.Text = "";
            Nid.Text = "";
            Chkbox.Text = "";
        }
        /*RelativeLayout relativeLayout = FindViewById<RelativeLayout>(Resource.Id.relativeLayout1);
relativeLayout.Click += delegate
{
   try
   {
       SetContentView(Resource.Layout.safirinhif);
       web_view = FindViewById<WebView>(Resource.Id.webView1);
       web_view.SetWebViewClient(new NhifWebClient());
       web_view.LoadUrl(txturl.ToString());
       WebSettings webSettings = web_view.Settings;
       webSettings.JavaScriptEnabled = true;

   }
   catch (Exception)
   {
       Toast.MakeText(this, "Failed to open link, check internet connection", ToastLength.Long).Show();
   }
   Toast.MakeText(this, "Tender not ready", ToastLength.Long).Show();
};
RelativeLayout relativeLayout1 = FindViewById<RelativeLayout>(Resource.Id.relativeLayout2);
relativeLayout1.Click += delegate
{
   try
   {
       SetContentView(Resource.Layout.safirinhif);
       web_view = FindViewById<WebView>(Resource.Id.webView1);
       web_view.SetWebViewClient(new NhifWebClient());
       web_view.LoadUrl(txturl1.ToString());
       WebSettings webSettings = web_view.Settings;
       webSettings.JavaScriptEnabled = true;

   }
   catch (Exception)
   {
       Toast.MakeText(this, "Failed to open link, check internet connection", ToastLength.Long).Show();
   }
   Toast.MakeText(this, "Tender Available", ToastLength.Long).Show();
};
RelativeLayout relativeLayout2 = FindViewById<RelativeLayout>(Resource.Id.relativeLayout3);
relativeLayout2.Click += delegate
{
   try
   {
       SetContentView(Resource.Layout.safirinhif);
       web_view = FindViewById<WebView>(Resource.Id.webView1);
       web_view.SetWebViewClient(new NhifWebClient());
       web_view.LoadUrl(txturl2.ToString());
       WebSettings webSettings = web_view.Settings;
       webSettings.JavaScriptEnabled = true;

   }
   catch (Exception)
   {
       Toast.MakeText(this, "Failed to open link, check internet connection", ToastLength.Long).Show();
   }
   Toast.MakeText(this, "Tender in progress ready", ToastLength.Long).Show();
};
RelativeLayout relativeLayout3 = FindViewById<RelativeLayout>(Resource.Id.relativeLayout4);
relativeLayout3.Click += delegate
{
   try
   {
       SetContentView(Resource.Layout.safirinhif);
       web_view = FindViewById<WebView>(Resource.Id.webView1);
       web_view.SetWebViewClient(new NhifWebClient());
       web_view.LoadUrl(txturl3.ToString());
       WebSettings webSettings = web_view.Settings;
       webSettings.JavaScriptEnabled = true;

   }
   catch (Exception)
   {
       Toast.MakeText(this, "Failed to open link, check internet connection", ToastLength.Long).Show();
   }
   Toast.MakeText(this, "Tender waiting for money to be allocated", ToastLength.Long).Show();
};*/

        private void BtnBackClick(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
    public class Mwenyewe2
    {

        public int Id1 { get; set; }

        public string Name1 { get; set; }

        public string Kielelezo1 { get; set; }

        public override string ToString()
        {
            const string V = " ";
            return Id1 + V + Name1 + "\n" + V + Kielelezo1;
        }
    }
}