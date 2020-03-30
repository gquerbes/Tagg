using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tagg.Views;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cometchat.Inscripts.Com.Cometchatcore.Coresdk;
using Tagg.Views.MessagingViews;
using CometChatUIBinding.Additions;
using Org.Json;
using Xamarin.Forms;

[assembly: Dependency(typeof(Tagg.Droid.Views.ChatModule))]
namespace Tagg.Droid.Views
{
    public class ChatModule : IChatManager
    {
        String siteurl = "";
        String licenseKey = "COMETCHAT-XXXXX-XXXXX-XXXXX-XXXXX";
        String apiKey = "xxxxxxxxxxxxxxxxxxxxxx";
        Boolean isCometOnDemand = true;
        CometChat cometChat = CometChat.GetInstance(Android.App.Application.Context);


        public void DoThing()
        {
            cometChat.InitializeCometChat(
           siteurl,
           licenseKey,
           apiKey,
           isCometOnDemand,
   new CometChatCallback((JSONObject obj) =>
   {
        /*code block on success */
   }, (JSONObject obj) =>
   {
        /*code block on success */
   }));
        }
        public ChatModule()
        {
           
        }


    }
}