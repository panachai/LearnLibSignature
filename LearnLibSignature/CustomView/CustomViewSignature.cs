
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Xamarin.Controls;

namespace LearnLibSignature {
	public class CustomViewSignature : RelativeLayout {

		private const bool EnableCustomization = true;
		private System.Drawing.PointF[] points;
		SignaturePadView signature;

		Context context;

		public CustomViewSignature(Context context) :
			base(context) {
			this.context = context;
			Initialize();
		}

		public CustomViewSignature(Context context, IAttributeSet attrs) :
			base(context, attrs) {
			this.context = context;
			Initialize();
		}

		public CustomViewSignature(Context context, IAttributeSet attrs, int defStyle) :
			base(context, attrs, defStyle) {
			this.context = context;
			Initialize();
		}

		void Initialize() {
			LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
			View view = inflater.Inflate(Resource.Layout.SingnatureView, this);

			SetSignature();

		}

		void SetSignature() {
			signature = FindViewById<SignaturePadView>(Resource.Id.signatureView);

		}

		void SetBtnSaveAndLoad() {
			var btnSave = FindViewById<Button>(Resource.Id.btnSave);
			btnSave.Click += delegate {
				if (signature.IsBlank) {
					// display the base line for the user to sign on.
					AlertDialog.Builder alert = new AlertDialog.Builder(context);
					alert.SetMessage("No signature to save.");
					alert.SetNeutralButton("Okay", delegate { });
					alert.Create().Show();
				}
				points = signature.Points;
			};
			btnSave.Dispose();

			var btnLoad = FindViewById<Button>(Resource.Id.btnLoad);
			btnLoad.Click += delegate {
				if (points != null)
					signature.LoadPoints(points);

				Bitmap imagen = signature.GetImage(Color.Black, Color.White, false);

				ImageView imvTest = FindViewById<ImageView>(Resource.Id.imvTest);
				imvTest.SetImageBitmap(imagen);
			};
			btnLoad.Dispose();
		}


	}
}
