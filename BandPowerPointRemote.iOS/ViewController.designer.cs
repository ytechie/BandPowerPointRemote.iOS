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
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField AccessCodeTextBox { get; set; }

		[Action ("ConnectToServerButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void ConnectToServerButton_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (AccessCodeTextBox != null) {
				AccessCodeTextBox.Dispose ();
				AccessCodeTextBox = null;
			}
		}
	}
}
