
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
using LaunchDarkly.Sdk.Client;
using static Android.App.LauncherActivity;

namespace RMGLaunchDarklyPOC
{
	[Activity (Label = "LocationActivity")]			
	public class LocationActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
            BindLayoutUiItems();
        }

		public void BindLayoutUiItems()
		{
            SetContentView(Resource.Layout.Location);

            var items = new List<string>() { "----------Choose your location-----------", "29_Abandeen", "30_AdobeDo", "31_MailCenter" };
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, items);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            var spinner = FindViewById<Spinner>(Resource.Id.spinner_id);
            spinner.Adapter = adapter;

            spinner.ItemSelected += (sender, e) =>
            {
                var selectedItem = sender as Spinner;
                var selectedLocationName = selectedItem.GetItemAtPosition(e.Position);
                Toast.MakeText(this, "Selected location is " + selectedItem.GetItemAtPosition(e.Position), ToastLength.Short).Show();
                BindListdataOnLocationChnage(selectedLocationName.ToString());
            };
        }

        public void BindListdataOnLocationChnage(string selectedLocation)
        {
            // Code to read all flags
            if(MainActivity._LdClientInstance.Initialized)
            {
                var flags = MainActivity._LdClientInstance.AllFlags();
                if (flags != null && flags.Count > 0)
                {
                    List<string> flagListData = new List<string>();
                    foreach (var items in flags)
                    {
                        var lstflagValue = MainActivity._LdClientInstance.BoolVariation(items.Key, false);
                        var simtestFlagData = string.Format("Feature flag: " + items.Key + " = {0}", lstflagValue);
                        flagListData.Add(simtestFlagData);
                    }
                    if (flagListData != null && flagListData.Count > 0)
                    {

                        var mainList = (ListView)FindViewById<ListView>(Resource.Id.listview_id);
                        mainList.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, flagListData.ToArray());
                    }
                }
            }
            
           
        }
    }
}

