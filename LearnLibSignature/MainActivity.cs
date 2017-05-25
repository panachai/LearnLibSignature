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
		CustomViewSignature customViewSignature;

		protected override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);

			Init();
			//customViewSignature.BackgroundImageResource = Resource.Drawable.logo_galaxy_black_64;
			Setting();
		}

		void Init() {
			//customViewSignature = new CustomViewSignature(this);
			customViewSignature = FindViewById<CustomViewSignature>(Resource.Id.csvSearchEdittext);
		}

		void Setting() {
			//customViewSignature.BackgroundImageResource = Resource.Drawable.logo_galaxy_black_64;

			customViewSignature.StrokeColor = Color.Red;
		}

	}
}

