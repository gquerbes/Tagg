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

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName.Equals("Height"))
            {
                if(this.Height + 180 >= Device.info.ScaledScreenSize.Height && !_vm.IsFullScreen)
                {
                    _vm.IsFullScreen = true;
                    //TODO: Alert parent view to stop panning so that user can scroll back to top of list
                }
                else if(!(this.Height + 180 >= Device.info.ScaledScreenSize.Height) && _vm.IsFullScreen)
                {
                    _vm.IsFullScreen = false;
                }
            }
        }


        public ProfileListView()
        {
            InitializeComponent();
            _vm = new ProfileListViewModel();
            this.BindingContext = _vm;

        }
    }
}
