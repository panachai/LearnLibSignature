using System.IO;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using Xamarin.Controls;


namespace LearnLibSignature {
	[Activity(Label = "LearnLibSignature", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity {
		protected override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);


		}
	}
}

