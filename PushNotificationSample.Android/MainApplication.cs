using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Plugin.FirebasePushNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PushNotificationSample.Droid
{
    [Application]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer) : base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            // Set the default notification channel for your app when running Android Oreo
            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
            {
                FirebasePushNotificationManager.DefaultNotificationChannelId = "PNSampleChannelID";
                FirebasePushNotificationManager.DefaultNotificationChannelName = "General";
                FirebasePushNotificationManager.DefaultNotificationChannelImportance = NotificationImportance.High;
            }

            FirebasePushNotificationManager.Initialize(this, false);

            // Handle notification when app is closed here
            CrossFirebasePushNotification.Current.OnNotificationReceived += OnNotificationReceived;
        }

        private void OnNotificationReceived(object source, FirebasePushNotificationDataEventArgs e)
        {

        }
    }
}