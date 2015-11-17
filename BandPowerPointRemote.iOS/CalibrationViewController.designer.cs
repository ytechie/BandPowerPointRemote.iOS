// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BandPowerPointRemote.iOS
{
	[Register ("CalibrationViewController")]
	partial class CalibrationViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIProgressView AccelXMeter { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIProgressView AccelYMeter { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIProgressView AccelZMeter { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView CalibrationScreen { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel GestureAxisText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel GForceText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton ResetButton { get; set; }

		[Action ("ResetButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void ResetButton_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (AccelXMeter != null) {
				AccelXMeter.Dispose ();
				AccelXMeter = null;
			}
			if (AccelYMeter != null) {
				AccelYMeter.Dispose ();
				AccelYMeter = null;
			}
			if (AccelZMeter != null) {
				AccelZMeter.Dispose ();
				AccelZMeter = null;
			}
			if (CalibrationScreen != null) {
				CalibrationScreen.Dispose ();
				CalibrationScreen = null;
			}
			if (GestureAxisText != null) {
				GestureAxisText.Dispose ();
				GestureAxisText = null;
			}
			if (GForceText != null) {
				GForceText.Dispose ();
				GForceText = null;
			}
			if (ResetButton != null) {
				ResetButton.Dispose ();
				ResetButton = null;
			}
		}
	}
}
