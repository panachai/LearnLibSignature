using System;
using System.IO;
using Android.Graphics;
using Android.Util;

using Xamarin.Controls;

namespace LearnLibSignature {
	public class CompressBitmapToPng {

		private System.Drawing.PointF[] points;


		public CompressBitmapToPng CompressAndDecoded(int signatureView) {
			var signature = FindViewById<SignaturePadView>(signatureView);



			return this;
		}

		public CompressBitmapToPng SaveSignature() {
			points = signature.Points;
			return this;
		}

		/*
				if (EnableCustomization) {
				//var root = FindViewById<View>(Resource.Id.rootView);

				signature.Caption.Text = "Authorization Signature";
				signature.Caption.SetTypeface(Typeface.Serif, TypefaceStyle.BoldItalic);
				signature.Caption.SetTextSize(global::Android.Util.ComplexUnitType.Sp, 16f);
				signature.SignaturePrompt.Text = ">>";
				signature.SignaturePrompt.SetTypeface(Typeface.SansSerif, TypefaceStyle.Normal);
				signature.SignaturePrompt.SetTextSize(global::Android.Util.ComplexUnitType.Sp, 32f);
				signature.BackgroundColor = Color.Rgb(255, 255, 200); // a light yellow.
				signature.StrokeColor = Color.Black;

				signature.BackgroundImageView.SetImageResource(Resource.Drawable.logo_galaxy_black_64);
				signature.BackgroundImageView.SetAlpha(16);
				signature.BackgroundImageView.SetAdjustViewBounds(true);

				var layout = new RelativeLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
				layout.AddRule(LayoutRules.CenterInParent);
				layout.SetMargins(20, 20, 20, 20);
				signature.BackgroundImageView.LayoutParameters = layout;

				// You can change paddings for positioning...
				var caption = signature.Caption;
				caption.SetPadding(caption.PaddingLeft, 1, caption.PaddingRight, 25);
			}
		*/




		public CompressBitmapToPng CompressAndDecoded(Bitmap bitmap) {
			Bitmap original = BitmapFactory.decodeStream(getAssets().open("1024x768.jpg"));
			ByteArrayOutputStream out = new ByteArrayOutputStream();
			original.compress(Bitmap.CompressFormat.Png, 100, out);
			Bitmap decoded = BitmapFactory.decodeStream(new ByteArrayInputStream(out.toByteArray()));

			Log.e("Original   dimensions", original.getWidth() + " " + original.getHeight());
			Log.e("Compressed dimensions", decoded.getWidth() + " " + decoded.getHeight());

			return this;
		}



		/*
var sdCardPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
var filePath = System.IO.Path.Combine(sdCardPath, "test.png");
var stream = new FileStream(filePath, FileMode.Create);
bitmap.Compress(Bitmap.CompressFormat.Png, 100, stream);
			stream.Close();
		*/
	}
}
