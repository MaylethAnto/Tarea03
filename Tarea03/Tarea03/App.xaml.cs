﻿using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using Tarea03.ViewModel;

namespace Tarea03
{
    public partial class App : Application
    {
        static SQLiteHelper db;

        public static SQLiteHelper SQLiteDb
        {
            get
            {
                if (db == null)
                {
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "XamarinSQLite.db3");
                    db = new SQLiteHelper(dbPath);
                }
                return db;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
        

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
