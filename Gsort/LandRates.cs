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
using Android.Widget;
using Gsort.Mwanzowadata;
using SQLite;
using static Gsort.Mwanzowadata.Payments;

namespace Gsort
{
    [Activity(Label = "Health")]
    public class LandRates : Activity
    {
        EditText fname, lname, Docpath, phone1, Nid;
        CheckBox Chkbox;
        ListView listView;
        public static string CHANNEL_ID = "10023";
        List<string> _pick1c = new List<string>();
        List<string> _pick1d = new List<string>();
        ArrayAdapter<string> arrayAdapter;
        Mwenyewe2 _chaguo = new Mwenyewe2();
        private string phone;
        private long msisdn1;
        private readonly long msisdn = 254726683199;
        private readonly int pesa = 1;
        private readonly string callUrl = "http://requestbin.net/r/tat0wqta";
        private readonly ExtraConfig extraConfig = new ExtraConfig
        {
            LNMShortCode = 174379,
            LNMPassWord = "bfb279f9aa9bdbcf158e97dd71a467cd2e0c893059b10f78e6b72ada1ed2c919"
        };

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.landrates);
            Button btnback = FindViewById<Button>(Resource.Id.btn5);
            btnback.Click += BtnBackClick;
            Toast.MakeText(this, "The List below shows most common permits, Please visit the county HeadQuaters for ones not listed", ToastLength.Long).Show();
            listView = (ListView)FindViewById(Resource.Id.listView72);
            _chaguo.Id1 = 1;
            _chaguo.Name1 = "Food Kiosk permits/ wachhuzi wa vyakula";
            _chaguo.Kielelezo1 = "All information about Health";
            _pick1c.Add(_chaguo.ToString());
            _chaguo.Id1 = 2;
            _chaguo.Name1 = " Restraunt permits/ Hoteli za vyakula";
            _chaguo.Kielelezo1 = "Want to work with us, learn about how we tender and the process involved";
            _pick1c.Add(_chaguo.ToString());
            _chaguo.Id1 = 3;
            _chaguo.Name1 = "Hotels/ Hoteli kubwa";
            _chaguo.Kielelezo1 = "Apply for Business permits here";
            _pick1c.Add(_chaguo.ToString());
            _chaguo.Id1 = 4;
            _chaguo.Name1 = "Shop permits/ Maduka madogo";
            _chaguo.Kielelezo1 = "County Offices Tenders";
            _pick1c.Add(_chaguo.ToString());
            _chaguo.Id1 = 5;
            _chaguo.Name1 = "Retailers permits";
            _chaguo.Kielelezo1 = "All landlords should subscribe here for best services to their tenants";
            _pick1c.Add(_chaguo.ToString());
            _chaguo.Id1 = 6;
            _chaguo.Name1 = "Bars and Clubs permits";
            _chaguo.Kielelezo1 = "Pata soko lakuuzia bidhaa zako";
            _pick1c.Add(_chaguo.ToString());
            _chaguo.Id1 = 7;
            _chaguo.Name1 = "Cottage Industries permits/ wachuuzi wa Juakali";
            _chaguo.Kielelezo1 = "Recruit docmented workers for jobs within the county for casual jobs";
            _pick1c.Add(_chaguo.ToString());
            _chaguo.Id1 = 8;
            _chaguo.Name1 = "Hawkers permits/ Wachuuzi";
            _chaguo.Kielelezo1 = "Recruit docmented workers for jobs within the county for casual jobs";
            _pick1c.Add(_chaguo.ToString());
            _chaguo.Id1 = 9;
            _chaguo.Name1 = "Salons & Vinyozi Permits";
            _chaguo.Kielelezo1 = "Recruit docmented workers for jobs within the county for casual jobs";
            _pick1c.Add(_chaguo.ToString());
            _chaguo.Id1 = 10;
            _chaguo.Name1 = "Taxi and BodaBoda Permits";
            _chaguo.Kielelezo1 = "Recruit docmented workers for jobs within the county for casual jobs";
            _pick1c.Add(_chaguo.ToString());
            arrayAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSelectableListItem, _pick1c);
            listView.Adapter = arrayAdapter;
            listView.ItemClick += (s, e) =>
            {
                switch (e.Position)
                {
                    case 0:
                        Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                        AlertDialog alertDialog = dialog.Create();
                        alertDialog.SetTitle("Food Kiosk permits/ wachhuzi wa vyakula");
                        alertDialog.SetIcon(Resource.Mipmap.assembly);
                        alertDialog.SetMessage("Nakuru county is a corruption free zone. Apply for available permit");
                        alertDialog.FindViewById<TextView>(Resource.Id.txtView1);
                        alertDialog.SetButton("OK", (c, ev) => {
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
                        alertDialog.SetButton2("Back", (c, ev) => { alertDialog.Dismiss(); });
                        alertDialog.Show();
                        break;
                    case 1:
                        Android.App.AlertDialog.Builder dialog1 = new AlertDialog.Builder(this);
                        AlertDialog alertDialog1 = dialog1.Create();
                        alertDialog1.SetTitle("Restraunt permits/ Hoteli za vyakula");
                        alertDialog1.SetMessage("Nakuru county is a corruption free zone. Apply for available permit");
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
                            btnCancel.Click += BtnCancelPop;
                            alertDialog12.Show();
                        });
                        alertDialog1.SetButton2("Back", (c, ev) => { });
                        alertDialog1.Show();

                        break;
                    case 2:
                        Android.App.AlertDialog.Builder dialog2 = new AlertDialog.Builder(this);
                        AlertDialog alertDialog2 = dialog2.Create();
                        alertDialog2.SetTitle("Hotels / Hoteli kubwa");
                        alertDialog2.SetMessage("Nakuru county is a corruption free zone. Apply for available permit. If you agree please continue.");
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
                            btnCancel.Click += BtnCancelPop;
                            alertDialog12.Show();
                        });
                        alertDialog2.SetButton2("Back", (c, ev) => { });
                        alertDialog2.Show();
                        break;
                    case 3:
                        Android.App.AlertDialog.Builder dialog3 = new AlertDialog.Builder(this);
                        AlertDialog alertDialog3 = dialog3.Create();
                        alertDialog3.SetTitle("Shop permits/ Maduka madogo");
                        alertDialog3.SetMessage("Nakuru county is a corruption free zone. Apply for available permit");
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
                            btnCancel.Click += BtnCancelPop;
                            alertDialog12.Show();
                        });
                        alertDialog3.SetButton2("Back", (c, ev) => { });
                        alertDialog3.Show();
                        break;
                    case 4:
                        Android.App.AlertDialog.Builder dialog4 = new AlertDialog.Builder(this);
                        AlertDialog alertDialog4 = dialog4.Create();
                        alertDialog4.SetTitle("Retailers permits");
                        alertDialog4.SetIcon(Resource.Mipmap.assembly1);
                        alertDialog4.SetMessage("Nakuru county is a corruption free zone. Apply for available permit");
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
                            btnCancel.Click += BtnCancelPop;
                            alertDialog12.Show();
                        });
                        alertDialog4.SetButton2("Back", (c, ev) => { });
                        alertDialog4.Show();
                        break;
                    case 5:
                        Android.App.AlertDialog.Builder dialog5 = new AlertDialog.Builder(this);
                        AlertDialog alertDialog5 = dialog5.Create();
                        alertDialog5.SetTitle("Bars and Clubs permits");
                        alertDialog5.SetIcon(Resource.Mipmap.farm);
                        alertDialog5.SetMessage("Nakuru county is a corruption free zone. Apply for available permit");
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
                            btnCancel.Click += BtnCancelPop;
                            alertDialog12.Show();
                        });
                        alertDialog5.SetButton2("Back", (c, ev) => { });
                        alertDialog5.Show();
                        break;
                    case 6:
                        Android.App.AlertDialog.Builder dialog6 = new AlertDialog.Builder(this);
                        AlertDialog alertDialog6 = dialog6.Create();
                        alertDialog6.SetTitle("Cottage Industries permits/ wachuuzi wa Juakali");
                        alertDialog6.SetMessage("Nakuru county is a corruption free zone. Apply for available permit");
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
                            btnCancel.Click += BtnCancelPop;
                            alertDialog12.Show();
                        });
                        alertDialog6.SetButton2("Back", (c, ev) => { });
                        alertDialog6.Show();
                        break;
                    case 7:
                        Android.App.AlertDialog.Builder dialog7 = new AlertDialog.Builder(this);
                        AlertDialog alertDialog7 = dialog7.Create();
                        alertDialog7.SetTitle("Hawkers permits/ Wachuuzi");
                        alertDialog7.SetIcon(Resource.Mipmap.farm);
                        alertDialog7.SetMessage("Nakuru county is a corruption free zone. Apply for available permit");
                        alertDialog7.SetButton("OK", (c, ev) => {
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
                            btnCancel.Click += BtnCancelPop;
                            alertDialog12.Show();
                        });
                        alertDialog7.SetButton2("Back", (c, ev) => { });
                        alertDialog7.Show();
                        break;
                    case 8:
                        Android.App.AlertDialog.Builder dialog8 = new AlertDialog.Builder(this);
                        AlertDialog alertDialog8 = dialog8.Create();
                        alertDialog8.SetTitle("Salons & Vinyozi Permits");
                        alertDialog8.SetMessage("Nakuru county is a corruption free zone. Apply for available permit");
                        alertDialog8.SetButton("OK", (c, ev) => {
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
                            btnCancel.Click += BtnCancelPop;
                            alertDialog12.Show();
                        });
                        alertDialog8.SetButton2("Back", (c, ev) => { });
                        alertDialog8.Show();
                        break;
                    case 9:
                        Android.App.AlertDialog.Builder dialog9 = new AlertDialog.Builder(this);
                        AlertDialog alertDialog9 = dialog9.Create();
                        alertDialog9.SetTitle("Salons & Vinyozi Permits");
                        alertDialog9.SetMessage("Nakuru county is a corruption free zone. Apply for available permit");
                        alertDialog9.SetButton("OK", (c, ev) => {
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
                            btnCancel.Click += BtnCancelPop;
                            alertDialog12.Show();
                        });
                        alertDialog9.SetButton2("Back", (c, ev) => { });
                        alertDialog9.Show();
                        break;
                }
            };
            // Create your application here
        }

        private void BtnCancelPop(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Exiting, please wait", ToastLength.Short).Show();
            StartActivity(typeof(MainActivity));
        }

        private void BtnOkPop(object sender, EventArgs e)
        {
            LayoutInflater layoutInflaterAndroid1 = LayoutInflater.From(this);
            View myview1 = layoutInflaterAndroid1.Inflate(Resource.Layout.licencepaymentfee, null);
            Android.Support.V7.App.AlertDialog.Builder alertDialogbuilder1 = new Android.Support.V7.App.AlertDialog.Builder(this);
            alertDialogbuilder1.SetView(myview1);
            EditText phone1 = myview1.FindViewById<EditText>(Resource.Id.eText1);
            alertDialogbuilder1.SetCancelable(true)
            .SetPositiveButton("OK", async delegate
            {
                phone = phone1.Text;
                msisdn1 = long.Parse(phone);
                Payments mpesaAPI = new Payments(Env.Sandbox, "bYBiRy4gsWkPjMMcuYDrtT2AjEYnoIrx", "3tUcCxyFXOtOu19m", extraConfig);
                var res = await mpesaAPI.LipaNaMpesaOnline(msisdn, pesa, callUrl, "DevTech Africa");
                var transactionID = res.Data.CheckoutRequestID;
                StartActivity(typeof(MainActivity));
                NotificationCompat.Builder builder = new NotificationCompat.Builder(this, CHANNEL_ID)
                    .SetContentTitle("Gsort Notification")
                    .SetSubText("We have received payment from M-Pesa, you will receive an update after your details have been processed")
                    .SetContentText("Hi, you have a new notification from Nakuru County Government")
                    .SetDefaults(VibrationEffect.DefaultAmplitude)
                    .SetSmallIcon(Resource.Mipmap.shellnaks);
                Notification notification = builder.Build();
                NotificationManager notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;
                const int notificationId = 0;
                notificationManager.Notify(notificationId, notification);
            })
            .SetNegativeButton("Cancel", delegate {

                StartActivity(typeof(Parking));
            });

            Android.Support.V7.App.AlertDialog alertDialog3 = alertDialogbuilder1.Create();
            alertDialog3.Show();
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
        private void BtnBackClick(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
}