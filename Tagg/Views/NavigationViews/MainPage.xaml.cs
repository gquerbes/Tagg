using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Tagg.Views.MapViews;
using Tagg.Views.MessagingViews;

namespace Tagg.Views.NavigationViews
{
    public enum MenuItemType
    {
        Map,
        Listview,
        Messaging
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }


    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            //MenuPages.Add((int)MenuItemType., (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                   
                    case (int)MenuItemType.Map:
                        MenuPages.Add(id, new NavigationPage(new MapPage()));
                        break;
                    case (int)MenuItemType.Listview:
                        MenuPages.Add(id, new NavigationPage(new ContentPage() { Content = new ProfileViews.ProfileListView() }));
                        break;
                    case (int)MenuItemType.Messaging:
                        MenuPages.Add(id, new NavigationPage(new CometMessagingPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = true;
            }
        }
    }


}