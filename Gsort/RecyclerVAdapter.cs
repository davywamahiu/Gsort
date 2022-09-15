using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;

namespace Gsort
{
    public class RecyclerVAdapter : RecyclerView.Adapter
    {
        public event EventHandler<RecyclerVAdapterClickEventArgs> ItemClick;
        public event EventHandler<RecyclerVAdapterClickEventArgs> ItemLongClick;
        List<County> items;

        public RecyclerVAdapter(List<County>data)
        {
            this.items = data;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            //Setup your layout here
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.notice1, parent, false);
            //var id = Resource.Layout.__YOUR_ITEM_HERE;
            //itemView = LayoutInflater.From(parent.Context).
            //       Inflate(id, parent, false);

            var vh = new RecyclerVAdapterViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            // Replace the contents of the view with that element
            var holder = viewHolder as RecyclerVAdapterViewHolder;
            holder.Origin.Text = items[position].Origin;
            holder.statement.Text = items[position].statement;
            holder.Date.Text = items[position].Date;
            holder.Plate.Text = items[position].Plate;
            holder.Town.Text = items[position].Town;
            holder.Amount.Text = "parking fee paid"+items[position].Amount;
        }

        public override int ItemCount => items.Count;

        void OnClick(RecyclerVAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(RecyclerVAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);

    }

    public class RecyclerVAdapterViewHolder : RecyclerView.ViewHolder
    {
        //public TextView TextView { get; set; }
        public TextView Origin { get; set; }
        public TextView statement { get; set; }
        public TextView Date { get; set; }
        public TextView Amount { get; set; }
        public TextView Plate { get; set; }
        public TextView Town { get; set; }
        public RecyclerVAdapterViewHolder(View itemView, Action<RecyclerVAdapterClickEventArgs> clickListener,
                            Action<RecyclerVAdapterClickEventArgs> longClickListener) : base(itemView)
        {
            //TextView = v;
            Origin = itemView.FindViewById<TextView>(Resource.Id.textView1);
            statement = itemView.FindViewById<TextView>(Resource.Id.textView2);
            Date = itemView.FindViewById<TextView>(Resource.Id.textView19);
            Plate = itemView.FindViewById<TextView>(Resource.Id.textView4);
            Town = itemView.FindViewById<TextView>(Resource.Id.textView5);
            Amount = itemView.FindViewById<TextView>(Resource.Id.textView3);
            itemView.Click += (sender, e) => clickListener(new RecyclerVAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new RecyclerVAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }

    public class RecyclerVAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}