using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Tagg.ViewModels.ProfileViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tagg.Views.ProfileViews
{
    public partial class ProfileListView : ContentView
    {
        ProfileListViewModel _vm;


        public ProfileListView()
        {
            InitializeComponent();
            _vm = new ProfileListViewModel();
            this.BindingContext = _vm;

        }
    }
}
