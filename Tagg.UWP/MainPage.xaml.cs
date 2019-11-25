using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TaggUI.Styles;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Xamarin.Forms;

namespace Tagg.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            Xamarin.FormsMaps.Init(Credentials.Credentials.UWP_MAP_KEY);

            LoadApplication(new Tagg.App());
            var uiSettings = new UISettings();
            SetTheme(uiSettings);
            uiSettings.ColorValuesChanged += UiSettingsOnColorValuesChanged;

        }

        private void UiSettingsOnColorValuesChanged(UISettings sender, object args)
        {
            SetTheme(sender);
        }

       
        private void SetTheme(UISettings settings)
        {
            var color = settings.GetColorValue(UIColorType.Background);
            var app = Tagg.App.Current;

            Xamarin.Forms.ResourceDictionary desiredTheme;

           if (color == Windows.UI.Color.FromArgb(255, 0, 0, 0))
           {
               desiredTheme = DarkTheme.Instance;
           }
           else
           {
               desiredTheme = LightTheme.Instance;
           }

           //if current resource dictionary not 
           if (app.Resources != desiredTheme)
           {
               Device.BeginInvokeOnMainThread(() => { app.Resources = desiredTheme; });
            }
           
            
        }
    }
}
