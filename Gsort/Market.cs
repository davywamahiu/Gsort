using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Graphics;
using Android.Views;
using Android.Support.V4.Print;
using Android.Support.V4.App;
using System.Net;
using System.IO;
using Gsort.Mwanzowadata;
using static Gsort.Mwanzowadata.Payments;

namespace Gsort
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = false)]
    public class Market : Activity
    {
        ListView masoko;
        List<string> _pick1c = new List<string>();
        List<string> _pick1d = new List<string>();
        public static string CHANNEL_ID = "10023";
        ArrayAdapter<string> arrayAdapter;
        readonly string[] jengo = { "Soko Mjinga", "Masoko Ya Mama Mboga", "Naivasha Fish Market", "Subukia Open Air Market", "Molo Open Air Market", "Solai Animal Market", "GilGil Open Air Animal Market", "Salgaa Open Air Animal Market", "Kaptembua Open Air Animal Market", "Soko Mjinga" };
        readonly string[] kuhusu = {"Soko la kuuzia bidhaa za shambani. Get to sell or buy fresh produce from this market",
                           "Huduma kwa wenye masoko madogo ya kuuzia mboga kwa mafungo madogo ya kila",
                           "Soko la kuuzia samaki from L.Naivasha. Get to sell or buy fish produce from this market",
                           "Soko la kuuzia bidhaa za shambani. Get to sell or buy fresh produce from this market",
                           "Soko la kuuzia Wanyama. Get to sell or buy Cattle from this market",
                           "Soko la kuuzia bidhaa za shambani. Get to sell or buy fresh produce from this market",
                           "Soko la kuuzia bidhaa za shambani. Get to sell or buy fresh produce from this market",
                           "Soko la kuuzia bidhaa za shambani. Get to sell or buy fresh produce from this market",
                           "Soko la kuuzia bidhaa za shambani. Get to sell or buy fresh produce from this market",
                           "Soko la kuuzia bidhaa za shambani. Get to sell or buy fresh produce from this market"};
        readonly int[] picha = { Resource.Drawable.andro, Resource.Drawable.andro4, Resource.Drawable.andro3, Resource.Drawable.andro11, Resource.Drawable.andro12, Resource.Drawable.andro5, Resource.Drawable.andro6, Resource.Drawable.andro7, Resource.Drawable.andro1, Resource.Drawable.andro2 };

        private static readonly ExtraConfig extraConfig = new ExtraConfig
        {
            LNMShortCode = 174379,
            LNMPassWord = "bfb279f9aa9bdbcf158e97dd71a467cd2e0c893059b10f78e6b72ada1ed2c919"
        };
        public string callUrl = "http://requestbin.net/r/tat0wqta";
        public int pesa = 1;
        public static readonly long msisdn = 254726683199;
        public long msisdn1;
        private string phone;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.market);
            masoko = FindViewById<ListView>(Resource.Id.lstVw);
            var adapter = new CustomLstView(this, jengo, kuhusu, picha);
            masoko.Adapter = adapter;
            masoko.ItemClick += (s, e) =>
            {
                LayoutInflater layoutInflaterAndroid1 = LayoutInflater.From(this);
                View myview1 = layoutInflaterAndroid1.Inflate(Resource.Layout.marketable, null);
                Android.Support.V7.App.AlertDialog.Builder alertDialogbuilder1 = new Android.Support.V7.App.AlertDialog.Builder(this);
                alertDialogbuilder1.SetView(myview1);
                var userContent0 = myview1.FindViewById<EditText>(Resource.Id.eText1);
                var userContent4 = myview1.FindViewById<EditText>(Resource.Id.eText2);
                var userContent5 = myview1.FindViewById<EditText>(Resource.Id.eText3);
                var userContent6 = myview1.FindViewById<ListView>(Resource.Id.lstView4);
                Servies servies = new Servies();
                servies.Nhiff = "GilGil";
                _pick1d.Add(servies.ToString());
                servies.Nhiff = "Kuresoi North";
                _pick1d.Add(servies.ToString());
                servies.Nhiff = "Kuresoi South";
                _pick1d.Add(servies.ToString());
                servies.Nhiff = "Nakuru East";
                _pick1d.Add(servies.ToString());
                servies.Nhiff = "Nakuru West";
                _pick1d.Add(servies.ToString());
                servies.Nhiff = "Naivasha";
                _pick1d.Add(servies.ToString());
                servies.Nhiff = "Molo";
                _pick1d.Add(servies.ToString());
                servies.Nhiff = "Njoro";
                _pick1d.Add(servies.ToString());
                servies.Nhiff = "Subukia";
                _pick1d.Add(servies.ToString());
                servies.Nhiff = "Rongai";
                _pick1d.Add(servies.ToString());
                arrayAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SelectDialogSingleChoice, _pick1d);
                userContent6.Adapter = arrayAdapter;
                alertDialogbuilder1.SetCancelable(true)
                .SetPositiveButton("Send Application", delegate
                {

                    CallMpesaApIAsync();
                });
                Android.Support.V7.App.AlertDialog alertDialog2 = alertDialogbuilder1.Create();
                alertDialog2.Show();
                /*Bundle valueSend = new Bundle();
                valueSend.PutString("sendContent", "Your request has been received successfuly");
                Intent naksIntent = new Intent(this, typeof(NoticeBoard));
                naksIntent.PutExtras(valueSend);
                Android.Support.V4.App.TaskStackBuilder stackBuilder = Android.Support.V4.App.TaskStackBuilder.Create(this);
                stackBuilder.AddParentStack(Java.Lang.Class.FromType(typeof(NoticeBoard)));
                stackBuilder.AddNextIntent(naksIntent);
                PendingIntent resultPendingIntent = stackBuilder.GetPendingIntent(0, (int)PendingIntentFlags.UpdateCurrent);
                NotificationCompat.Builder builder = new NotificationCompat.Builder(this)
                .SetAutoCancel(true)
                .SetContentIntent(resultPendingIntent)
                .SetContentTitle("Gsort Notifications")
                .SetSmallIcon(Resource.Drawable.andro)
                .SetContentText("You have a new notification");
                NotificationManager notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);
                notificationManager.Notify(ButtonClickNotification, builder.Build());
                Toast.MakeText(this, "Sending content ... " +userContent.Text+ "!#&^*9.." +userContent1.Text + "!#^-*9__" + userContent2.Text, ToastLength.Long).Show();*/
            };
            // Create your application here
        }
        public void CallMpesaApIAsync()
        {
            LayoutInflater layoutInflaterAndroid1 = LayoutInflater.From(this);
            View myview1 = layoutInflaterAndroid1.Inflate(Resource.Layout.confirmpay, null);
            Android.Support.V7.App.AlertDialog.Builder alertDialogbuilder1 = new Android.Support.V7.App.AlertDialog.Builder(this);
            alertDialogbuilder1.SetView(myview1);
            EditText phone1 = myview1.FindViewById<EditText>(Resource.Id.eText1);
            alertDialogbuilder1.SetCancelable(true)
            .SetPositiveButton("OK", async delegate
            {
                phone = phone1.Text;
                msisdn1 = long.Parse(phone);
                Payments mpesaAPI = new Payments(Payments.Env.Sandbox, "bYBiRy4gsWkPjMMcuYDrtT2AjEYnoIrx", "3tUcCxyFXOtOu19m", extraConfig);
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

    }
}