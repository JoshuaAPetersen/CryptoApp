using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace CryptoApp_Test1
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android.InstalledApp("com.companyname.cryptoapp").EnableLocalScreenshots().StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}