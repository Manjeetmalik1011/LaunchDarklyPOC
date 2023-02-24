
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RMGLaunchDarklyPOC.CommonUtility;

namespace RMGLaunchDarklyPOC
{
	[Activity (Label = "LoginActivity")]			
	public class LoginActivity : Activity
	{
        private EditText email;
        private EditText password;
        protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
            BindLayoutItems();
        }

        public void BindLayoutItems()
        {
            SetContentView(Resource.Layout.Login);
            email = FindViewById<EditText>(Resource.Id.et_username);
            password = FindViewById<EditText>(Resource.Id.et_password);

            email.Text = GlobalSettings.userName;
            password.Text = GlobalSettings.password;
            var button = FindViewById<Button>(Resource.Id.btn_login);
            button.Click += DoLogin;
        }
        public void DoLogin(object sender, EventArgs e)
        {
            if (email.Text == GlobalSettings.userName && password.Text == GlobalSettings.password)
            {
                LaunchDaklyUtility.Init();
                Toast.MakeText(this, "Login successfully done!", ToastLength.Long).Show();
                StartActivity(typeof(LocationActivity));
            }
            else
            {
                //Toast.makeText(getActivity(), "Wrong credentials found!", Toast.LENGTH_LONG).show();  
                Toast.MakeText(this, "Wrong credentials found!", ToastLength.Long).Show();
            }
        }
    }
}

