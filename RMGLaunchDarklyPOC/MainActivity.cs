using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using LaunchDarkly.Sdk.Client;

namespace RMGLaunchDarklyPOC
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public static LdClient _LdClientInstance;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            BindLayoutUi();
        }

        public void BindLayoutUi()
        {
            SetContentView(Resource.Layout.activity_main);
            StartActivity(typeof(LoginActivity));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}
