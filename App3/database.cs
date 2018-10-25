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
using SQLite;
namespace App3
{
    class Database
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);



        public bool CreateDatabse()

        {

            try

            {

                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ListItem.db")))

                {

                    connection.CreateTable<listItem>();

                    return true;



                }

            }

            catch (SQLiteException e)

            {

                Log.Info("Error", e.Message);

                return false;

            }

        }







        public bool insert(listItem item)

        {

            try

            {

                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ListItem.db")))

                {

                    connection.Insert(item);

                    return true;



                }

            }

            catch (SQLiteException e)

            {

                return false;

            }

        }



        public List<listItem> Getallitems()

        {

            try

            {

                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ListItem.db")))

                {



                    return connection.Table<listItem>().ToList();





                }

            }

            catch (SQLiteException e)

            {
                e.ToString();
                Log.Info("Error", e.Message);

                return null;

            }

        }





        public bool removeItem(listItem item)

        {

            try

            {

                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ListItem.db")))

                {

                    connection.Delete(item);

                    return true;



                }

            }

            catch (SQLiteException e)

            {

                Log.Info("Error", e.Message);

                return false;

            }

        }



        public bool updateItem(listItem item)

        {

            try

            {

                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ListItem.db")))

                {

                    connection.Query<listItem>("update listItem set Title=?, subtitle=?,Distance=? where Id=?", item.Title, item.Subtitle, item.Distance, item.Id);



                    return true;



                }

            }

            catch (SQLiteException e)

            {

                Log.Info("Error", e.Message);

                return false;

            }

        }

        
    }

}