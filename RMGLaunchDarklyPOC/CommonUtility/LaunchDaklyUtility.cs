using System;
using LaunchDarkly.Sdk;
using LaunchDarkly.Sdk.Client;


namespace RMGLaunchDarklyPOC.CommonUtility
{
    public class LaunchDaklyUtility
    {
        public static void Init()
        {
            var arrayValue = LdValue.BuildArray();
            arrayValue.Add("29_Abandeen");
            arrayValue.Add("30_AdobeDo");
            arrayValue.Add("31_MailCenter");



            var context = Context.Builder(GlobalSettings.userAuthToken)
             .Name(GlobalSettings.userName)
             .Set("Locations", arrayValue.Build())
             .Build();



            var timeSpan = TimeSpan.FromSeconds(10);
            MainActivity._LdClientInstance = LdClient.Init(
             GlobalSettings.mobileKey,
             context,
             timeSpan
            );
            if (MainActivity._LdClientInstance.Initialized)
            {
                Console.WriteLine("SDK successfully initialized!");
            }
            else
            {
                Console.WriteLine("SDK failed to initialize");
            }
        }
    }
}

