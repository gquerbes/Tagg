using System;
using Firebase.CloudMessaging;
using Foundation;
using iAd;
using ObjCRuntime;
using UIKit;
using UserNotifications;

namespace Tagg.iOS.Messaging
{
    public class MessagingCenter  : UNUserNotificationCenterDelegate, IMessagingDelegate
    {
        public MessagingCenter()
        {

        }



        public void Init()
        {
            Firebase.Core.App.Configure();

            Firebase.CloudMessaging.Messaging.SharedInstance.Delegate = this;

            RegisterForNotifications();

            Firebase.CloudMessaging.Messaging.SharedInstance.Subscribe("/topics/all");
        }



        private void RegisterForNotifications()
        {

            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                var pushSettings = UIUserNotificationSettings.GetSettingsForTypes(
                                   UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound,
                                   new NSSet());

                UIApplication.SharedApplication.RegisterUserNotificationSettings(pushSettings);
                UIApplication.SharedApplication.RegisterForRemoteNotifications();
            }
            else
            {
                UIRemoteNotificationType notificationTypes = UIRemoteNotificationType.Alert | UIRemoteNotificationType.Badge | UIRemoteNotificationType.Sound;
                UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(notificationTypes);
            }
        }

        public override void DidReceiveNotificationResponse(UNUserNotificationCenter center, UNNotificationResponse response, [BlockProxy(typeof(AdAction))] Action completionHandler)
        {
            base.DidReceiveNotificationResponse(center, response, completionHandler);
        }
      
    }
}
