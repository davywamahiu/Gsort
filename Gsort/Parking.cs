using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Gsort.Mwanzowadata;
using System.Threading.Tasks;
using static Gsort.Mwanzowadata.Payments;
using System.Net.Http;
using Java.Util;
using Firebase.Database;
using System.Net;
using System.IO;
using System.Text;

namespace Gsort
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = false)]
    public class Parking : Activity
    {
        ListView chaguola;
        public static string CHANNEL_ID = "10023";
        Mwenyewe1 _chaguo = new Mwenyewe1();
        List<string> _pick2c = new List<string>();
        List<string> _pick1c = new List<string>();
        List<string> _chagua = new List<string>();
        private DatabaseReference db;
        ArrayAdapter<string> arrayAdapter;
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
            SetContentView(Resource.Layout.parking);
            string status;
            string status1;
            string seconditem;
            chaguola = (ListView)FindViewById(Resource.Id.listView101);
            _chaguo.Id = 1;
            _chaguo.Name = "Nakuru Town";
            _chaguo.Kielelezo = "Hii inatumka katika kuegesha magari kote Nakuru.  Has universal application across the county";
            _chagua.Add(_chaguo.ToString());
            _chaguo.Id = 2;
            _chaguo.Name = "Naivasha Town";
            _chaguo.Kielelezo = "Hii inatumka katika kuegesha magari kote Nakuru.  Has universal application across the county";
            _chagua.Add(_chaguo.ToString());
            _chaguo.Id = 3;
            _chaguo.Name = "GilGil Town";
            _chaguo.Kielelezo = "Hii inatumka katika kuegesha magari GilGil Nakuru na Naivasha. Used in GilGil and Naivasha";
            _chagua.Add(_chaguo.ToString());
            _chaguo.Id = 4;
            _chaguo.Name = "Molo Town";
            _chaguo.Kielelezo = "Hii inatumka katika kuegesha magari Molo na Nakuru Mjini.  Used in Molo and Nakuru";
            _chagua.Add(_chaguo.ToString());
            arrayAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSelectableListItem, _chagua);
            chaguola.Adapter = arrayAdapter;
            chaguola.ItemClick += (s, e) =>
            {
                for (int i = 0; i < chaguola.Count; i++)
                {
                    if (e.Position == i)
                    {
                        chaguola.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.ForestGreen);
                        
                    }
                    else
                    {
                        chaguola.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Transparent);
                    }
                }
                LayoutInflater layoutInflaterAndroid1 = LayoutInflater.From(this);
                View myview1 = layoutInflaterAndroid1.Inflate(Resource.Layout.sparking, null);
                Android.Support.V7.App.AlertDialog.Builder alertDialogbuilder1 = new Android.Support.V7.App.AlertDialog.Builder(this);
                alertDialogbuilder1.SetView(myview1);
                var userContent0 = myview1.FindViewById<EditText>(Resource.Id.eText11);
                var userContent4 = myview1.FindViewById<EditText>(Resource.Id.eText22);
                var userContent5 = myview1.FindViewById<EditText>(Resource.Id.eText33);
                var userContent6 = myview1.FindViewById<ListView>(Resource.Id.lstView44);
                var usercontent7 = myview1.FindViewById<Spinner>(Resource.Id.spinner1);
                Servies servies = new Servies();
                servies.Nhiff = "Pay/Lipa na M-PESA";
                _pick1c.Add(servies.ToString());
                arrayAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SelectDialogSingleChoice, _pick1c);
                userContent6.Adapter = arrayAdapter;
                alertDialogbuilder1.SetCancelable(true)
                .SetPositiveButton("Cancel", delegate
                {
                    Toast.MakeText(this, "Exitin please wait ... ", ToastLength.Short).Show();
                })
                .SetNegativeButton("Confirm Pay", delegate
                {
                    LayoutInflater layoutInflaterAndroid2 = LayoutInflater.From(this);
                    View myview2 = layoutInflaterAndroid2.Inflate(Resource.Layout.sparkings, null);
                    Android.Support.V7.App.AlertDialog.Builder alertDialogbuilder2 = new Android.Support.V7.App.AlertDialog.Builder(this);
                    alertDialogbuilder2.SetView(myview2);

                    var userContent3 = myview2.FindViewById<ListView>(Resource.Id.listView1);
                    Servies servies1 = new Servies();
                    servies1.Nhiff = "KSh 5,000";
                    _pick2c.Add(servies1.ToString());
                    servies1.Nhiff = "Ksh 2,500";
                    _pick2c.Add(servies1.ToString());
                    servies1.Nhiff = "Ksh 1,500";
                    _pick2c.Add(servies1.ToString());
                    servies1.Nhiff = "KSh 150";
                    _pick2c.Add(servies1.ToString());
                    arrayAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SelectDialogSingleChoice, _pick2c);
                    userContent3.Adapter = arrayAdapter;
                    userContent3.ItemClick += (r, w) => {
                        for (int i = 0; i < userContent3.Count; i++)
                        {
                            if (w.Position == i)
                            {
                                userContent3.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.ForestGreen);
                                seconditem = _pick2c[w.Position];
                                var timeStamp = DateTime.Now.ToString("yyyy");
                                var timeStamp1 = DateTime.Now.ToString("MM");
                                var timeStamp2 = DateTime.Now.ToString("dd");
                                var timeStamp3 = DateTime.Now.ToString("hh");
                                var timeStamp4 = DateTime.Now.ToString("mm");

                                var timeStamp5 = DateTime.Now.ToString("hh");
                                var ucode = Guid.NewGuid();
                                string GuidString = Convert.ToBase64String(ucode.ToByteArray());
                                GuidString = GuidString.Replace("=", "");
                                GuidString = GuidString.Replace("+", "");
                                GuidString = GuidString.Replace("/", "");
                                GuidString = GuidString.Replace("a", "");
                                GuidString = GuidString.Replace("b", "");
                                GuidString = GuidString.Replace("c", "");
                                GuidString = GuidString.Replace("d", "");
                                GuidString = GuidString.Replace("c", "");
                                GuidString = GuidString.Replace("d", "");
                                GuidString = GuidString.Replace("f", "");
                                GuidString = GuidString.Replace("g", "");
                                GuidString = GuidString.Replace("h", "");
                                GuidString = GuidString.Replace("e", "");
                                GuidString = GuidString.Replace("i", "");
                                GuidString = GuidString.Replace("j", "");
                                GuidString = GuidString.Replace("k", "");
                                GuidString = GuidString.Replace("m", "");
                                GuidString = GuidString.Replace("o", "");
                                GuidString = GuidString.Replace("n", "");
                                GuidString = GuidString.Replace("p", "");
                                GuidString = GuidString.Replace("q", "");
                                GuidString = GuidString.Replace("r", "");
                                GuidString = GuidString.Replace("s", "");
                                GuidString = GuidString.Replace("t", "");
                                GuidString = GuidString.Replace("u", "");
                                GuidString = GuidString.Replace("v", "");
                                GuidString = GuidString.Replace("w", "");
                                GuidString = GuidString.Replace("x", "");
                                GuidString = GuidString.Replace("y", "");
                                GuidString = GuidString.Replace("z", "");
                                status1 = _chagua[e.Position];
                                status = timeStamp+"/"+timeStamp1+"/"+timeStamp2+" "+timeStamp3+":"+timeStamp4;
                                string phone = userContent0.Text;
                                string plate = userContent4.Text;
                                CallMpesaApIAsync();
                                string idno = GuidString+" Confirmed. "+seconditem+" sent to Nakuru County Parking account 899334 on "+timeStamp+"/"+timeStamp1+"/"+timeStamp2+" at"+" "+timeStamp3+":"+timeStamp4+". New Mpesa balance is Ksh0.00. Transaction cost, Ksh0.00. To reverse, foward this message to 456";

                                HashMap hasMapdavy = new HashMap();
                                hasMapdavy.Put("Origin", plate);
                                hasMapdavy.Put("Amount", seconditem);
                                hasMapdavy.Put("statement", idno);
                                hasMapdavy.Put("Date", status);
                                hasMapdavy.Put("Town", status1);
                                hasMapdavy.Put("Plate", phone);
                                db = FirebaseDatabase.GetInstance("https://gsort-398b4.firebaseio.com/").GetReference("Countyc32").Push();
                                db.SetValue(hasMapdavy);
                            }
                            else
                            {
                                userContent3.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Transparent);
                            }
                        }
                    };
                    alertDialogbuilder2.SetCancelable(true)
                    .SetPositiveButton("Cancel", delegate
                    {
                        Toast.MakeText(this, "Exitin please wait ... ", ToastLength.Short).Show();
                        alertDialogbuilder2.Dispose();
                    })
                    .SetNegativeButton("Confirm Pay", async delegate
                    {

                        

                        //resp = db.Child("test");
                        //await resp.SetValueAsync("Nothing to show");

                    });
                    Android.Support.V7.App.AlertDialog alertDialog2 = alertDialogbuilder2.Create();
                    alertDialog2.Show();
                });
                Android.Support.V7.App.AlertDialog alertDialog3 = alertDialogbuilder1.Create();
                alertDialog3.Show();
            };
            Button btnback = FindViewById<Button>(Resource.Id.btn5);
            btnback.Click += BtnBackClick;
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

        private void CreateUser()
        {
            
        }

        private static async  Task MakeRequest()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(new Uri("http://requestbin.net/r/1hrnplc1"));
            var body = await response.Content.ReadAsStringAsync();
            Console.WriteLine(body);
        }

        private void BtnBackClick(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
    /*static void Main(string[] args)
    {
       Console.Title = "STK push";
                    string a = "https://sandbox.safaricom.co.ke/mpesa/stkpush/v1/processrequest";
                    string baseUrl = a;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseUrl);
                    string token = "WoXqAJV9QgrNWrY7uomnU6XSceMd";
                    request.Headers.Add("authorization", "Bearer " + token);
                    request.ContentType = "application/json";
                    request.Headers.Add("cache-control", "no-cache");
                    request.KeepAlive = false;
                    request.Method = "POST";
                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        string json = "{\"BussinessShortCode\":\"174379\"," + 
                        "\"Password\":\"MTc0Mzc5YmZiMjc5ZjlhYTliZGJjZjE1OGU5N2RkNzFhNDY3Y2QyZTBjODkzMDU5YjEwZjc4ZTZiNzJhZGExZWQyYzkxOTIwMjAxMjMwMjM0MzIz\"," + 
                        "\"Timestamp\":\"20201230234323\"," + 
                        "\"TransactionType\":\"CustomerPayBillOnline\"," + 
                        "\"Amount\":\"1\"," + 
                        "\"PartyA\":\"254726683199\"," +
                                "\"PartyB\":\"174379\"," + 
                                "\"PhoneNumber\":\"254726683199\"," + 
                                "\"CallBackURL\":\"http://requestbin.net/r/1mbf1v01\"," + 
                                "\"AccountReference\":\"Dev Tech Africa\"," + 
                                "\"TransactionDesc\":\"Test purpopose\"}"; 
                        streamWriter.Write(json);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                    try
                    {

                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        Stream receiveStream = response.GetResponseStream();
                        StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                        Console.WriteLine(readStream.ReadToEnd());
                        response.Close();
                        readStream.Close();
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
                    catch (WebException ex)
                    {
                        var resp = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                        Console.WriteLine(resp);
                        StartActivity(typeof(Parking));
                    }*/
    /*private string GenerateSafaricomToken(string consumerKey, string consumerSecret, string grantType)
    {
        RestClient restClient = new RestClient
        {
            BaseUrl = new Uri("https://sanbox.safaricom.co.ke"), Authenticator = new HttpBasicAuthenticator(consumerKey, consumerSecret)
        };
        RestRequest restRequest = new RestRequest("/oauth/v1/generate", Method.GET);
        restRequest.AddParameter("grant_type", "client_credentials", ParameterType.QueryString);
        IRestResponse restResponse = restClient.Execute(restRequest);
        if (restResponse != null && ! string.IsNullOrEmpty(restResponse.Content))
        {
            TokenResponse tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(restResponse.Content);
            return restResponse.Content;
        }
        return string.Empty;
    }*/
    public class Mwenyewe1
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Kielelezo { get; set; }

        public int ImagId { get; set; }

        public override string ToString()
        {
            const string V = " ";
            return Id + V + Name + "\n" + V + Kielelezo;
        }
    }
   /* public class TokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessCode
        {
            get; set;
        }
        [JsonProperty("expires_in")]
        public int ExpiryDate { get; set; }
    }*/
}