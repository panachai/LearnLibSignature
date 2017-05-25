
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.IO;
using Java.Nio;
using Xamarin.Controls;
using System.Net.Http;

using Android.Graphics;

namespace LearnLibSignature {
	public class CustomViewSignature : RelativeLayout {

		private const bool EnableCustomization = true;
		private System.Drawing.PointF[] points;
		SignaturePadView signature;
		Context context;

		//Properties
		public string TextCaption {
			get {
				return signature.Caption.Text;
			}
			set {
				this.SetTextCaption(value);
			}
		}
		public float TextSizeCaption {
			get {
				return signature.Caption.TextSize;
			}
			set {
				this.SetTextSizeCaption(value);

			}
		}
		public string TextSignaturePrompt {
			get {
				return signature.SignaturePrompt.Text;
			}
			set {
				this.SetTextSignaturePrompt(value);
			}
		}
		public float TextSizeSignaturePrompt {
			get {
				return signature.SignaturePrompt.TextSize;
			}
			set {
				this.SetTextSizeSignaturePrompt(value);
			}
		}

		public Color BackgroundColor {
			get {
				return signature.BackgroundColor;
			}
			set {
				this.SetBackgoundColor(value);
			}
		}

		void SetBackgoundColor(Color value) {
			signature.BackgroundColor = value;//Color.Rgb(255, 255, 200)
		}

		/**
		 * 
signature.BackgroundColor = Color.Rgb(255, 255, 200); // a light yellow.
		signature.StrokeColor = Color.Black;*/


		void SetTextCaption(string txtValue) {
			signature.Caption.Text = txtValue;
		}

		void SetTypeface(Typeface typeface, TypefaceStyle typefaceStyle) {
			signature.Caption.SetTypeface(typeface, typefaceStyle);
		}

		void SetTextSizeCaption(float size) {
			signature.Caption.SetTextSize(global::Android.Util.ComplexUnitType.Sp, size);
		}

		void SetTextSignaturePrompt(string txtValuePrompt) {
			signature.SignaturePrompt.Text = txtValuePrompt;
		}

		void SetSignaturePromptTypeface(Typeface typeface, TypefaceStyle typefaceStyle) {
			signature.SignaturePrompt.SetTypeface(typeface, typefaceStyle);
		}

		void SetTextSizeSignaturePrompt(float value) {
			signature.SignaturePrompt.SetTextSize(global::Android.Util.ComplexUnitType.Sp, value);
		}




		//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

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

			signature = FindViewById<SignaturePadView>(Resource.Id.signatureView);

			TestSettingSignature();

			SetBtnSaveAndLoad();
		}

		void TestSettingSignature() {
			//signature.Caption.Text = "Authorization Signature";
			//signature.Caption.SetTypeface(Typeface.Serif, TypefaceStyle.BoldItalic);
			//signature.Caption.SetTextSize(global::Android.Util.ComplexUnitType.Sp, TextSize); //TextSize+
			//signature.SignaturePrompt.Text = ">>";
			//signature.SignaturePrompt.SetTypeface(Typeface.SansSerif, TypefaceStyle.Normal);
			//signature.SignaturePrompt.SetTextSize(global::Android.Util.ComplexUnitType.Sp, 32f);
			//signature.BackgroundColor = Color.Rgb(255, 255, 200); // a light yellow.
			//signature.StrokeColor = Color.Black;

			//signature.BackgroundImageView.SetImageResource(Resource.Drawable.logo_galaxy_black_64);
			//signature.BackgroundImageView.SetAlpha(16);
			//signature.BackgroundImageView.SetAdjustViewBounds(true);

			//var layout = new RelativeLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
			//layout.AddRule(LayoutRules.CenterInParent);
			//layout.SetMargins(20, 20, 20, 20);
			//signature.BackgroundImageView.LayoutParameters = layout;

			//// You can change paddings for positioning...
			//var caption = signature.Caption;
			//caption.SetPadding(caption.PaddingLeft, 1, caption.PaddingRight, 25);
		}




		public byte[] CompressBitmapAsync(Bitmap bitmapList) {

			byte[] bitmapData;
			var stream = new MemoryStream();
			bitmapList.Compress(Bitmap.CompressFormat.Jpeg, 50, stream);
			bitmapData = stream.ToArray();
			return bitmapData;
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
				//do save
				points = signature.Points;
			};
			btnSave.Dispose();

			var btnLoad = FindViewById<Button>(Resource.Id.btnLoad);
			btnLoad.Click += delegate {
				if (points != null)
					//do load
					signature.LoadPoints(points);

				//into bitmap
				Bitmap imagen = signature.GetImage(Color.Black, Color.White, false);

				//compress bitmap++++++++++++++++++++++++++++++++++++++++++++++++++
				Bitmap smallImagen = imagen;

				//into imageview
				ImageView imvTest = FindViewById<ImageView>(Resource.Id.imvTest);
				imvTest.SetImageBitmap(imagen);
			};
			btnLoad.Dispose();
		}


	}
}
