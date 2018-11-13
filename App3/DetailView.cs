using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace App3
{
    [Activity(Label = "DetailView")]
    public class DetailView : AppCompatActivity
    {
        Database db;
        EditText title;
        EditText subtitle;
        EditText distance;
        ImageButton button;
        int PickImageId;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.detailview);
            Android.Support.V7.App.ActionBar actionBar = this.SupportActionBar;
            actionBar.SetHomeButtonEnabled(true);
            actionBar.SetDisplayHomeAsUpEnabled(true);
            db = new Database();
            db.CreateDatabse();
            title = FindViewById<EditText>(Resource.Id.title);
            subtitle = FindViewById<EditText>(Resource.Id.subtitle);
           distance = FindViewById<EditText>(Resource.Id.distance);

            button = FindViewById<ImageButton>(Resource.Id.imageButton1);

            button.Click += Imagepicker;
        }

        private void Imagepicker(object sender, EventArgs e)
        {
            Intent = new Intent();
            Intent.SetType("image/*");
            Intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(Intent, "Select pic"),PickImageId);
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if ((requestCode == PickImageId) && (resultCode == Result.Ok)&&(data!=null))
            {
                Android.Net.Uri uri = data.Data;
                button.SetImageURI(uri);
            }
        }

        /*public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch(item.ItemId)
            {
                case Android.Resource.Id.Home:
                    var intent = new Intent();
                    intent.PutExtra("title", title.Text);
                    intent.PutExtra("subtitle", subtitle.Text);
                    intent.PutExtra("distance", distance.Text);
                    SetResult(Result.Ok, intent);
                    Finish();

                    return true;

                default:
                    return base.OnOptionsItemSelected(item);

            }
        }*/
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:


                    if (String.IsNullOrEmpty(title.Text))

                    {

                        title.Error = "Title cannot be empty";

                    }

                    else if (String.IsNullOrEmpty(subtitle.Text))

                    {

                        subtitle.Error = "Subtitle cannot be empty";

                    }

                    else if (String.IsNullOrEmpty(distance.Text))

                    {

                        distance.Error = "Distance cannot be empty";

                    }

                    else

                    {
                        listItem obj = new listItem();
                        var intent = new Intent();
                        obj.Title = title.Text;
                        obj.Subtitle = subtitle.Text;
                        obj.Distance = distance.Text;
                        db.insert(obj);
                        intent.PutExtra("item has selected", " " + title.Text + "  " + subtitle.Text + " " + distance.Text);
                        SetResult(Result.Ok, intent);
                        Finish();
                    }
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);

            }
        }

    }
}