using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Gsort
{
    public class ViewHolder5 : Java.Lang.Object
    {
        public TextView txt1;
        public TextView txt2;
        public ImageView img1;
    }
    public class CustomLstView1 : BaseAdapter
    {
        private readonly Activity context;
        private string[] jengo;
        private readonly string[] kuhusu;
        private readonly int[] picha;
        public override int Count
        {
            get
            {
                return jengo.Length;
            }
        }
        public CustomLstView1(Activity context, string[] jengo, string[] kuhusu, int[] picha)
        {
            this.context = context;
            this.jengo = jengo;
            this.kuhusu = kuhusu;
            this.picha = picha;
        }
        public override Java.Lang.Object GetItem(int position)
        {
            return jengo[position];
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ViewHolder5 viewHolder;
            if (convertView == null)
            {

                convertView = LayoutInflater.From(context).Inflate(Resource.Layout.smarket, null, true);
                viewHolder = new ViewHolder5
                {
                    txt1 = convertView.FindViewById<TextView>(Resource.Id.txtView1),
                    txt2 = convertView.FindViewById<TextView>(Resource.Id.txtView2),
                    img1 = convertView.FindViewById<ImageView>(Resource.Id.imageView1)
                };
                convertView.Tag = viewHolder;
                var name = jengo[position];
                viewHolder.txt1.Text = name;
                var names = kuhusu[position];
                viewHolder.txt2.Text = names;
                viewHolder.img1.SetImageResource(picha[position]);
                return convertView;
            }
            else
            {
                viewHolder = (ViewHolder5)convertView.Tag;
                try
                {
                    return convertView;
                }
                catch (Java.Lang.Exception)
                {
                    return null;
                }
            }
        }
    }
}