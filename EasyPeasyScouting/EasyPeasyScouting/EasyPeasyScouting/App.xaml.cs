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

        protected async override void OnStart()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "data.txt");
            string value = "";

            using (StreamReader sr = new StreamReader(path))
            {
                value = await sr.ReadToEndAsync();
                Robots.list = JsonConvert.DeserializeObject<List<Robot>>(value);
            }

            if(Robots.list == null)
            {
                Robots.list = new List<Robot>();
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
