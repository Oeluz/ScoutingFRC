using System;
using System.IO;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Newtonsoft.Json;


namespace EasyPeasyScouting
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Robots.LoadList();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            try
            {
                string value = "";
                if (!File.Exists("data.txt"))
                {
                    File.CreateText("data.txt");

                }
                else
                {
                    value = File.ReadAllText("data.txt");
                }

                Robots.list = JsonConvert.DeserializeObject<List<Robot>>(value);
            }
            catch(Exception ex)
            {

            }



        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
