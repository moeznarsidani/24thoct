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
using Bumptech.Glide;

namespace App3
{
    class ListAdapter : BaseAdapter<listItem>
    {

        private List<listItem> listData;
        private Activity context;
        public ListAdapter(Activity listActivity, List<listItem> listData) : base()
        {
            this.context = listActivity;
            this.listData = listData;
        }

        public override listItem this[int position]
        {
            get
            {

                return listData[position];

            }

        }
        public override int Count
        {

            get
            {

                return listData.Count;
            }

        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            if (convertView == null)
            {

                view = context.LayoutInflater.Inflate(Resource.Layout.list_item, null, false);

            }
            listItem item = this[position];
            view.FindViewById<TextView>(Resource.Id.textView3).Text = item.Title;
            view.FindViewById<TextView>(Resource.Id.textView2).Text = item.Subtitle;
            view.FindViewById<TextView>(Resource.Id.textView1).Text = item.Distance;

            ImageView myimage = view.FindViewById<ImageView>(Resource.Id.imageView1);
            Glide.With(context).Load(item.Image).Into(myimage);

            return view;
        }
      /*  public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = null;

            listItem item = this[position];
            if (item.Id % 2 == 0)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.list_item, null, false);
            }
            else
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.list_item2, null, false);
            }
            view.FindViewById<TextView>(Resource.Id.textView3).Text = item.Title;
            view.FindViewById<TextView>(Resource.Id.textView2).Text = item.Subtitle;
            view.FindViewById<TextView>(Resource.Id.textView1).Text = item.Distance;

            item.GetType();
            ImageView myimage = view.FindViewById<ImageView>(Resource.Id.imageView1);
            Glide.With(context).Load(item.Image).Into(myimage);

            return view;*/
        }
    }
