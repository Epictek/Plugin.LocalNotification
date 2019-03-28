﻿using System;
using System.Diagnostics;
using UIKit;
using UserNotifications;

namespace Plugin.LocalNotification.Platform.iOS
{
    /// <inheritdoc />
    public class LocalNotificationDelegate : UNUserNotificationCenterDelegate
    {
        /// <inheritdoc />
        public override void DidReceiveNotificationResponse(UNUserNotificationCenter center,
            UNNotificationResponse response, Action completionHandler)
        {
            try
            {
                // Take action based on identifier
                if (!response.IsDefaultAction)
                {
                    return;
                }

                var dictionary = response.Notification.Request.Content.UserInfo;

                if (!dictionary.ContainsKey(NotificationCenter.ExtraReturnDataIos))
                {
                    return;
                }

                var subscribeItem = new NotificationTappedEventArgs
                {
                    Data = dictionary[NotificationCenter.ExtraReturnDataIos].ToString()
                };

                UIApplication.SharedApplication.InvokeOnMainThread(() =>
                {
                    var appBadges = UIApplication.SharedApplication.ApplicationIconBadgeNumber -
                                    Convert.ToInt32(response.Notification.Request.Content.Badge.ToString());
                    UIApplication.SharedApplication.ApplicationIconBadgeNumber = appBadges;

                    NotificationCenter.Current.OnNotificationTapped(subscribeItem);
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <inheritdoc />
        public override void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
        {
            try
            {
                completionHandler(UNNotificationPresentationOptions.Alert);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}