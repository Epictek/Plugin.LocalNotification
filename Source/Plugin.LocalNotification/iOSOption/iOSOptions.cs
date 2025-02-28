﻿namespace Plugin.LocalNotification.iOSOption
{
    /// <summary>
    /// NotificationRequest for iOS
    /// </summary>
    public class iOSOptions
    {
        /// <summary>
        /// Setting this flag will prevent iOS from displaying the default banner when a Notification is received in foreground
        /// Default is false
        /// </summary>
        public bool HideForegroundAlert { get; set; }

        /// <summary>
        /// Setting this flag will enable iOS to play the default notification sound even if the app is in foreground
        /// Default is false
        /// </summary>
        public bool PlayForegroundSound { get; set; }

        /// <summary>
        /// The Priority determines the degree of Priority associated with the notification.
        /// Default is active
        /// </summary>
        public iOSPriority Priority { get; set; } = iOSPriority.Active;

        /// <summary>
        /// The system uses the relevanceScore, a value between 0 and 1, to sort the notifications from your app. The highest score gets featured in the notification summary.
        /// </summary>
        public double RelevanceScore { get; set; }

        /// <summary>
        /// The string the notification adds to the category’s summary format string.
        /// </summary>
        public string SummaryArgument { get; set; }

        /// <summary>
        /// The number of items the notification adds to the category’s summary format string.
        /// </summary>
        public int SummaryArgumentCount { get; set; }
    }
}