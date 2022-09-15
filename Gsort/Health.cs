using System;
using System.Collections;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.View;
using Android.Views;
using Android.Webkit;
using Android.Widget;

namespace Gsort
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = false)]
    public class Health : Activity
    {
        private readonly string txturl = "http://www.google.com";

        // private static readonly int ButtonClickNotification = 9999;
        private WebView web_view;
        ListView txtView1;
        Servies servies = new Servies();
        Mwenda mwenda = new Mwenda();
        Bravo bravo = new Bravo();
        Mwenyewe _pick1 = new Mwenyewe();
        List<string> _pick1b = new List<string>();
        List<string> _pick1a = new List<string>();
        List<string> _pick1c = new List<string>();
        List<string> _pick1d = new List<string>();
        ArrayAdapter<string> arrayAdapter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.tender);
            // Create your application here
            txtView1 = FindViewById<ListView>(Resource.Id.listView72);
            _pick1.Id = 1;
            _pick1.Name = "Level V Hospitals";
            _pick1.Kielelezo = "Formerly provincial Hospitals, Nakuru PGH";
            _pick1a.Add(_pick1.ToString());
            _pick1.Id = 2;
            _pick1.Name = "Level IV Hospitals";
            _pick1.Kielelezo = "Formerly District Hospitals, Molo";
            _pick1a.Add(_pick1.ToString());
            txtView1.Adapter = arrayAdapter;
            arrayAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSelectableListItem, _pick1a);
            txtView1.Adapter = arrayAdapter;
            txtView1.ItemClick += (s, e) =>
            {
                for (int i = 0; i < txtView1.Count; i++)
                {
                    if (e.Position == i)
                    {
                        string product = e.ToString();
                        txtView1.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.ForestGreen);
                    }
                    else
                    {
                        txtView1.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Transparent);
                    }
                }
                switch (e.Position)
                {
                    case 0:
                        LayoutInflater layoutInflaterAndroid = LayoutInflater.From(this);
                        View myview = layoutInflaterAndroid.Inflate(Resource.Layout.hosi, null);
                        Android.Support.V7.App.AlertDialog.Builder alertDialogbuilder = new Android.Support.V7.App.AlertDialog.Builder(this);
                        alertDialogbuilder.SetView(myview);

                        var userContent = myview.FindViewById<ListView>(Resource.Id.listView1);
                        bravo.CountyHosi = "Nakuru Level 5 PGH";
                        _pick1d.Add(bravo.ToString());
                        bravo.CountyHosi = "Naivasha Level 4 Hospital";
                        _pick1d.Add(bravo.ToString());
                        bravo.CountyHosi = "Annex level 5 Hospital";
                        _pick1d.Add(bravo.ToString());
                        bravo.CountyHosi = "Aga Khan Hospital private";
                        _pick1d.Add(bravo.ToString());
                        bravo.CountyHosi = "Valley Hospital private";
                        _pick1d.Add(bravo.ToString());
                        arrayAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItemChecked, _pick1d);
                        userContent.Adapter = arrayAdapter;
                        alertDialogbuilder.SetCancelable(false)
                        .SetPositiveButton("Send", delegate
                        {
                            LayoutInflater layoutInflaterAndroid2 = LayoutInflater.From(this);
                            View myview2 = layoutInflaterAndroid2.Inflate(Resource.Layout.status, null);
                            Android.Support.V7.App.AlertDialog.Builder alertDialogbuilder2 = new Android.Support.V7.App.AlertDialog.Builder(this);
                            alertDialogbuilder2.SetView(myview2);

                            var userContent2 = myview2.FindViewById<ListView>(Resource.Id.lstView3);
                            servies.Nhiff = "Beyond Zero";
                            _pick1c.Add(servies.ToString());
                            servies.Nhiff = "NHIF covered";
                            _pick1c.Add(servies.ToString());
                            servies.Nhiff = "Universal Health coverage";
                            _pick1c.Add(servies.ToString());
                            servies.Nhiff = "County Health Policy";
                            _pick1c.Add(servies.ToString());
                            servies.Nhiff = "Personal Health Policy";
                            _pick1c.Add(servies.ToString());
                            servies.Nhiff = "Others";
                            _pick1c.Add(servies.ToString());
                            arrayAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSelectableListItem, _pick1c);
                            userContent2.Adapter = arrayAdapter;
                            alertDialogbuilder2.SetCancelable(true)
                            .SetPositiveButton("EXIT", delegate
                            {
                                Toast.MakeText(this, "Exiting ... ", ToastLength.Short).Show();
                            })
                            .SetNegativeButton("NHIF register", delegate
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
                            });
                            Android.Support.V7.App.AlertDialog alertDialog2 = alertDialogbuilder2.Create();
                            alertDialog2.Show();
                        })
                        .SetNegativeButton("Cancel", delegate
                        {
                            alertDialogbuilder.Dispose();
                        });
                        Android.Support.V7.App.AlertDialog alertDialog = alertDialogbuilder.Create();
                        alertDialog.Show();
                        break;
                    case 1:
                        LayoutInflater layoutInflaterAndroid1 = LayoutInflater.From(this);
                        View myview1 = layoutInflaterAndroid1.Inflate(Resource.Layout.hositwo, null);
                        Android.Support.V7.App.AlertDialog.Builder alertDialogbuilder1 = new Android.Support.V7.App.AlertDialog.Builder(this);
                        alertDialogbuilder1.SetView(myview1);

                        var userContent1 = myview1.FindViewById<ListView>(Resource.Id.listView2);
                        mwenda.Hosi = "Molo Sub County Hospital";
                        _pick1b.Add(mwenda.ToString());
                        mwenda.Hosi = "Bahati Sub County Hospital";
                        _pick1b.Add(mwenda.ToString());
                        mwenda.Hosi = "Subukia Sub County Hospital";
                        _pick1b.Add(mwenda.ToString());
                        mwenda.Hosi = "GilGil Sub County Hospital";
                        _pick1b.Add(mwenda.ToString());
                        mwenda.Hosi = "Naivasha Sub County Hospital";
                        _pick1b.Add(mwenda.ToString());
                        mwenda.Hosi = "Bahati Sub County Hospital";
                        _pick1b.Add(mwenda.ToString());
                        arrayAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItemChecked, _pick1b);
                        userContent1.Adapter = arrayAdapter;
                        userContent1.ItemClick += delegate
                        {

                        };
                        alertDialogbuilder1.SetCancelable(false)
                        .SetPositiveButton("Send", delegate
                        {
                            LayoutInflater layoutInflaterAndroid2 = LayoutInflater.From(this);
                            View myview2 = layoutInflaterAndroid2.Inflate(Resource.Layout.bravo, null);
                            Android.Support.V7.App.AlertDialog.Builder alertDialogbuilder2 = new Android.Support.V7.App.AlertDialog.Builder(this);
                            alertDialogbuilder2.SetView(myview2);
                            var userContent2 = myview2.FindViewById<ListView>(Resource.Id.lstView3);
                            servies.Nhiff = "Beyond Zero";
                            _pick1c.Add(servies.ToString());
                            servies.Nhiff = "NHIF covered";
                            _pick1c.Add(servies.ToString());
                            servies.Nhiff = "Universal Health coverage";
                            _pick1c.Add(servies.ToString());
                            servies.Nhiff = "County Health Policy";
                            _pick1c.Add(servies.ToString());
                            servies.Nhiff = "Personal Health Policy";
                            _pick1c.Add(servies.ToString());
                            servies.Nhiff = "Others";
                            _pick1c.Add(servies.ToString());
                            arrayAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSelectableListItem, _pick1c);
                            userContent2.Adapter = arrayAdapter;
                            alertDialogbuilder2.SetCancelable(true)
                            .SetPositiveButton("EXIT", delegate
                            {
                                Toast.MakeText(this, "Exiting ... ", ToastLength.Short).Show();
                            })
                            .SetNegativeButton("NHIF register", delegate
                            {
                                try
                                {
                                    /*LayoutInflater layoutInflaterAndroid3 = LayoutInflater.From(this);
                                    View myview3 = layoutInflaterAndroid3.Inflate(Resource.Layout.safirinhif, null);*/
                                    SetContentView(Resource.Layout.safirinhif);
                                    web_view = FindViewById<WebView>(Resource.Id.webView1);
                                    web_view.SetWebViewClient(new NhifWebClient());
                                    web_view.LoadUrl(txturl.ToString());
                                    WebSettings webSettings = web_view.Settings;
                                    webSettings.JavaScriptEnabled = true;
                                    Button btnback1 = FindViewById<Button>(Resource.Id.btn5);
                                    btnback1.Click += BtnBackClick;
                            }
                                catch (Exception)
                                {
                                    Toast.MakeText(this, "Failed to open link, check internet connection", ToastLength.Long).Show();
                                }
                            });
                            Android.Support.V7.App.AlertDialog alertDialog2 = alertDialogbuilder2.Create();
                            alertDialog2.Show();

                            /*Bundle valueSend = new Bundle();
                            valueSend.PutString("SendContent", "Your request has been received successfuly");
                            naksIntent = new Intent(this, typeof(NoticeBoard));
                            naksIntent.PutExtras(valueSend);
                            Android.Support.V4.App.TaskStackBuilder stackBuilder = Android.Support.V4.App.TaskStackBuilder.Create(this);
                            stackBuilder.AddParentStack(Java.Lang.Class.FromType(typeof(NoticeBoard)));
                            stackBuilder.AddNextIntent(naksIntent);
                            PendingIntent resultPendingIntent = stackBuilder.GetPendingIntent(0, (int)PendingIntentFlags.UpdateCurrent);
                            NotificationCompat.Builder builder = new NotificationCompat.Builder(this)
                            .SetAutoCancel(true)
                            .SetContentIntent(resultPendingIntent)
                            .SetContentTitle("Gsort Notifications")
                            .SetSmallIcon(Resource.Drawable.popup_android_close_icon)
                            .SetContentText("You have a new notification");
                            NotificationManager notificationManager = (NotificationManager)GetSystemService(NotificationService);
                            notificationManager.Notify(ButtonClickNotification, builder.Build());
                            Toast.MakeText(this, "Sending content ... " + userContent1, ToastLength.Long).Show();*/
                        })
                        .SetNegativeButton("Cancel", delegate
                        {
                            alertDialogbuilder1.Dispose();
                        });
                        Android.Support.V7.App.AlertDialog alertDialog1 = alertDialogbuilder1.Create();
                        alertDialog1.Show();
                        break;
                }
            };
            Button btnback = FindViewById<Button>(Resource.Id.btn5);
            btnback.Click += BtnBackClick;
        }

        private void BtnBackClick(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
        /* */
    }
    internal class NhifWebClient : WebViewClient
    {

        public override bool ShouldOverrideUrlLoading(WebView view, string url)
        {
            view.LoadUrl(url);
            return true;
        }
    }
    public class Mkangai
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Kielelezo { get; set; }

        public override string ToString()
        {
            const string V = " ";
            return Id + V + Name + "\n" + V+V + Kielelezo;
        }
    }
    public class Mwenda
    {
        public string Hosi { get; set; }
        public override string ToString()
        {
            return Hosi;
        }
    }
    public class Servies
    {
        public string Nhiff { get; set; }
        public override string ToString()
        {
            return Nhiff;
        }
    }
    public class Bravo
    {
        public string CountyHosi { get; set; }
        public override string ToString()
        {
            return CountyHosi;
        }
    }
}