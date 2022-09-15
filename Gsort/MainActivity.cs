using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Firebase.Database;
using Java.Interop;
using Java.Util;

namespace Gsort
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = false)]
    public class MainActivity : AppCompatActivity
    {
        readonly string[] jengo = { "Health Services/ Huduma za Afya", "Tenders/Utoaji Zabuni", "Business Permits/Leseni za Biashara", "Land Rates/Malipo ya shamba", "Housing Rates/Malipo ya kodi", "Market/Soko", "Parking/Kuegesha Magari", "Garbage Collection/Uzoaji Taka", "Nakuru County Information Center" };
        readonly string[] kuhusu = {"Manage Your Health via app/Mudu afya yako leo",
                           "Want to work with us learn how/Pata zabuni za Kaunti bila kutoa rushwa",
                           "Apply for License/Pata Leseni kwa urahisi",
                           "Pay your rates/Lipia kodi ya shamba hapa",
                           "Landlords only/Wenye nyumba za kukodisha pekee",
                           "Sell your farm produce here/Uza bidhaa zako hapa",
                           "For best parking experience subscribe to our services/Nunua tiketi yako ya kuegesha gari hapa",
                           "Gargage collection at affordable cost/Zoa taka kwa bei nafuu",
                           "Get all information about Nakuru County/Pata jumbe kuhusu Nakuru",};
        readonly int[] picha = { Resource.Drawable.medical, Resource.Drawable.tender001, Resource.Drawable.permits, Resource.Drawable.landrates, Resource.Drawable.rentals, Resource.Drawable.soko9, Resource.Drawable.parking001, Resource.Drawable.recycle, Resource.Drawable.gavana };

        ListView chaguola;
        private SearchView SearchView;
        Mwenyewe _chaguo = new Mwenyewe();
        List<string> _chagua = new List<string>();
        ArrayAdapter<string> arrayAdapter;
        Button btnsend;
        EditText phonenumber;
        EditText suggestion;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_main);
            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
            // FirebaseApp.InitializeApp(Gsort);
            //SearchView Srch = FindViewById<SearchView>(Resource.Id.searchView4);
            chaguola = (ListView)FindViewById(Resource.Id.listView7);
            var adapter = new CustomLstView1(this, jengo, kuhusu, picha);
            chaguola.Adapter = adapter;

            //Srch.QueryTextChange += Srch_QuerTextChange;
            chaguola.ItemClick += (s, e) =>
            {
                Intent naksIntent;
                switch (e.Position)
                {
                    case 0:
                        naksIntent = new Intent(this, typeof(Health));
                        StartActivity(typeof(Health));
                        break;
                    case 1:
                        naksIntent = new Intent(this, typeof(Tender));
                        StartActivity(typeof(Tender));
                        break;
                    case 2:
                        naksIntent = new Intent(this, typeof(LandRates));
                        StartActivity(typeof(LandRates));
                        break;
                    case 3:
                        naksIntent = new Intent(this, typeof(Housing));
                        StartActivity(typeof(Housing));
                        break;
                    case 4:
                        naksIntent = new Intent(this, typeof(Rental));
                        StartActivity(typeof(Rental));
                        break;
                    case 5:
                        naksIntent = new Intent(this, typeof(Market));
                        StartActivity(typeof(Market));
                        break;
                    case 6:
                        naksIntent = new Intent(this, typeof(Parking));
                        StartActivity(typeof(Parking));
                        break;
                    case 7:
                        naksIntent = new Intent(this, typeof(Gioto));
                        StartActivity(typeof(Gioto));
                        break;
                    case 8:
                        naksIntent = new Intent(this, typeof(NoticeBoard));
                        StartActivity(typeof(NoticeBoard));
                        break;
                }
            };
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            
        }
        
        /*private void Srch_QuerTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            adapter.Filter.InvokeFilter(e.NewText);
        }*/

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            IMenuItem item = menu.FindItem(Resource.Id.action_searchme);
            SearchView = item.ActionView.JavaCast<SearchView>();
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_login)
            {
                StartActivity(typeof(Login));
                OverridePendingTransition(Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out);
            }
            if (id == Resource.Id.action_signup)
            {
                StartActivity(typeof(Register));
                OverridePendingTransition(Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out);
            }
            if (id == Resource.Id.action_settings)
            {
                StartActivity(typeof(Settings));
                OverridePendingTransition(Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out);
            }
            if (id == Resource.Id.action_back)
            {
                StartActivity(typeof(MainActivity));
                OverridePendingTransition(Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out);
            }
            if (id == Resource.Id.action_care)
            {
                StartActivity(typeof(MainActivity));
                OverridePendingTransition(Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out);
            }
            if (id == Resource.Id.action_searchme)
            {
                OverridePendingTransition(Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out);
            }
            return base.OnOptionsItemSelected(item);
        }
        private DatabaseReference databaseReference;
        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            LayoutInflater layoutInflaterAndroid2 = LayoutInflater.From(this);
            View myview2 = layoutInflaterAndroid2.Inflate(Resource.Layout.alertme2, null);
            Android.Support.V7.App.AlertDialog.Builder alertDialogbuilder2 = new Android.Support.V7.App.AlertDialog.Builder(this);
            alertDialogbuilder2.SetView(myview2);
            alertDialogbuilder2.SetCancelable(true)
            .SetPositiveButton("Suggestion/Complaints", delegate
            {
                LayoutInflater layoutInflaterAndroid1 = LayoutInflater.From(this);
                View myview1 = layoutInflaterAndroid1.Inflate(Resource.Layout.alertmenow, null);
                Android.Support.V7.App.AlertDialog.Builder alertDialogbuilder1 = new Android.Support.V7.App.AlertDialog.Builder(this);
                alertDialogbuilder1.SetView(myview1);
                btnsend = FindViewById<Button>(Resource.Id.button1);
                phonenumber = FindViewById<EditText>(Resource.Id.editText1);
                suggestion = FindViewById<EditText>(Resource.Id.editText2);
                /*btnsend.Click += delegate
                {
                    HashMap hasMapdavy = new HashMap();
                    hasMapdavy.Put("Origin", phonenumber);
                    hasMapdavy.Put("Amount", suggestion);
                    DatabaseReference db = FirebaseDatabase.GetInstance("https://gsort-398b4.firebaseio.com/").GetReference("CountyLine").Push();
                    db.SetValue(hasMapdavy);
                };*/
                alertDialogbuilder1.SetCancelable(true)
                .SetPositiveButton("OK", delegate
                {

                })
                .SetNegativeButton("Cancel", delegate
                {


                });

                Android.Support.V7.App.AlertDialog alertDialog3 = alertDialogbuilder1.Create();
                alertDialog3.Show();
            })
            .SetNegativeButton("Exit", delegate
            {


            });

            Android.Support.V7.App.AlertDialog alertDialog2 = alertDialogbuilder2.Create();
            alertDialog2.Show();
            
        }

        private async void Btnsend_ClickAsync(object sender, EventArgs e)
        {
            
        }
    }

    public class Mwenyewe
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Kielelezo { get; set; }

        public int ImagId { get; set; }

        public override string ToString()
        {
            const string V = " ";
            return Id + V + Name + "\n" + ImagId + V + Kielelezo;
        }
    }
}

