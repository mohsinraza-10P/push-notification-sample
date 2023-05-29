using Plugin.FirebasePushNotification;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PushNotificationSample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

            CrossFirebasePushNotification.Current.OnTokenRefresh += OnTokenRefresh;
            CrossFirebasePushNotification.Current.OnNotificationReceived += OnNotificationReceived;
            CrossFirebasePushNotification.Current.OnNotificationOpened += OnNotificationOpened;
            CrossFirebasePushNotification.Current.OnNotificationAction += OnNotificationAction;
            CrossFirebasePushNotification.Current.OnNotificationError += OnNotificationError;
            CrossFirebasePushNotification.Current.OnNotificationDeleted += OnNotificationDeleted;
        }

        private void OnNotificationDeleted(object source, FirebasePushNotificationDataEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"OnNotificationDeleted");
            PrintDictionary(e.Data);
        }

        private void OnNotificationReceived(object source, FirebasePushNotificationDataEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"OnNotificationReceived");
            PrintDictionary(e.Data);
            Device.BeginInvokeOnMainThread(async () => {
                await Application.Current.MainPage.DisplayAlert($"{e.Data["title"]}", $"{e.Data["body"]}", "OK");
            });
        }

        private void OnNotificationError(object source, FirebasePushNotificationErrorEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"OnNotificationError: {e.Message}");
        }

        private void OnNotificationAction(object source, FirebasePushNotificationResponseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"OnNotificationAction");
            PrintDictionary(e.Data);
        }

        private void OnNotificationOpened(object source, FirebasePushNotificationResponseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"OnNotificationOpened");
            PrintDictionary(e.Data);
        }

        private void OnTokenRefresh(object source, FirebasePushNotificationTokenEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"OnTokenRefresh: {e.Token}");
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private void PrintDictionary(IDictionary<string, object> data)
        {
            if (data != null && data.Count > 0)
            {
                foreach (var item in data)
                {
                    System.Diagnostics.Debug.WriteLine($"[{item.Key}: {item.Value}]");
                }
            }
        }
    }
}
