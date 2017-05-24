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

		private const bool EnableCustomization = true;

		CompressBitmapToPng testCompress = new CompressBitmapToPng();

		protected override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);

			var signature = FindViewById<SignaturePadView>(Resource.Id.signatureView);


			var btnSave = FindViewById<Button>(Resource.Id.btnSave);
			btnSave.Click += delegate {
				if (signature.IsBlank) {
					// display the base line for the user to sign on.
					AlertDialog.Builder alert = new AlertDialog.Builder(this);
					alert.SetMessage("No signature to save.");
					alert.SetNeutralButton("Okay", delegate { });
					alert.Create().Show();
				}

			};
			btnSave.Dispose();

			var btnLoad = FindViewById<Button>(Resource.Id.btnLoad);
			btnLoad.Click += delegate {
				if (points != null)
					signature.LoadPoints(points);

				Bitmap imagen = signature.GetImage(Color.Black, Color.White, false);

				ImageView imvTest = FindViewById<ImageView>(Resource.Id.imvTest);
				imvTest.SetImageBitmap(imagen);


				//ExportBitmapAsPNG(imagen);

			};
			btnLoad.Dispose();

			//this.A();

		}
		/*
		public MainActivity A() {
			return this;

		}
		*/

		public Bitmap ExportBitmapAsPNG(Bitmap bitmap) { //save to card
			var sdCardPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
			//var sdCardPath = "/storage/emulated/";
			var filePath = System.IO.Path.Combine(sdCardPath, "test.png");

			//"/storage/emulated/test.png"
			var stream = new FileStream(filePath, FileMode.Create);
			bitmap.Compress(Bitmap.CompressFormat.Png, 100, stream);
			stream.Close();

			return bitmap;
		}

	}
}

