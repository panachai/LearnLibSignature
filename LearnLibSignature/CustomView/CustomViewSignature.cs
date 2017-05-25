
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
using Android.Graphics.Drawables;

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
		public Color StrokeColor {
			get {
				return signature.StrokeColor;
			}
			set {
				this.SetStrokeColor(value);
			}
		}
		public int BackgroundImageResource {
			set {
				this.SetImageResource(value);
			}

		}
		public int BackgroundImageViewAlpha {
			set {
				this.SetBackgroundImageViewAlpha(value);
			}
		}
		public Boolean AdjustViewBounds {
			set {
				SetAdjustViewBounds(value);
			}
		}

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

			SetBtnSaveAndLoad();
		}

		void SetTextCaption(string value) {
			signature.Caption.Text = value;
		}
		public void SetTypeface(Typeface typeface, TypefaceStyle typefaceStyle) {
			signature.Caption.SetTypeface(typeface, typefaceStyle);
		}
		void SetTextSizeCaption(float value) {
			signature.Caption.SetTextSize(global::Android.Util.ComplexUnitType.Sp, value);
		}
		void SetTextSignaturePrompt(string value) {
			signature.SignaturePrompt.Text = value;
		}
		public void SetSignaturePromptTypeface(Typeface typeface, TypefaceStyle typefaceStyle) {
			signature.SignaturePrompt.SetTypeface(typeface, typefaceStyle);
		}
		void SetTextSizeSignaturePrompt(float value) {
			signature.SignaturePrompt.SetTextSize(global::Android.Util.ComplexUnitType.Sp, value);
		}
		void SetBackgoundColor(Color value) {
			signature.BackgroundColor = value;//Color.Rgb(255, 255, 200)
		}
		void SetStrokeColor(Color value) {
			signature.StrokeColor = value;
		}
		void SetImageResource(int value) {
			signature.BackgroundImageView.SetImageResource(value);
		}
		void SetBackgroundImageViewAlpha(int value) {
			signature.BackgroundImageView.SetAlpha(value);
		}
		void SetAdjustViewBounds(Boolean value) {
			signature.BackgroundImageView.SetAdjustViewBounds(value);
		}

		public void SetLayout() {
			SetSignatureLayout(10, 10, 10, 10, LayoutRules.CenterInParent);
		}
		public void SetLayout(int top, int left, int right, int bottom) {
			SetSignatureLayout(top, left, right, bottom, LayoutRules.CenterInParent);
		}
		public void SetLayout(int top, int left, int right, int bottom, LayoutRules layoutRules) {
			SetSignatureLayout(top, left, right, bottom, layoutRules);
		}
		private void SetSignatureLayout(int left, int top, int right, int bottom, LayoutRules layoutRules) { //have override
			var layout = new RelativeLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
			layout.AddRule(layoutRules);
			layout.SetMargins(left, top, right, bottom);
			signature.BackgroundImageView.LayoutParameters = layout;
		}

		public void SetPadding(int left, int top, int right, int bottom) {
			var caption = signature.Caption;
			caption.SetPadding(left, top, right, bottom);
		}


		//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++



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
