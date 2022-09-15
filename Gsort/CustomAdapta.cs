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
    public class ViewHolder2 : Java.Lang.Object
    {
        public TextView fname1 { get; set; }
        public TextView lname1 { get; set; }
        public TextView phone2 { get; set; }
        public TextView Docpath1 { get; set; }
        public TextView Nid1 { get; set; }
        public TextView Chkbox1 { get; set; }
    }
    class CustomAdapta : BaseAdapter
    {
        private readonly Activity context;
        private List<Nyumba> listMwenyewe1;
        public override int Count
        {
            get
            {
                return listMwenyewe1.Count;
            }
        }
        public CustomAdapta(Activity context, List<Nyumba> listMwenyewe1)
        {
            this.context = context;
            this.listMwenyewe1 = listMwenyewe1;
        }
        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return listMwenyewe1[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ViewHolder2 viewHolder;
            if (convertView == null)
            {

                convertView = LayoutInflater.From(context).Inflate(Resource.Layout.nbsupport, null, true);
                viewHolder = new ViewHolder2
                {
                    fname1 = convertView.FindViewById<TextView>(Resource.Id.txtView1),
                    lname1 = convertView.FindViewById<TextView>(Resource.Id.txtView2),
                    phone2 = convertView.FindViewById<TextView>(Resource.Id.txtView3),
                    Docpath1 = convertView.FindViewById<TextView>(Resource.Id.txtView4),
                    Nid1 = convertView.FindViewById<TextView>(Resource.Id.txtView5),
                    Chkbox1 = convertView.FindViewById<TextView>(Resource.Id.txtView6)
                };
                convertView.Tag = viewHolder;
                var name = listMwenyewe1[position].Name;
                viewHolder.fname1.Text = name;
                var names = listMwenyewe1[position].RoomSize;
                viewHolder.lname1.Text = names;
                var name1 = listMwenyewe1[position].Rent;
                viewHolder.phone2.Text = name1;
                var names11 = listMwenyewe1[position].Available;
                viewHolder.Nid1.Text = names11;
                var names1 = listMwenyewe1[position].SubCounty;
                viewHolder.Docpath1.Text = names1;/*
                var name11 = Count1;
                viewHolder.Chkbox1.Text = name;
                var names11 = Nid[position];
                viewHolder.Nid1.Text = names;*/
                return convertView;
            }
            else
            {
                viewHolder = (ViewHolder2)convertView.Tag;
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