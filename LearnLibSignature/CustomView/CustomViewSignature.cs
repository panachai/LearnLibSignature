
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Xamarin.Controls;

namespace LearnLibSignature {
	public class CustomViewSignature : View {
		//SignaturePadView signaturePad;

		public CustomViewSignature(Context context) :
			base(context) {
			Initialize();
		}

		public CustomViewSignature(Context context, IAttributeSet attrs) :
			base(context, attrs) {
			Initialize();
		}

		public CustomViewSignature(Context context, IAttributeSet attrs, int defStyle) :
			base(context, attrs, defStyle) {
			Initialize();
		}

		void Initialize() {



			//signaturePad = (FindViewById<SignaturePadView>(Resource.Id.signaturePad);


			

		}
	}
}
