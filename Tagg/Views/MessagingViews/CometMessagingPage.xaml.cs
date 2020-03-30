using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tagg.Views.MessagingViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CometMessagingPage : ContentPage
    {
        IChatManager chat;
        public CometMessagingPage()
        {
            InitializeComponent();
            chat = DependencyService.Get<IChatManager>();
            chat.DoThing();
        }
    }
}